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
            StartMenu start = new StartMenu();
            start.Show();
            this.Hide();
        }
    }
}