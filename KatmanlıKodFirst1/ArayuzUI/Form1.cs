using islemler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Varliklar;

namespace ArayuzUI
{
    public partial class Form1 : Form
    {
        private ogrenciIslemleri oi;
        private List<Ogrenci> al;
        public Form1()
        {
            if (al == null) al = new List<Ogrenci>();
            if (oi == null) oi = new ogrenciIslemleri();
            InitializeComponent();
        }
        private void yukle()
        {
            al = oi.tamaminiGetir().OrderBy(p => p.ID).ToList();
            dataGridView1.DataSource = al;
            dataGridView1.Columns[0].Visible = false;
            resimSutunuAyarla();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            yukle();
        }

        void arayuzListesiYildizla(List<Ogrenci> liste)
        {
            foreach (var ogrenci in liste)
            {
                ogrenci.KimlikNo = ogrenci.Kisalt(ogrenci.KimlikNo);
                ogrenci.OgrenciNo = ogrenci.Kisalt(ogrenci.OgrenciNo);
                ogrenci.Ad = ogrenci.Kisalt(ogrenci.Ad);
                ogrenci.Soyad = ogrenci.Kisalt(ogrenci.Soyad);
            }

        }
        void resimSutunuAyarla()
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            DataGridViewImageColumn rs = new DataGridViewImageColumn();
            rs.Width = 200;
            rs.HeaderText = "Resim";
            rs.DataPropertyName = "resim";
            rs.ImageLayout = DataGridViewImageCellLayout.Stretch;
            rs.ReadOnly = true;
            dataGridView1.Columns.Insert(6, rs);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ogrenci o = new Ogrenci();
            o.KimlikNo = textBox1.Text;
            o.OgrenciNo = textBox2.Text;
            o.Ad = textBox3.Text;
            o.Soyad = textBox4.Text;
            o.DogumTarihi = dateTimePicker1.Value;
            o.Resim = o.ResimToByteDizi(pictureBox1.Image);
            al.Add(o);
            oi.Ekle(o);
            arayuzdenVeriYukle();
            temizle();
        }

        private void temizle()
        {
            label2.Text = "-1";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dateTimePicker1.Value = DateTime.Now;
            pictureBox1.Image = null;
            numericUpDown1.Value = 0;

        }

        void arayuzdenVeriYukle()
        {
            dataGridView1.DataSource = null;
            arayuzListesiYildizla(al);
            dataGridView1.DataSource = al;
            resimSutunuAyarla();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Today >= dateTimePicker1.Value)
            {
                numericUpDown1.Value = yasHesapla(dateTimePicker1.Value);
            }
        }

        private decimal yasHesapla(DateTime tarih)
        {
            DateTime dtar = tarih;
            DateTime bugun = DateTime.Today;
            int yas = bugun.Year - dtar.Year;
            if (dtar > bugun.AddYears(-yas))
            {
                yas--;
            }
            return (sbyte)yas;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            parcalaraAyir();
        }

        private void parcalaraAyir()
        {
            if (dataGridView1.CurrentRow.Index > -1)
            {
                Ogrenci o = oi.tekilGetir(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                label2.Text = o.ID.ToString();
                textBox1.Text = o.KimlikNo;
                textBox2.Text = o.OgrenciNo;
                textBox3.Text = o.Ad;
                textBox4.Text = o.Soyad;
                dateTimePicker1.Value = o.DogumTarihi;
                pictureBox1.Image = o.ByteDiziToResim(o.Resim);
                numericUpDown1.Value = yasHesapla(o.DogumTarihi);
            }
            else
            {
                MessageBox.Show("Kayıt seçiniz");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(label2.Text != "-1" && (textBox1.Text.IndexOf("") == -1 || textBox2.Text.IndexOf("") == -1 || textBox3.Text.IndexOf("") == -1 || textBox4.Text.IndexOf("") == -1))
{
                Ogrenci go = al.Where(o => o.ID == Convert.ToInt32(label2.Text)).FirstOrDefault();
                if (go != null)
                {
                    go.KimlikNo = textBox1.Text;
                    go.OgrenciNo = textBox2.Text;
                    go.Ad = textBox3.Text;
                    go.Soyad = textBox4.Text;
                    go.DogumTarihi = dateTimePicker1.Value;
                    go.Resim = go.ResimToByteDizi(pictureBox1.Image);
                    oi.Ekle(go);
                    al.Add(go);
                    arayuzdenVeriYukle();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Öğrenci Bulunamadığından Güncellenemedi");
                }
            }
else
            {
                MessageBox.Show("Veriler Hatalı Formatta OLduğundan Güncellenemedi");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label2.Text != "-1")
            {
                Ogrenci so = al.Where(o => o.ID == Convert.ToInt32(label2.Text)).FirstOrDefault();
                if (so != null)
                {
                    oi.Sil(so);
                    al.Remove(so);
                    arayuzdenVeriYukle();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Öğrenci Bulunamadığından Silinemedi");
                }
            }
            else
            {

                MessageBox.Show("Önce Silinecek Kaydı Seçiniz");

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0)
            {
                yukle();
            }
            else
            {
                List<Ogrenci> gl = oi.sorgula(o => o.KimlikNo.Contains(textBox5.Text) || o.OgrenciNo.Contains(textBox5.Text) || o.Ad.ToLower().Contains(textBox5.Text.ToLower()) || o.Soyad.ToLower().Contains(textBox5.Text.ToLower()));
                arayuzListesiYildizla(gl);
                dataGridView1.DataSource = gl;
            }
        }
    }
}
       
    

