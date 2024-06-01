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
    public class DersIslemleri : VtIslemlerİI<Ders>
    {
        private DersDAL DersDAL;
        public DersIslemleri()
        {
            if (DersDAL == null)
            {
                DersDAL = new DersDAL();
            }
        }
        public void Ekle(Ders kayit)
        {
           DersDAL.Ekle(kayit);
        }

        public void Guncelle(Ders kayit)
        {
            DersDAL.Guncelle(kayit);
        }

        public void Sil(Ders kayit)
        {
            DersDAL.Sil(kayit);
        }

        public List<Ders> sorgula(Func<Ders, bool> filtre)
        {
            return DersDAL.sorgula(filtre);
        }

        public List<Ders> tamaminiGetir()
        {
            return DersDAL.tamaminiGetir();
        }

        public Ders tekilGetir(Func<Ders, bool> filtre = null)
        {
            return DersDAL.tekilGetir(filtre);
        }

        public Ders tekilGetir(int ID)
        {
            return DersDAL.tekilGetir(ID);
        }

        public void TopluEkle(List<Ders> eklenecekListe)
        {
            DersDAL.TopluEkle(eklenecekListe);
        }

        public void TopluSil(List<Ders> silinecekListe)
        {
            DersDAL.TopluSil(silinecekListe);
        }
    }
}
