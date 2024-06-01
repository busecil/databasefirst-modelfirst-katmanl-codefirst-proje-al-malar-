using InterFaceler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar;
using VeriBaglantisi;

namespace Islemler
{
    public class OgrenciIslemleri : VtIslemlerİI<Ogrenci>
    {
        private OgrenciDAL ogrenciDAL;
        public OgrenciIslemleri()
        {
            if (ogrenciDAL == null)
            {
                ogrenciDAL = new OgrenciDAL();
            }
        }
        public void Ekle(Ogrenci kayit)
        {
            ogrenciDAL.Ekle(kayit);
        }

        public void Guncelle(Ogrenci kayit)
        {
            ogrenciDAL.Guncelle(kayit);
        }

        public void Sil(Ogrenci kayit)
        {
            ogrenciDAL.Sil(kayit);
        }

        public List<Ogrenci> sorgula(Func<Ogrenci, bool> filtre)
        {
            return ogrenciDAL.sorgula(filtre);
        }

        public List<Ogrenci> tamaminiGetir()
        {
            return ogrenciDAL.tamaminiGetir();
        }

        public Ogrenci tekilGetir(Func<Ogrenci, bool> filtre = null)
        {
            return ogrenciDAL.tekilGetir(filtre);
        }

        public Ogrenci tekilGetir(int ID)
        {
            return ogrenciDAL.tekilGetir(ID);
        }

        public void TopluEkle(List<Ogrenci> eklenecekListe)
        {
            ogrenciDAL.TopluEkle(eklenecekListe);
        }

        public void TopluSil(List<Ogrenci> silinecekListe)
        {
            ogrenciDAL.TopluSil(silinecekListe);
        }

        List<Ogrenci> VtIslemlerİI<Ogrenci>.tamaminiGetir()
        {
            throw new NotImplementedException();
        }
    }
}
