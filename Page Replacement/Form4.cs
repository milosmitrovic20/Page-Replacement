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

            // Optimalni algoritam

            int flag1, flag2, flag3, j, k, pos = 0, max, faults = 0;
            char[] frames = new char[10];
            int[] temp = new int[10];

            for (int i = 0; i < okvir; i++)
            {
                frames[i] = ' ';
            }

            for (int i = 0; i < tekstZaMenjanje.Length; i++)
            {
                flag1 = flag2 = 0;

                for (j = 0; j < okvir; ++j)
                {
                    if (Convert.ToInt32(frames[j] - 48) == a[i])
                    {
                        flag1 = flag2 = 1;
                        break;
                    }
                }

                if (flag1 == 0)
                {
                    for (j = 0; j < okvir; ++j)
                    {
                        if (frames[j] == ' ')
                        {
                            faults++;
                            frames[j] = Convert.ToChar((int)a[i] + 48);
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

                        for (k = i + 1; k < tekstZaMenjanje.Length; ++k)
                        {
                            if (Convert.ToInt32(frames[j] - 48) == a[k])
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
                    frames[pos] = Convert.ToChar((int)a[i] + 48);
                    faults++;
                }

                for (j = 0; j < okvir; ++j)
                {
                    dataGridView1.Rows.Add(Convert.ToString(frames[j]));
                }
            }

            textBox1.Text = "Broj zvezdica : " + (tekstZaMenjanje.Length - faults);
        }
    }
}
