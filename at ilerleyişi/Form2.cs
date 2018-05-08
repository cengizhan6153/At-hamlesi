using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace at_ilerleyişi
{
    public partial class Form2 : Form
    {
        public Form1 f;
        int puan = 1;
        int boyut;
        public Form2(Form1 f1, int a)
        {
            this.boyut = a;
            this.f = f1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            f.Show();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Data_Olustur(boyut);
        }
        public void Data_Olustur(int b)
        {
            dataGridView1.ColumnCount = b;
            dataGridView1.RowCount = b;
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "o";
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a, b;
            a = e.ColumnIndex;
            b = e.RowIndex;
            if (dataGridView1.Rows[b].Cells[a].Value.ToString() == "o")
                Ilerle(b, a);
        }
        public void Ilerle(int row, int cell)
        {
            bool b = false;
            label1.Text = puan.ToString();
            skorKontrolo(puan);
            dataGridView1.Rows[row].Cells[cell].Value = puan++;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString() == "x" || dataGridView1.Rows[i].Cells[j].Value.ToString() == "o")
                    {
                        if (i == row - 1 && j == cell - 2)
                        { dataGridView1.Rows[i].Cells[j].Value = "o"; b = true; continue; }
                        if (i == row - 1 && j == cell + 2)
                        { dataGridView1.Rows[i].Cells[j].Value = "o"; b = true; continue; }
                        if (i == row + 1 && j == cell - 2)
                        { dataGridView1.Rows[i].Cells[j].Value = "o"; b = true; continue; }
                        if (i == row + 1 && j == cell + 2)
                        { dataGridView1.Rows[i].Cells[j].Value = "o"; b = true; continue; }
                        if (i == row - 2 && j == cell - 1)
                        { dataGridView1.Rows[i].Cells[j].Value = "o"; b = true; continue; }
                        if (i == row - 2 && j == cell + 1)
                        { dataGridView1.Rows[i].Cells[j].Value = "o"; b = true; continue; }
                        if (i == row + 2 && j == cell - 1)
                        { dataGridView1.Rows[i].Cells[j].Value = "o"; b = true; continue; }
                        if (i == row + 2 && j == cell + 1)
                        { dataGridView1.Rows[i].Cells[j].Value = "o"; b = true; continue; }
                        dataGridView1.Rows[i].Cells[j].Value = "x";
                    }
                }
            }
            yolKontrolu(b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void skorKontrolo(int i)
        {
            if (i == boyut * boyut)
            {
                MessageBox.Show(":D KAZANDİNİZ :D");
            }
        }
        public void yolKontrolu(bool b)
        {
            if(!b && puan-1 != boyut*boyut)
                MessageBox.Show(":( KAYBETTİNİZ :(");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Data_Olustur(boyut);
            puan = 1;
            label1.Text = "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Oyunu tamamlayabilek için 'L' şeklinde ilerleyrek tüm kutucuklardan geçmen gerekmektedir.İyi eğlenceler :D");
        }
    }
}
