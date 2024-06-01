using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ModelFirstEf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        VeriTabaniModelContainer vt = new VeriTabaniModelContainer();
        private void Form1_Load(object sender, EventArgs e)
        {
            veriYukle();
        }

        private void veriYukle()
        {
            comboBox1.DataSource = vt.Kategoriler.ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "kategoriAdi";
            var sorgu = from u in vt.Urunler
                        select new
                        {
                            urunID = u.ID,
                            u.urunAdi,
                            u.birimFiyat,
                            u.stokMiktar,
                            u.Kategori.kategoriAdi,
                            u.Kategori.ID
                        };
            dataGridView1.DataSource = sorgu.ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || numericUpDown1.Value == 0 || numericUpDown2.Value == 0 || comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Boş Kayıt Eklenemez");
                return;
            }
            Urun aktif = new Urun();
            aktif.urunAdi = textBox1.Text;
            aktif.birimFiyat = numericUpDown1.Value;
            aktif.stokMiktar = Convert.ToInt32(numericUpDown2.Value);
            Kategori eklenecekKategori = vt.Kategoriler.Find(comboBox1.SelectedValue);
            aktif.Kategori = eklenecekKategori;
            vt.Urunler.Add(aktif);
            vt.SaveChanges();
            veriYukle();
            temizle();

        }

        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            comboBox1.SelectedIndex = -1;
            label2.Text = "-1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label2.Text != "-1")
            {
                int id;
                bool sonuc = int.TryParse(label2.Text, out id);
                if (sonuc)
                {
                    Urun aktif = vt.Urunler.Find(id);
                    vt.Urunler.Remove(aktif);
                    vt.SaveChanges();
                    veriYukle();
                    temizle();
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
            if (label2.Text != "-1" && comboBox1.SelectedIndex > -1)
            {
                int id;
                bool sonuc = int.TryParse(label2.Text, out id);
                if (sonuc)
                {
                    Urun aktif = vt.Urunler.Find(id);
                    aktif.urunAdi = textBox1.Text;
                    aktif.birimFiyat = numericUpDown1.Value;
                    aktif.stokMiktar = (int)(numericUpDown2.Value);
                    Kategori arananKategori = vt.Kategoriler.Find(comboBox1.SelectedValue);
                    aktif.Kategori = arananKategori;
                    vt.SaveChanges();
                    veriYukle();
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
            if (textBox2.Text.Length > 0)
            {
                var sorgu = from u in vt.Urunler
                            where u.urunAdi.ToLower().Contains(textBox2.Text.ToLower()) ||
                            u.Kategori.kategoriAdi.ToLower().Contains(textBox2.Text.ToLower())
                            select new
                            {
                                urunID = u.ID,
                                urunAdi = u.urunAdi,
                                u.birimFiyat,
                                u.stokMiktar,
                                u.Kategori.kategoriAdi,
                                KategoriID = u.Kategori.ID
                            };
                dataGridView1.DataSource = sorgu.ToList();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
            else
            {
                veriYukle();
            }
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
            numericUpDown1.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[2].Value);
            numericUpDown2.Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
            comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                temizle();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KategoriYönetim ky = new KategoriYönetim();
            ky.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            veriYukle();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
