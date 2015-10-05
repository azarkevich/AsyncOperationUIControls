using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
	public partial class SimpleBackgroundOperation : Form
	{
		public SimpleBackgroundOperation()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			simplifiedBackgroundOperation1.Track(StartOperation(TimeSpan.FromSeconds(5), false), "5 Seconds operation ....");
		}

		void button2_Click(object sender, EventArgs e)
		{
			simplifiedBackgroundOperation1.Track(StartOperation(TimeSpan.FromSeconds(5), true), "5 Seconds operation ....");
		}

		async Task StartOperation(TimeSpan ts, bool fail)
		{
			await Task.Run(() => Thread.Sleep(ts));

			if(fail)
				throw new Exception("Mwa-ha-ha");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			simplifiedBackgroundOperation1.Reset();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			var tcs = new TaskCompletionSource<string>();

			simplifiedBackgroundOperation1.Track(tcs.Task, "5 Seconds operation ....");

			Task.Run(() => {
				Thread.Sleep(TimeSpan.FromSeconds(5));
				tcs.SetCanceled();
			});
		}
	}
}
