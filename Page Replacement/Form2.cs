using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Numerics;

namespace Page_Replacement
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 forma1 = new Form1();
            forma1.Show();
        }

        public void ubaci_u_tabelu(string tekstZaMenjanje, int okvir)
        {
            dataGridView1.ColumnCount = tekstZaMenjanje.Length;
            dataGridView1.RowCount = okvir;
            BigInteger broj = BigInteger.Parse(tekstZaMenjanje);
            BigInteger[] a = new BigInteger[tekstZaMenjanje.Length];
            for (int i = 0; i < tekstZaMenjanje.Length; i++)
            {
                a[i] = broj % 10;
                broj /= 10;
            }
            Array.Reverse(a);
            for (int i = 0; i < tekstZaMenjanje.Length; i++)
            {
                dataGridView1.Columns[i].Name = Convert.ToString(a[i]);
            }

            // FIFO algoritam

            char[] temp = new char[okvir];

            for (int i = 0; i < okvir; i++)
            {
                temp[i] = ' ';
            }

            int broj_zvezdica = 0;
            int indeks = 0;

            for (int i = 0; i < tekstZaMenjanje.Length; i++)
            {
                bool dostupan = true;

                for (int j = 0; j < okvir; j++)
                {
                    if (a[i] == Convert.ToInt32(temp[j] - 48))
                    {
                        dostupan = false;
                    }
                }

                if (dostupan)
                {
                    temp[indeks] = Convert.ToChar((int)a[i] + 48);
                    indeks = (indeks + 1) % okvir;

                    for (int j = 0; j < okvir; j++)
                    {
                        this.dataGridView1.Rows[j].Cells[i].Value = Convert.ToString(temp[j]);
                    }
                }

                else
                {
                    broj_zvezdica++;

                    for (int j = 0; j < okvir; j++)
                    {
                        this.dataGridView1.Rows[j].Cells[i].Value = Convert.ToString(temp[j]);
                    }

                    //Console.Write("*");
                }

                //Console.WriteLine();
            }

            // ispis

            textBox1.Text = "Broj zvezdica: " + broj_zvezdica;
            //Console.WriteLine("Broj zvezdica: " + broj_zvezdica);
        }
    }
}
