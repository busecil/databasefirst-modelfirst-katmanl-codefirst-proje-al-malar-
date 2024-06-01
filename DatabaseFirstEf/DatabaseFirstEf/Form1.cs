using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseFirstEf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NorthwindVarliklar veriTabani = new NorthwindVarliklar();
        List<Nakliyeci> Nakliyeciler;
        private void Form1_Load(object sender, EventArgs e)
        {
            Nakliyeciler = veriTabani.Nakliyeciler.ToList();
            dataGridView1.DataSource = Nakliyeciler;
            dataGridView1.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ekleme işlemi
            if (textBox1.Text == "" || maskedTextBox1.Text == "")
            {
                MessageBox.Show("Boş kayıt eklenemez");
                return;
            }
            Nakliyeci ekleneceknakliyeci = new Nakliyeci();
            ekleneceknakliyeci.SirketAdi = textBox1.Text;
            ekleneceknakliyeci.Telefon = maskedTextBox1.Text;
            Nakliyeciler.Add(ekleneceknakliyeci);
            veriTabani.Nakliyeciler.Add(ekleneceknakliyeci);
            veriTabani.SaveChangesAsync();
            veriYukle();
            temizle();
        }

        private void temizle()
        {
            label2.Text = "-1";
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
        }

        private void veriYukle()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Nakliyeciler;
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > -1)
            {
                parcala();
            }
        }

        private void parcala()
        {
            label2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label2.Text == "-1")
            {
                MessageBox.Show("Önce silinecek Kaydı seçiniz");
                return;
            }
            int ID;
            bool sonuc = int.TryParse(label2.Text, out ID);
            if (sonuc)
            {
                Nakliyeci sN = veriTabani.Nakliyeciler.Find(ID);
                veriTabani.Nakliyeciler.Remove(sN);
                Nakliyeciler.Remove(sN);
                veriTabani.SaveChangesAsync();
                veriYukle();
                temizle();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                dataGridView1.DataSource = Nakliyeciler.Where(n => n.SirketAdi.ToLower().Contains(textBox2.Text.ToLower()) || n.Telefon.Contains(textBox2.Text)).ToList();
            }
            else
            {
                veriYukle();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label2.Text == "-1")
            {
                MessageBox.Show("Önce güncellenecek Kaydı seçiniz");
                return;
            }
            int ID;
            bool sonuc = int.TryParse(label2.Text, out ID);
            if (sonuc)
            {
                Nakliyeci gN = veriTabani.Nakliyeciler.Find(ID);
                gN.SirketAdi = textBox1.Text;
                gN.Telefon = maskedTextBox1.Text;
                veriTabani.Nakliyeciler.Remove(gN);
                veriTabani.SaveChangesAsync();
                veriYukle();
                temizle();
            }
            else
            {
                MessageBox.Show("güncellenemedi");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                temizle();
            }

        }
    }
}
