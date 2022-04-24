using System.Numerics;

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
            if (comboBox1.Text == "First In First Out (FIFO)" && !String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                string niz = textBox1.Text;
                niz = niz.Replace(",", " ");
                int n = int.Parse(textBox2.Text);
                List<BigInteger> list = niz.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToList();
                this.Hide();
                Form2 fifoforma = new Form2();
                fifoforma.Show();
                fifoforma.ubaci_u_tabelu(list, n);
            }   

            else if (comboBox1.Text == "Optimal (OPT)" && !String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                string niz = textBox1.Text;
                niz = niz.Replace(",", "");
                int n = int.Parse(textBox2.Text);
                List<BigInteger> list = niz.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToList();
                this.Hide();
                Form4 optimalforma = new Form4();
                optimalforma.Show();
                optimalforma.ubaci_u_tabelu(list, n);
            }

            else if (comboBox1.Text == "Least Recently Used (LRU)" && !String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                string niz = textBox1.Text;
                niz = niz.Replace(",", "");
                int n = int.Parse(textBox2.Text);
                List<BigInteger> list = niz.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToList();
                this.Hide();
                Form3 lruforma = new Form3();
                lruforma.Show();
                lruforma.ubaci_u_tabelu(list, n);
            }

            else
            {
                MessageBox.Show("Niste uneli dovoljno podataka! Probajte ponovo!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Virtuelna memorija (Virtual memory) predstavlja način upravljanja memorijom koji omogućava da se procesu na raspolaganje stavi memorija koja je drugačije veličine od one koja stvarno (fizički) postoji u sistemu. Pri tome je operativni sistem zadužen da omogući preslikavanje virtuelne memorije u fizičku memoriju. Postoje razni algoritmi za izbor stranice koja će biti izbačena iz memorije, a neki od njih su: First In First Out (FIFO), Optimal (OPT) i Least Recently Used (LRU).");
        }
    }
}