using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Page_Replacement
{
    public partial class Form3 : Form
    {
        public Form3()
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

            // LRU algoritam

            int c = 0, c1, j, k = 0, r, t;
            int[] temp = new int[20];
            int[] b = new int[20];
            int[] c2 = new int[20];
            int broj_zvezdica = 0;
            temp[k] = (int)a[k];
            this.dataGridView1.Rows[0].Cells[0].Value = Convert.ToString(temp[k]);
            c++;
            k++;
            for (int i = 1; i < tekstZaMenjanje.Length; i++)
            {
                c1 = 0;
                for (j = 0; j < okvir; j++)
                {
                    if (a[i] != temp[j])
                        c1++;
                }
                if (c1 == okvir)
                {
                    c++;
                    if (k < okvir)
                    {
                        temp[k] = (int)a[i];
                        k++;
                    }
                    else
                    {
                        for (r = 0; r < okvir; r++)
                        {
                            c2[r] = 0;
                            for (j = i - 1; j < tekstZaMenjanje.Length; j--)
                            {
                                if (temp[r] != a[j])
                                    c2[r]++;
                                else
                                    break;
                            }
                        }
                        for (r = 0; r < okvir; r++)
                            b[r] = c2[r];
                        for (r = 0; r < okvir; r++)
                        {
                            for (j = r; j < okvir; j++)
                            {
                                if (b[r] < b[j])
                                {
                                    t = b[r];
                                    b[r] = b[j];
                                    b[j] = t;
                                }
                            }
                        }
                        for (r = 0; r < okvir; r++)
                        {
                            if (c2[r] == b[0])
                                temp[r] = (int)a[i];
                        }
                    }
                }

                else
                {
                    broj_zvezdica++;
                }

                for (j = 0; j < k; j++)
                    this.dataGridView1.Rows[j].Cells[i].Value = Convert.ToString(temp[j]);

                // ispis

                label2.Text = "Broj zvezdica: " + broj_zvezdica;
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LRU (Least Recently Used) algoritam se zasniva na ideji da se iz memorije izbaci stranica koja je korišćena najdalje u prošlosti u odnosu na ostale stranice. U ovom pristupu pokušava se predviđanje dalje sekvence zahtevanih stranica na osnovu prethodnog izvršavanja programa.");
        }
    }
}
