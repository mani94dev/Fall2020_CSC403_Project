namespace Fall2020_CSC403_Project
{
    partial class StartMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenu));
            this.Border = new System.Windows.Forms.Panel();
            this.Start = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Panel();
            this.Border.SuspendLayout();
            this.SuspendLayout();
            // 
            // Border
            // 
            this.Border.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Border.BackgroundImage")));
            this.Border.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Border.Controls.Add(this.Start);
            this.Border.Controls.Add(this.Exit);
            this.Border.Location = new System.Drawing.Point(8, 8);
            this.Border.Margin = new System.Windows.Forms.Padding(2);
            this.Border.Name = "Border";
            this.Border.Size = new System.Drawing.Size(297, 330);
            this.Border.TabIndex = 3;
            this.Border.Paint += new System.Windows.Forms.PaintEventHandler(this.Border_Paint);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.SystemColors.GrayText;
            this.Start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Start.BackgroundImage")));
            this.Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Start.Location = new System.Drawing.Point(33, 48);
            this.Start.Margin = new System.Windows.Forms.Padding(2);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(240, 83);
            this.Start.TabIndex = 1;
            this.Start.Paint += new System.Windows.Forms.PaintEventHandler(this.Start_Paint);
            this.Start.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Start_MouseClick);
            // 
            // Exit
            // 
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Exit.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Exit.Location = new System.Drawing.Point(33, 209);
            this.Exit.Margin = new System.Windows.Forms.Padding(2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(240, 70);
            this.Exit.TabIndex = 0;
            this.Exit.Paint += new System.Windows.Forms.PaintEventHandler(this.Exit_Paint);
            this.Exit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Exit_MouseClick);
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(314, 345);
            this.Controls.Add(this.Border);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "startMenu";
            this.Load += new System.EventHandler(this.startMenu_Load);
            this.Border.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Exit;
        private System.Windows.Forms.Panel Start;
        private System.Windows.Forms.Panel Border;
    }
}