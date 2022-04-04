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
            string niz;
            niz = textBox1.Text;
            string str = string.Join("", niz.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

            if (comboBox1.Text == "First In First Out (FIFO)")
            {
                this.Hide();

                Form2 fifoforma = new Form2();
                fifoforma.Show();
                fifoforma.promeniText(str);
            }   

            else if (comboBox1.Text == "Optimal (OPT)")
            {
                this.Hide();
                Form4 optimalforma = new Form4();
                optimalforma.Show();
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