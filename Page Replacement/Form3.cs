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

        public void ubaci_u_tabelu(List<BigInteger> a, int okvir)
        {
            if (a.Count <= 23)
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            dataGridView1.ColumnCount = a.Count;
            dataGridView1.RowCount = okvir + 1;

            for (int i = 0; i < a.Count; i++)
            {
                dataGridView1.Columns[i].Name = Convert.ToString(a[i]);
                this.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // LRU algoritam

            int c = 0, c1, j, k = 0, r;
            BigInteger t;
            BigInteger[] temp = new BigInteger[okvir];
            BigInteger[] b = new BigInteger[okvir];
            BigInteger[] c2 = new BigInteger[okvir];
            int broj_zvezdica = 0;
            temp[k] = a[k];
            this.dataGridView1.Rows[0].Cells[0].Value = Convert.ToString(temp[k]);
            this.dataGridView1.Rows[0].Cells[0].Style.ForeColor = Color.Red;
            c++;
            k++;
            for (int i = 1; i < a.Count; i++)
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
                        temp[k] = a[i];
                        k++;
                    }
                    else
                    {
                        for (r = 0; r < okvir; r++)
                        {
                            c2[r] = 0;
                            for (j = i - 1; j < a.Count; j--)
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
                                temp[r] = a[i];
                        }
                    }
                }

                else
                {
                    broj_zvezdica++;
                    this.dataGridView1.Rows[okvir].Cells[i].Value = "*";
                }

                for (j = 0; j < k; j++)
                {
                    if (Convert.ToString(temp[j]) == dataGridView1.Columns[i].HeaderText)
                    {
                        this.dataGridView1.Rows[j].Cells[i].Style.ForeColor = Color.Red;
                    }

                    this.dataGridView1.Rows[j].Cells[i].Value = Convert.ToString(temp[j]);
                }   
            }

            // ispis

            label2.Text = "Broj pogodaka : " + broj_zvezdica;
            label3.Text = "Broj promašaja : " + (a.Count - broj_zvezdica);
            label4.Text = "Ukupan broj referenci : " + a.Count;

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
