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
    public partial class OgrenciDersFormucs : Form
    {
        DersIslemleri _dIslem;
        OgrenciIslemleri _oIslem;
        OgrenciDersIslemleri _odIslem;
        public OgrenciDersFormucs()
        {
            _dIslem = new DersIslemleri();
            _oIslem = new OgrenciIslemleri();
            _odIslem = new OgrenciDersIslemleri(); 


            InitializeComponent();
        }

        private void OgrenciDersFormucs_Load(object sender, EventArgs e)
        {
            ogrenciYukle();
            dersYukle();
            ogrenciDersYukle();


        }

        private void ogrenciDersYukle()
        {
            dataGridView2.DataSource = _odIslem.tamaminiGetir().Select(od=> new)
                
                
            }
        }

        private void ogrenciYukle()
        {
            dataGridView4.DataSource = _oIslem.tamaminiGetir().Select(o => new
            {
                o.ID,
                o.OgrenciNo,
                o.KimlikNo,
                o.Ad,
                o.Soyad,

            }).ToList();
            dataGridView4.Columns[0].Visible = false;
        }

        private void dersYukle()
        {
            dataGridView4.DataSource = _dIslem.tamaminiGetir().Select(d => new
            {
                d.ID,
                d.dersKodu,
                d.dersAdi
            }).ToList();
            dataGridView4.Columns[0].Visible = false;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
