using InterFaceler;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar;

namespace VeriBaglantisi
{
    public class OgrenciDersDAL : VtIslemlerİI<OgrenciDers>
    {
        public void Ekle(OgrenciDers kayit)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Added;
                vt.SaveChanges();
            }
        }

        public void Guncelle(OgrenciDers kayit)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Modified;
                vt.SaveChanges();
            }
        }

        public void Sil(OgrenciDers kayit)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Deleted;
                vt.SaveChanges();
            }
        }

        public List<OgrenciDers> sorgula(Func<OgrenciDers, bool> filtre)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return filtre == null ? vt.Set<OgrenciDers>().ToList() : vt.Set<OgrenciDers>().Where(filtre).ToList();
            }
        }

        public List<OgrenciDers> tamaminiGetir()
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<OgrenciDers>().ToList();
            }
        }

        public OgrenciDers tekilGetir(Func<OgrenciDers, bool> filtre = null)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<OgrenciDers>().SingleOrDefault(filtre);
            }
        }

        public OgrenciDers tekilGetir(int ID)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<OgrenciDers>().SingleOrDefault(o => o.ID == ID);
            }
        }

        public void TopluEkle(List<OgrenciDers> eklenecekListe)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                foreach (OgrenciDers Eleman in eklenecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Added;
                }

                vt.SaveChanges();
            }
        }

        public void TopluSil(List<OgrenciDers> silinecekListe)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                foreach (OgrenciDers Eleman in silinecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Deleted;
                }

                vt.SaveChanges();
            }
        }
    }
}
