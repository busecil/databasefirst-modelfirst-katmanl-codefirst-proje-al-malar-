using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ModelFirstEf
{
    public partial class KategoriYönetim : Form
    {
        public KategoriYönetim()
        {
            InitializeComponent();
        }
        VeriTabaniModelContainer vt = new VeriTabaniModelContainer();
        private void KategoriYönetim_Load(object sender, EventArgs e)
        {
            veriyukle();
        }

        private void veriyukle()
        {
            var sorgu = from k in vt.Kategoriler
                        select new
                        {
                            k.ID,
                            k.kategoriAdi,
                            k.aciklama
                        };
            dataGridView1.DataSource = sorgu.ToList();
            dataGridView1.Columns[0].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Boş Kayıt Eklenemez");
                return;
            }
            Kategori aktif = new Kategori();
            aktif.kategoriAdi = textBox1.Text;
            aktif.aciklama = textBox2.Text;
            vt.Kategoriler.Add(aktif);
            vt.SaveChanges();
            veriyukle();
            temizle();

        }

        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            label2.Text = "-1";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label2.Text != "-1")
            {
                int id;
                bool sonuc = int.TryParse(label2.Text, out id);
                if (sonuc)
                {
                    int kategoriyeBagliUrunSayisi = vt.Urunler.Where(u => u.Kategori.ID == id).Count();
                    if (kategoriyeBagliUrunSayisi > 0)
                    {
                        DialogResult cevap = MessageBox.Show($"Bu Kategoriye Bağlı{kategoriyeBagliUrunSayisi}kadar Ürün var, kategorinin silinmesi için bu kategoriye bağlı tüm ürünlerin silinmesi gerekiyor. Silme işlemini devam ettirmek istiyor musunuz?", "Emin misiniz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (cevap != DialogResult.Yes)
                        {
                            List<Urun> silinecekUrunler = vt.Urunler.Where(u => u.Kategori.ID == id).ToList();
                            foreach (Urun urun in silinecekUrunler)
                            {
                                vt.Urunler.Remove(urun);
                            }
                            vt.SaveChanges();
                            Kategori silinecekKategori = vt.Kategoriler.Find(id);
                            vt.Kategoriler.Remove(silinecekKategori);
                            vt.SaveChanges();
                            veriyukle();
                            temizle();

                        }
                        return;

                    }
                    else
                    {
                        Kategori silinecekKategori = vt.Kategoriler.Find(id);
                        vt.Kategoriler.Remove(silinecekKategori);
                        vt.SaveChanges();
                        veriyukle();
                        temizle();
                    }
                }
                else
                {
                    MessageBox.Show("Silme işlemi gerçekleşmedi");
                }

            }
            else
            {
                MessageBox.Show("Önce Silinecek kaydı seçiniz");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label2.Text != "-1")
            {
                int id;
                bool sonuc = int.TryParse(label2.Text, out id);
                if (sonuc)
                {
                    Kategori aktif = vt.Kategoriler.Find(id);
                    aktif.kategoriAdi = textBox1.Text;
                    aktif.aciklama = textBox2.Text;

                    vt.SaveChanges();
                    veriyukle();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Güncelleme işlemi gerçekleşmedi");
                }

            }
            else
            {
                MessageBox.Show("Önce Güncellenecek kaydı seçiniz");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    


