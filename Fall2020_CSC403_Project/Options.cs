using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            startMenu start = new startMenu();
            start.Show();
            this.Hide();
        }
    }
}