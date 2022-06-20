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
            this.topHeartBoxImage = new System.Windows.Forms.PictureBox();
            this.middleHeartBoxImage = new System.Windows.Forms.PictureBox();
            this.bottomHeartBoxImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topHeartBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleHeartBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomHeartBoxImage)).BeginInit();
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
            // topHeartBoxImage
            // 
            this.topHeartBoxImage.BackColor = System.Drawing.Color.Transparent;
            this.topHeartBoxImage.BackgroundImage = global::SummativeProject.Properties.Resources.HasHeart;
            this.topHeartBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.topHeartBoxImage.Location = new System.Drawing.Point(1116, 136);
            this.topHeartBoxImage.Name = "topHeartBoxImage";
            this.topHeartBoxImage.Size = new System.Drawing.Size(263, 177);
            this.topHeartBoxImage.TabIndex = 3;
            this.topHeartBoxImage.TabStop = false;
            // 
            // middleHeartBoxImage
            // 
            this.middleHeartBoxImage.BackColor = System.Drawing.Color.Transparent;
            this.middleHeartBoxImage.BackgroundImage = global::SummativeProject.Properties.Resources.HasHeart;
            this.middleHeartBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.middleHeartBoxImage.Location = new System.Drawing.Point(1116, 349);
            this.middleHeartBoxImage.Name = "middleHeartBoxImage";
            this.middleHeartBoxImage.Size = new System.Drawing.Size(263, 177);
            this.middleHeartBoxImage.TabIndex = 4;
            this.middleHeartBoxImage.TabStop = false;
            // 
            // bottomHeartBoxImage
            // 
            this.bottomHeartBoxImage.BackColor = System.Drawing.Color.Transparent;
            this.bottomHeartBoxImage.BackgroundImage = global::SummativeProject.Properties.Resources.HasHeart;
            this.bottomHeartBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bottomHeartBoxImage.Location = new System.Drawing.Point(1116, 561);
            this.bottomHeartBoxImage.Name = "bottomHeartBoxImage";
            this.bottomHeartBoxImage.Size = new System.Drawing.Size(263, 177);
            this.bottomHeartBoxImage.TabIndex = 5;
            this.bottomHeartBoxImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 900);
            this.Controls.Add(this.bottomHeartBoxImage);
            this.Controls.Add(this.middleHeartBoxImage);
            this.Controls.Add(this.topHeartBoxImage);
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
            ((System.ComponentModel.ISupportInitialize)(this.topHeartBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleHeartBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomHeartBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label cooldownTimerLabel;
        private System.Windows.Forms.PictureBox foregroundPictureBox;
        private System.Windows.Forms.PictureBox topHeartBoxImage;
        private System.Windows.Forms.PictureBox middleHeartBoxImage;
        private System.Windows.Forms.PictureBox bottomHeartBoxImage;
    }
}

