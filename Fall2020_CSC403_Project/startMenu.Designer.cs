namespace Fall2020_CSC403_Project
{
    partial class startMenu
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
            this.Start = new System.Windows.Forms.Panel();
            this.Border = new System.Windows.Forms.Panel();
            this.Options = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.Panel();
            this.Border.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.start_button;
            this.Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Start.Location = new System.Drawing.Point(44, 59);
            this.Start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(320, 136);
            this.Start.TabIndex = 1;
            this.Start.Paint += new System.Windows.Forms.PaintEventHandler(this.Start_Paint);
            this.Start.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Start_MouseClick);
            // 
            // Border
            // 
            this.Border.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.Border;
            this.Border.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Border.Controls.Add(this.Start);
            this.Border.Controls.Add(this.Options);
            this.Border.Controls.Add(this.Exit);
            this.Border.Location = new System.Drawing.Point(11, 10);
            this.Border.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Border.Name = "Border";
            this.Border.Size = new System.Drawing.Size(396, 406);
            this.Border.TabIndex = 3;
            // 
            // Options
            // 
            this.Options.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.options_button;
            this.Options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Options.Location = new System.Drawing.Point(332, 342);
            this.Options.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(31, 30);
            this.Options.TabIndex = 2;
            this.Options.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Options_MouseClick);
            // 
            // Exit
            // 
            this.Exit.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.img_487255;
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Exit.Location = new System.Drawing.Point(44, 218);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(320, 86);
            this.Exit.TabIndex = 0;
            this.Exit.Paint += new System.Windows.Forms.PaintEventHandler(this.Exit_Paint);
            this.Exit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Exit_MouseClick);
            // 
            // startMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(418, 425);
            this.Controls.Add(this.Border);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "startMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "startMenu";
            this.Load += new System.EventHandler(this.startMenu_Load);
            this.Border.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Exit;
        private System.Windows.Forms.Panel Start;
        private System.Windows.Forms.Panel Options;
        private System.Windows.Forms.Panel Border;
    }
}