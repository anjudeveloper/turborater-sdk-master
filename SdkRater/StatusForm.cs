using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace SdkRater
{

	/// <summary>
	/// Generic status form that can be used from anywhere. Has a progress
	/// bar and a couple of labels.
	/// </summary>
	public class StatusForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ProgressBar ProgressBar1;
		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.Label lblTimeElapsed;
		private System.ComponentModel.IContainer components;
    private System.Windows.Forms.Label lblCompanyName;
		private System.Windows.Forms.PictureBox WaitPic;

    public string CompanyNameText
    {
      get
      {
        return lblCompanyName.Text;
      }
      set
      {
        lblCompanyName.Text = value;
      }
    }

		public string TimeElapsedText
		{
			get
			{
				return lblTimeElapsed.Text;
			}
			set
			{
				lblTimeElapsed.Text = value;
			}
		}

		public virtual bool AutoProgress
		{
			set
			{
				WaitPic.Visible = value;
				ProgressBar1.Visible = !value;
			}
		}


		public StatusForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusForm));
      this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
      this.lblProgress = new System.Windows.Forms.Label();
      this.lblTimeElapsed = new System.Windows.Forms.Label();
      this.WaitPic = new System.Windows.Forms.PictureBox();
      this.lblCompanyName = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.WaitPic)).BeginInit();
      this.SuspendLayout();
      // 
      // ProgressBar1
      // 
      this.ProgressBar1.Location = new System.Drawing.Point(7, 65);
      this.ProgressBar1.Name = "ProgressBar1";
      this.ProgressBar1.Size = new System.Drawing.Size(280, 20);
      this.ProgressBar1.TabIndex = 0;
      // 
      // lblProgress
      // 
      this.lblProgress.AutoSize = true;
      this.lblProgress.Location = new System.Drawing.Point(13, 7);
      this.lblProgress.Name = "lblProgress";
      this.lblProgress.Size = new System.Drawing.Size(74, 13);
      this.lblProgress.TabIndex = 1;
      this.lblProgress.Text = "ProgressLabel";
      // 
      // lblTimeElapsed
      // 
      this.lblTimeElapsed.AutoSize = true;
      this.lblTimeElapsed.Location = new System.Drawing.Point(13, 24);
      this.lblTimeElapsed.Name = "lblTimeElapsed";
      this.lblTimeElapsed.Size = new System.Drawing.Size(68, 13);
      this.lblTimeElapsed.TabIndex = 2;
      this.lblTimeElapsed.Text = "TimeElapsed";
      // 
      // WaitPic
      // 
      this.WaitPic.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.WaitPic.Image = ((System.Drawing.Image)(resources.GetObject("WaitPic.Image")));
      this.WaitPic.Location = new System.Drawing.Point(103, 73);
      this.WaitPic.Name = "WaitPic";
      this.WaitPic.Size = new System.Drawing.Size(147, 14);
      this.WaitPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.WaitPic.TabIndex = 3;
      this.WaitPic.TabStop = false;
      this.WaitPic.Visible = false;
      // 
      // lblCompanyName
      // 
      this.lblCompanyName.AutoSize = true;
      this.lblCompanyName.Location = new System.Drawing.Point(13, 42);
      this.lblCompanyName.Name = "lblCompanyName";
      this.lblCompanyName.Size = new System.Drawing.Size(105, 13);
      this.lblCompanyName.TabIndex = 4;
      this.lblCompanyName.Text = "CompanyNameLabel";
      this.lblCompanyName.Visible = false;
      // 
      // StatusForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(354, 96);
      this.ControlBox = false;
      this.Controls.Add(this.lblCompanyName);
      this.Controls.Add(this.WaitPic);
      this.Controls.Add(this.lblTimeElapsed);
      this.Controls.Add(this.lblProgress);
      this.Controls.Add(this.ProgressBar1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "StatusForm";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "VPU Progress";
      this.Load += new System.EventHandler(this.StatusForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.WaitPic)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

		}
		#endregion

		private void StatusForm_Load(object sender, System.EventArgs e)
		{
			if (ProgressBar1.Visible)
			{
				lblProgress.Text = "";
				lblTimeElapsed.Text = "";
        lblCompanyName.Text = "";
				Text = "VPU Progress";
			}
		}

		/// <summary>
		/// Steps the progress on the form
		/// </summary>
		/// <param name="progressText">Text of the progress label</param>
		/// <param name="timeText">Text of the elapsed time label</param>
		public void PerformStep(string progressText, string timeText)
		{
			lblProgress.Text = progressText;
			lblTimeElapsed.Text = timeText;
      lblCompanyName.Text = CompanyNameText;
			ProgressBar1.PerformStep();
		}

		/// <summary>
		/// Steps the progress on the form
		/// </summary>
		/// <param name="progressText">Text of the progress label</param>
		public void PerformStep(string progressText)
		{
			lblProgress.Text = progressText;
			ProgressBar1.PerformStep();
		}

		/// <summary>
		/// Steps the progress on the form
		/// </summary>
		public void PerformStep()
		{
			ProgressBar1.PerformStep();
		}

    public bool CompanyNameVisible
    {
      get
      {
        return lblCompanyName.Visible;
      }
      set
      {
        lblCompanyName.Visible = value;
      }
    }

		/// <summary>
		/// Visibility of the progress bar at the bottom of the form.
		/// </summary>
		public bool ProgressBarVisible
		{
			get
			{
				return ProgressBar1.Visible;
			}
			set
			{
				ProgressBar1.Visible = value;
			}
		}

		/// <summary>
		/// The text of this status form
		/// </summary>
		public string FormText
		{
			get
			{
				return this.Text;
			}
			set
			{
				this.Text = value;
			}
		}

		/// <summary>
		/// The text of the progress label
		/// </summary>
		public string ProgressText
		{
			get
			{
				return lblProgress.Text;
			}
			set
			{
				lblProgress.Text = value;
			}
		}

		/// <summary>
		/// The minimum value for the progress bar
		/// </summary>
		public int Minimum
		{
			get
			{
				return ProgressBar1.Minimum;
			}
			set
			{
				ProgressBar1.Minimum = value;
			}
		}

		/// <summary>
		/// The maximum value for the progress bar
		/// </summary>
		public int Maximum
		{
			get
			{
				return ProgressBar1.Maximum;
			}
			set
			{
				ProgressBar1.Maximum = value;
			}
		}

		/// <summary>
		/// The step amount value for the progress bar
		/// </summary>
		public int Step
		{
			get
			{
				return ProgressBar1.Step;
			}
			set
			{
				ProgressBar1.Step = value;
			}
		}

		public int ProgressValue
		{
			get
			{
				return ProgressBar1.Value;
			}
			set
			{
				ProgressBar1.Value = value;
			}
		}

		/// <summary>
		/// The date/time that the progress was started
		/// </summary>
		public virtual DateTime StartTime
		{
			get
			{
				return m_startTime;
			}
			set
			{
				m_startTime = value;
			}
		}

		private DateTime m_startTime;

	}
}
