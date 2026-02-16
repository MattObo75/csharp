namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdStang_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdDolj_Click(object sender, EventArgs e)
        {
            lblVisa.Text = "Det är väl inte så svårt";
        }

        private void cmdVisa_Click(object sender, EventArgs e)
        {
            lblVisa.Text = "Hej på dig! Det är kul att programmera!";
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            lblVisa.Text = txtText.Text;
        }
    }
}
