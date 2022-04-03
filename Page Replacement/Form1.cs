namespace Page_Replacement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "FIFO")
            {
                this.Hide();
                Form2 fifoforma = new Form2();
                fifoforma.Show();
            }   

            else
            {
                this.Hide();
                Form3 lruforma = new Form3();
                lruforma.Show();
            }
        }
    }
}