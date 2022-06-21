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
            this.startUpScreenBox = new System.Windows.Forms.PictureBox();
            this.bottomHeartBoxImage = new System.Windows.Forms.PictureBox();
            this.middleHeartBoxImage = new System.Windows.Forms.PictureBox();
            this.topHeartBoxImage = new System.Windows.Forms.PictureBox();
            this.foregroundPictureBox = new System.Windows.Forms.PictureBox();
            this.deathScreenBox = new System.Windows.Forms.PictureBox();
            this.winScreenBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.startUpScreenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomHeartBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleHeartBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topHeartBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deathScreenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winScreenBox)).BeginInit();
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
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 16;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // cooldownTimerLabel
            // 
            this.cooldownTimerLabel.AutoSize = true;
            this.cooldownTimerLabel.Location = new System.Drawing.Point(967, 24);
            this.cooldownTimerLabel.Name = "cooldownTimerLabel";
            this.cooldownTimerLabel.Size = new System.Drawing.Size(0, 13);
            this.cooldownTimerLabel.TabIndex = 1;
            // 
            // startUpScreenBox
            // 
            this.startUpScreenBox.BackColor = System.Drawing.Color.Transparent;
            this.startUpScreenBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startUpScreenBox.Image = global::SummativeProject.Properties.Resources.StartUpScreen;
            this.startUpScreenBox.Location = new System.Drawing.Point(0, 0);
            this.startUpScreenBox.Name = "startUpScreenBox";
            this.startUpScreenBox.Size = new System.Drawing.Size(1400, 900);
            this.startUpScreenBox.TabIndex = 6;
            this.startUpScreenBox.TabStop = false;
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
            // deathScreenBox
            // 
            this.deathScreenBox.BackColor = System.Drawing.Color.Transparent;
            this.deathScreenBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deathScreenBox.Image = global::SummativeProject.Properties.Resources.LoseScreen;
            this.deathScreenBox.Location = new System.Drawing.Point(0, 0);
            this.deathScreenBox.Name = "deathScreenBox";
            this.deathScreenBox.Size = new System.Drawing.Size(1400, 900);
            this.deathScreenBox.TabIndex = 7;
            this.deathScreenBox.TabStop = false;
            // 
            // winScreenBox
            // 
            this.winScreenBox.BackColor = System.Drawing.Color.Transparent;
            this.winScreenBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.winScreenBox.Image = global::SummativeProject.Properties.Resources.WinScreen;
            this.winScreenBox.Location = new System.Drawing.Point(0, 0);
            this.winScreenBox.Name = "winScreenBox";
            this.winScreenBox.Size = new System.Drawing.Size(1400, 900);
            this.winScreenBox.TabIndex = 8;
            this.winScreenBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 900);
            this.Controls.Add(this.winScreenBox);
            this.Controls.Add(this.deathScreenBox);
            this.Controls.Add(this.bottomHeartBoxImage);
            this.Controls.Add(this.middleHeartBoxImage);
            this.Controls.Add(this.topHeartBoxImage);
            this.Controls.Add(this.foregroundPictureBox);
            this.Controls.Add(this.cooldownTimerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startUpScreenBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fast Food Fight";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.startUpScreenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomHeartBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.middleHeartBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topHeartBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deathScreenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winScreenBox)).EndInit();
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
        private System.Windows.Forms.PictureBox startUpScreenBox;
        private System.Windows.Forms.PictureBox deathScreenBox;
        private System.Windows.Forms.PictureBox winScreenBox;
    }
}

