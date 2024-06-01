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

namespace ArayuzUI
{
    public partial class OgrenciDersFormu : Form
    {
        DersIslemleri _dIslem;
        OgrenciIslemleri _oIslem;
        OgrenciDersIslemleri _odIslem;
        public OgrenciDersFormu()
        {
            _dIslem = new DersIslemleri();
            _oIslem = new OgrenciIslemleri();
            _odIslem = new OgrenciDersIslemleri();
        }

        private void OgrenciDersFormu_Load(object sender, EventArgs e)
        {
            ogrenciYukle();
            dersYukle();
            ogrenciDersYukle();
        }

        private void ogrenciDersYukle()
        {
            dataGridView3.DataSource = _odIslem.tamaminiGetir().Select(od => new
            {
                od.ID,
               DERSID=od.Ders.ID,
               OGRID=od.Ogrenci.ID,
               od.Ogrenci.OgrenciNo,
               od.Ogrenci.KimlikNo,
               od.Ogrenci.Ad,
               od.Ogrenci.Soyad,
               od.Ders.dersKodu,
               od.Ders.dersAdi
            }).ToList();
            for(int i = 0;i<3;i++)
            {
                dataGridView2.Columns[i].Visible = false;
            }
           
        }
    

        private void dersYukle()
        {
            dataGridView2.DataSource = _dIslem.tamaminiGetir().Select(d => new
            {
                d.ID,
                d.dersKodu,
                d.dersAdi,
            }).ToList();
            dataGridView2.Columns[0].Visible = false;
        }
    

        private void ogrenciYukle()
        {
            dataGridView1.DataSource = _oIslem.tamaminiGetir().Select(o=>new
            {
              o.ID,
              o.OgrenciNo,
              o.KimlikNo,
              o.Ad,
              o.Soyad
            }).ToList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _oIslem.tamaminiGetir().Select(o => new
            {
                o.ID,
                o.OgrenciNo,
                o.KimlikNo,
                o.Ad,
                o.Soyad
            }).Where(o => o.KimlikNo.Contains(textBox1.Text || o.OgrenciNo.Contains(textBox1.Text).Tolist();
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
