namespace SettupSCE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value <= 80)
            {
                progressBar1.Value = progressBar1.Value + 20;
            }
            if (progressBar1.Value == 100)
            {
                button2.Visible = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            progressBar1.Visible = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
