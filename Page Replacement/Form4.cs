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
    public partial class Form4 : Form
    {
        public Form4()
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

            // Optimalni algoritam

            int flag1, flag2, flag3, j, k, pos = 0, max, faults = 0;
            BigInteger[] frames = new BigInteger[okvir];
            int[] temp = new int[okvir];

            for (int i = 0; i < okvir; i++)
            {
                frames[i] = -1;
            }

            for (int i = 0; i < a.Count; i++)
            {
                flag1 = flag2 = 0;

                for (j = 0; j < okvir; ++j)
                {
                    if (frames[j] == a[i])
                    {
                        this.dataGridView1.Rows[okvir].Cells[i].Value = "*";
                        flag1 = flag2 = 1;
                        break;
                    }
                }

                if (flag1 == 0)
                {
                    for (j = 0; j < okvir; ++j)
                    {
                        if (frames[j] == -1)
                        {
                            faults++;
                            frames[j] = a[i];
                            flag2 = 1;
                            break;
                        }
                    }
                }

                if (flag2 == 0)
                {
                    flag3 = 0;

                    for (j = 0; j < okvir; ++j)
                    {
                        temp[j] = -1;

                        for (k = i + 1; k < a.Count; ++k)
                        {
                            if (frames[j] == a[k])
                            {
                                temp[j] = k;
                                break;
                            }
                        }
                    }

                    for (j = 0; j < okvir; ++j)
                    {
                        if (temp[j] == -1)
                        {
                            pos = j;
                            flag3 = 1;
                            break;
                        }
                    }

                    if (flag3 == 0)
                    {
                        max = temp[0];
                        pos = 0;

                        for (j = 1; j < okvir; ++j)
                        {
                            if (temp[j] > max)
                            {
                                max = temp[j];
                                pos = j;
                            }
                        }
                    }
                    
                    frames[pos] = a[i];
                    faults++;
                }

                for (j = 0; j < okvir; ++j)
                {
                    if (frames[j] == -1)
                    {
                        this.dataGridView1.Rows[j].Cells[i].Value = " ";
                    }

                    else
                    {
                        this.dataGridView1.Rows[j].Cells[i].Value = Convert.ToString(frames[j]);
                    }

                    if (Convert.ToString(frames[j]) == dataGridView1.Columns[i].HeaderText)
                    {
                        this.dataGridView1.Rows[j].Cells[i].Style.ForeColor = Color.Red;
                    }
                }
            }

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // ispis

            label2.Text = "Broj pogodaka : " + (a.Count - faults);
            label3.Text = "Broj promašaja : " + faults;
            label4.Text = "Ukupan broj referenci : " + a.Count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Beladijev pristup predstavlja najbolji mogući način za izbor stranice koja će biti izbačena iz memorije. Ovaj pristup se naziva Beladijev optimalni algoritam za zamenu stranice. U trenutku kada nastane promašaj stranice, određeni skup stranica jednog procesa nalazi se u memoriji. Neke od tih stranica mogu biti potrebne već u sledećoj ili u nekoj od skorijih instrukcija.");
        }
    }
}
