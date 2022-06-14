namespace SummativeProject
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.cooldownTimerLabel = new System.Windows.Forms.Label();
            this.foregroundPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(719, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 8;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // cooldownTimerLabel
            // 
            this.cooldownTimerLabel.AutoSize = true;
            this.cooldownTimerLabel.Location = new System.Drawing.Point(967, 24);
            this.cooldownTimerLabel.Name = "cooldownTimerLabel";
            this.cooldownTimerLabel.Size = new System.Drawing.Size(80, 13);
            this.cooldownTimerLabel.TabIndex = 1;
            this.cooldownTimerLabel.Text = "CooldownTimer";
            // 
            // foregroundPictureBox
            // 
            this.foregroundPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.foregroundPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.foregroundPictureBox.Image = global::SummativeProject.Properties.Resources.Foreground;
            this.foregroundPictureBox.Location = new System.Drawing.Point(0, 0);
            this.foregroundPictureBox.Name = "foregroundPictureBox";
            this.foregroundPictureBox.Size = new System.Drawing.Size(422, 900);
            this.foregroundPictureBox.TabIndex = 2;
            this.foregroundPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 900);
            this.Controls.Add(this.foregroundPictureBox);
            this.Controls.Add(this.cooldownTimerLabel);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fast Food Fight";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.foregroundPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label cooldownTimerLabel;
        private System.Windows.Forms.PictureBox foregroundPictureBox;
    }
}

