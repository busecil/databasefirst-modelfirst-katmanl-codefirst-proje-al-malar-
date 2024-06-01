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
    public class OgrenciDersIslemleri : VtIslemlerİI<OgrenciDers>
    {
        private OgrenciDersDAL OgrenciDersDAL;
        public OgrenciDersIslemleri()
        {
            if (OgrenciDersDAL == null)
            {
                OgrenciDersDAL = new OgrenciDersDAL();
            }
        }
        public void Ekle(OgrenciDers kayit)
        {
           OgrenciDersDAL.Ekle(kayit);
        }


        public void Guncelle(OgrenciDers kayit)
        {
            OgrenciDersDAL.Guncelle(kayit);
        }

        public void Sil(OgrenciDers kayit)
        {
            OgrenciDersDAL.Sil(kayit);
        }

       

        public List<OgrenciDers> sorgula(Func<OgrenciDers, bool> filtre)
        {
            return OgrenciDersDAL.sorgula(filtre);
        }

       

        public List<OgrenciDers> tamaminiGetir()
        {
            return OgrenciDersDAL.tamaminiGetir();
        }

        public OgrenciDers tekilGetir(Func<OgrenciDers, bool> filtre = null)
        {
            return OgrenciDersDAL.tekilGetir(filtre);
        }

        public OgrenciDers tekilGetir(int ID)
        {
            return OgrenciDersDAL.tekilGetir(ID);
        }


        public void TopluEkle(List<OgrenciDers> eklenecekListe)
        {
            OgrenciDersDAL.TopluEkle(eklenecekListe);
        }

        

        public void TopluSil(List<OgrenciDers> silinecekListe)
        {
            OgrenciDersDAL.TopluSil(silinecekListe);
        }

       
        List<OgrenciDers> VtIslemlerİI<OgrenciDers>.tamaminiGetir()
        {
            throw new NotImplementedException();
        }

        OgrenciDers VtIslemlerİI<OgrenciDers>.tekilGetir(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
