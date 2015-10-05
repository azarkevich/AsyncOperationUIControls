using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsyncOperationUIControls.Properties;

namespace AsyncOperationUIControls
{
	public partial class SimplifiedBackgroundOperation : UserControl
	{
		string _notStartedText = "Not started";
		string _rantoCompletionText = "Completed";
		string _errorTemplateText = "Error: {0}";
		string _cancelledText = "Cancelled";
		string _inProgressText = "In Progress...";

		public SimplifiedBackgroundOperation()
		{
			InitializeComponent();

			label.Text = NotStartedText ?? "";
		}

		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public string NotStartedText
		{
			get
			{
				return _notStartedText;
			}
			set
			{
				_notStartedText = value;
			}
		}

		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public string InProgressText
		{
			get
			{
				return _inProgressText;
			}
			set
			{
				_inProgressText = value;
			}
		}

		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public string RanToCompletionText
		{
			get
			{
				return _rantoCompletionText;
			}
			set
			{
				_rantoCompletionText = value;
			}
		}

		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public string ErrorTemplateText
		{
			get
			{
				return _errorTemplateText;
			}
			set
			{
				_errorTemplateText = value;
			}
		}

		[Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
		public string CancelledText
		{
			get
			{
				return _cancelledText;
			}
			set
			{
				_cancelledText = value;
			}
		}

		public void Reset()
		{
			pictureBox.Image = Resources.notstarted;
		}

		public void Track(Task task)
		{
			pictureBox.Image = Resources.spin;
			label.Text = InProgressText;
			label.ForeColor = DefaultForeColor;
			toolTip.RemoveAll();

			task
				.ContinueWith(t => {

					if (t.IsCanceled)
					{
						label.Text = CancelledText;
						label.ForeColor = Color.Peru;
						pictureBox.Image = Resources.cancelled;
					}
					else if (t.IsFaulted)
					{
						var ex = t.Exception.InnerException;

						if(ex is TaskCanceledException)
						{
							label.Text = CancelledText;
							label.ForeColor = Color.Peru;
							pictureBox.Image = Resources.cancelled;
						}
						else
						{
							pictureBox.Image = Resources.Error.ToBitmap();
							label.Text = string.Format(_errorTemplateText, ex.Message, ex);
							label.ForeColor = Color.Red;
							toolTip.SetToolTip(pictureBox, t.Exception.InnerException.Message);
							toolTip.SetToolTip(label, t.Exception.InnerException.ToString());
						}
					}
					else
					{
						pictureBox.Image = Resources.ok;
						label.Text = RanToCompletionText;
					}

				}, TaskScheduler.FromCurrentSynchronizationContext())
			;
		}
	}
}
