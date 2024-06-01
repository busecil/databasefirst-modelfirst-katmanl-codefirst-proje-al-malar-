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
    public class DersDAL : VtIslemlerİI<Ders>
    {
        public void Ekle(Ders kayit)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Added;
                vt.SaveChanges();
            }
        }

        public void Guncelle(Ders kayit)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Modified;
                vt.SaveChanges();
            }
        }

        public void Sil(Ders kayit)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Deleted;
                vt.SaveChanges();
            }
        }

        public List<Ders> sorgula(Func<Ders, bool> filtre)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return filtre == null ? vt.Set<Ders>().ToList() : vt.Set<Ders>().Where(filtre).ToList();
            }
        }

        public List<Ders> tamaminiGetir()
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<Ders>().ToList();
            }
        }

        public Ders tekilGetir(Func<Ders, bool> filtre = null)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<Ders>().SingleOrDefault(filtre);
            }
        }

        public Ders tekilGetir(int ID)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<Ders>().SingleOrDefault(o => o.ID == ID);
            }
        }

        public void TopluEkle(List<Ders> eklenecekListe)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                foreach (Ders Eleman in eklenecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Added;
                }

                vt.SaveChanges();
            }
        }

        public void TopluSil(List<Ders> silinecekListe)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                foreach (Ders Eleman in silinecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Deleted;
                }

                vt.SaveChanges();
            }
        }
    }
}
