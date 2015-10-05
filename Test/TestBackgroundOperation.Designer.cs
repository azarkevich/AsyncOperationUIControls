namespace Test
{
	partial class TestBackgroundOperation
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.backgroundOperation1 = new AsyncOperationUIControls.BackgroundOperation();
			this.SuspendLayout();
			// 
			// backgroundOperation1
			// 
			this.backgroundOperation1.AbandonOnCancel = true;
			this.backgroundOperation1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.backgroundOperation1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.backgroundOperation1.CloseOnRanToCompletion = true;
			this.backgroundOperation1.Location = new System.Drawing.Point(278, 123);
			this.backgroundOperation1.Name = "backgroundOperation1";
			this.backgroundOperation1.Size = new System.Drawing.Size(247, 117);
			this.backgroundOperation1.TabIndex = 0;
			this.backgroundOperation1.WaitMessage = "Please wait ...";
			// 
			// TestBackgroundOperation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(799, 396);
			this.Controls.Add(this.backgroundOperation1);
			this.Name = "TestBackgroundOperation";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private AsyncOperationUIControls.BackgroundOperation backgroundOperation1;
	}
}

