using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaceler
{
    public interface VtIslemlerI<T>
    {
        void Ekle(T kayit);
        void Sil(T kayit);
        void Guncelle(T kayit);
        T TekilGetir(Func<T, bool> filtre = null);
        T TekilGetir(int ID);
        List<T> TamaminiGetir();
        List<T> Sorgula(Func<T, bool> filtre);
        void ToluEkle(List<T> eklenecekListe);
        void TopluSil(List<T> silinecekListe);

    }
}
