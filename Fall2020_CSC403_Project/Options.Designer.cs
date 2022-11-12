namespace Fall2020_CSC403_Project
{
    partial class Options
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
            this.Mute_btn = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.Sound_Icon = new System.Windows.Forms.Panel();
            this.Mute_btn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // Mute_btn
            // 
            //this.Mute_btn.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.Border;
            this.Mute_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Mute_btn.Controls.Add(this.panel1);
            this.Mute_btn.Controls.Add(this.trackBar1);
            this.Mute_btn.Controls.Add(this.Sound_Icon);
            this.Mute_btn.Location = new System.Drawing.Point(12, 12);
            this.Mute_btn.Name = "Mute_btn";
            this.Mute_btn.Size = new System.Drawing.Size(446, 507);
            this.Mute_btn.TabIndex = 0;
            // 
            // panel1
            // 
            //this.panel1.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.back_btn;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(31, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 63);
            this.panel1.TabIndex = 1;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(124, 80);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(280, 69);
            this.trackBar1.TabIndex = 0;
            // 
            // Sound_Icon
            // 
            //this.Sound_Icon.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.volume;
            this.Sound_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Sound_Icon.Location = new System.Drawing.Point(47, 80);
            this.Sound_Icon.Name = "Sound_Icon";
            this.Sound_Icon.Size = new System.Drawing.Size(71, 69);
            this.Sound_Icon.TabIndex = 0;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(470, 531);
            this.Controls.Add(this.Mute_btn);
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Mute_btn.ResumeLayout(false);
            this.Mute_btn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Mute_btn;
        private System.Windows.Forms.Panel Sound_Icon;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel1;
    }
}