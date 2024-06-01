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
    public class OgrenciDAL : VtIslemlerİI<Ogrenci>
    {
        public void Ekle(Ogrenci kayit)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Added;
                vt.SaveChanges();
            }
        }

        public void Guncelle(Ogrenci kayit)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Modified;
                vt.SaveChanges();
            }
        }

        public void Sil(Ogrenci kayit)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                vt.Entry(kayit).State = EntityState.Deleted;
                vt.SaveChanges();
            }
        }

        public List<Ogrenci> sorgula(Func<Ogrenci, bool> filtre)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return filtre == null ? vt.Set<Ogrenci>().ToList() : vt.Set<Ogrenci>().Where(filtre).ToList();
            }
        }

        public List<Ogrenci> tamaminiGetir()
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<Ogrenci>().ToList();
            }
        }

        public Ogrenci tekilGetir(Func<Ogrenci, bool> filtre = null)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<Ogrenci>().SingleOrDefault(filtre);
            }
        }

        public Ogrenci tekilGetir(int ID)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                return vt.Set<Ogrenci>().SingleOrDefault(o => o.ID == ID);
            }
        }

        public void TopluEkle(List<Ogrenci> eklenecekListe)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                foreach (Ogrenci Eleman in eklenecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Added;
                }

                vt.SaveChanges();
            }
        }

        public void TopluSil(List<Ogrenci> silinecekListe)
        {
            using (VeriTabaniContext vt = new VeriTabaniContext())
            {
                foreach (Ogrenci Eleman in silinecekListe)
                {
                    vt.Entry(Eleman).State = EntityState.Deleted;
                }

                vt.SaveChanges();
            }
        }
    }
}
