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
            dataGridView1.RowCount = okvir + 1;

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
                //dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.Silver;
                this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                        //Color clr = ColorTranslator.FromHtml("#d3d0cb");  // povezivanje boja sa hex kodom
                        //dataGridView1.Columns[i].Width = 70;  // podesavanje visine i duzine
                        //dataGridView1.Rows[j].Height = 40;    // podesavanje visine i duzine
                        this.dataGridView1.Rows[j].Cells[i].Value = Convert.ToString(temp[j]);
                        //this.dataGridView1.ForeColor = Color.Black;  // boja slova
                        //dataGridView1.Columns[i].DefaultCellStyle.BackColor = clr;  // boja pozadine
                    }
                }

                else
                {
                    broj_zvezdica++;

                    for (int j = 0; j < okvir; j++)
                    {
                        //dataGridView1.Columns[i].Width = 70;
                        //dataGridView1.Rows[j].Height = 30;
                        this.dataGridView1.Rows[j].Cells[i].Value = Convert.ToString(temp[j]);
                        //Color clr = ColorTranslator.FromHtml("#d3d0cb");
                        //dataGridView1.Columns[i].DefaultCellStyle.BackColor = clr;
                    }

                    this.dataGridView1.Rows[okvir].Cells[i].Value = "*";
                }
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // ispis

            label2.Text = "Broj pogodaka : " + broj_zvezdica;
            label3.Text = "Broj promašaja : " + (tekstZaMenjanje.Length - broj_zvezdica);
            label4.Text = "Ukupan broj referenci : " + tekstZaMenjanje.Length;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FIFO (First In, First Out) algoritam je jedan od pristupa koji se prirodno nameće i predlaže da se iz memorije izbacuju stranice po redosledu po kojem su učitane. Loša osobina ovog algoritma je činjenica da se u memoriju obično na početku učitavaju stranice koje su važne i često se koriste, a one bi ovakvim pristupom bile relativno brzo izbačene.");
        }
    }
}
