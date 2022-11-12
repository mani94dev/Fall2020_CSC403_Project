using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fall2020_CSC403_Project.code;


namespace Fall2020_CSC403_Project
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private void startMenu_Load(object sender, EventArgs e)
        {
        }

        private void Exit_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Start_MouseClick(object sender, MouseEventArgs e)
        {
            ThemeSelection mode = new ThemeSelection();
            mode.Show();
            this.Hide();
        }

        private void Options_MouseClick(object sender, MouseEventArgs e)
        {
            Options options = new Options();
            options.Show();
            this.Hide();
        }

        private void Start_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Exit_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Border_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}