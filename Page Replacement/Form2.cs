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

        public void ubaci_u_tabelu(List<BigInteger> a, int okvir)
        {
            dataGridView1.ColumnCount = a.Count;
            dataGridView1.RowCount = okvir + 1;

            for (int i = 0; i < a.Count; i++)
            {
                dataGridView1.Columns[i].Name = Convert.ToString(a[i]);
                //dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.Silver;
                this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // FIFO algoritam

            BigInteger[] temp = new BigInteger[okvir];

            for (int i = 0; i < okvir; i++)
            {
                temp[i] = -1;
            }

            int broj_zvezdica = 0;
            int indeks = 0;

            for (int i = 0; i < a.Count; i++)
            {
                bool dostupan = true;

                for (int j = 0; j < okvir; j++)
                {
                    if (a[i] == temp[j])
                    {
                        dostupan = false;
                    }
                }

                if (dostupan)
                {
                    temp[indeks] = a[i];
                    indeks = (indeks + 1) % okvir;

                    for (int j = 0; j < okvir; j++)
                    {
                        //Color clr = ColorTranslator.FromHtml("#d3d0cb");  // povezivanje boja sa hex kodom
                        //dataGridView1.Columns[i].Width = 70;  // podesavanje visine i duzine
                        //dataGridView1.Rows[j].Height = 40;    // podesavanje visine i duzine

                        if (temp[j] == -1)
                        {
                            this.dataGridView1.Rows[j].Cells[i].Value = " ";
                        }

                        else
                        {
                            this.dataGridView1.Rows[j].Cells[i].Value = temp[j];
                        }
                     
                        if (Convert.ToString(temp[j]) == dataGridView1.Columns[i].HeaderText)
                        {
                            this.dataGridView1.Rows[j].Cells[i].Style.ForeColor = Color.Red;
                        }

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

                        if (temp[j] == -1)
                        {
                            this.dataGridView1.Rows[j].Cells[i].Value = " ";
                        }

                        else
                        {
                            this.dataGridView1.Rows[j].Cells[i].Value = temp[j];
                        }

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
            label3.Text = "Broj promašaja : " + (a.Count - broj_zvezdica);
            label4.Text = "Ukupan broj referenci : " + a.Count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FIFO (First In, First Out) algoritam je jedan od pristupa koji se prirodno nameće i predlaže da se iz memorije izbacuju stranice po redosledu po kojem su učitane. Loša osobina ovog algoritma je činjenica da se u memoriju obično na početku učitavaju stranice koje su važne i često se koriste, a one bi ovakvim pristupom bile relativno brzo izbačene.");
        }
    }
}
