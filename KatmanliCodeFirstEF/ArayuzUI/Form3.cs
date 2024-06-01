using Islemler;
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
    public partial class Form3 : Form
    {
        private DersIslemleri _dersIslemleri;
        private List<Ders> arayuzListesi;
        public Form3()
        {
            _dersIslemleri =new DersIslemleri();
            arayuzListesi = new List<Ders>();
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            yukle();
        }

        private void yukle()
        {
            arayuzListesi=_dersIslemleri.tamaminiGetir().OrderByDescending(d => d.ID).ToList();
            dataGridView1.DataSource = arayuzListesi;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Ders Kodu";
            dataGridView1.Columns[2].HeaderText = "Ders Adı";
            dataGridView1.Columns[3].HeaderText = "Akts";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control &&  e.KeyCode == Keys.Insert) 
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    Ders d = new Ders();
                    d.ID = -1;
                    d.dersKodu = "-1";
                    d.dersAdi = "-1";
                    d.akts = -1;
                    _dersIslemleri.Ekle(d);
                    yukle();

                }
                else if (dataGridView1.Rows[0].Cells[1].Value.ToString()!="-1"&& dataGridView1.Rows[0].Cells[2].Value.ToString() != "-1" && dataGridView1.Rows[0].Cells[3].Value.ToString() != "-1" )
                {

                    Ders d = new Ders();
                    d.ID = -1;
                    d.dersKodu = "-1";
                    d.dersAdi = "-1";
                    d.akts = -1;
                    _dersIslemleri.Ekle(d);
                    yukle();

                }
            }
            else if((e.Control && e.KeyCode == Keys.Delete)&&dataGridView1.SelectedRows.Count>0)
            {
                for(int i = 0; i < dataGridView1.SelectedRows.Count;i++)
                {
                    Ders sd = _dersIslemleri.tekilGetir(d => d.ID == Convert.ToInt32(dataGridView1.SelectedRows[i].Cells[0].Value));
                    _dersIslemleri.Sil(sd);
                }
                yukle() ;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell.RowIndex>-1)
            {
                Ders gd = _dersIslemleri.tekilGetir(d => d.ID == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                gd.dersKodu = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                gd.dersAdi = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                gd.akts = Convert.ToInt16(dataGridView1.CurrentRow.Cells[3].Value);
                _dersIslemleri.Guncelle(gd);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                yukle();
            }
            else
            {
                List<Ders> geciciListe = new List<Ders>();
                geciciListe =_dersIslemleri.sorgula(d=>d.dersKodu.ToUpper().Contains(textBox1.Text.ToUpper())|| d.dersAdi.ToUpper().Contains(textBox1.Text.ToUpper()));
                dataGridView1.DataSource = geciciListe;
            }
        }
    }
}
