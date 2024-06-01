using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varliklar
{
    [Table("Ogrenciler")]
    public class Ogrenci
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(11)]
        public string KimlikNo { get; set; }
        [MaxLength(11)]
        public string OgrenciNo { get; set; }
        [MaxLength(50)]
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public byte[] Resim { get; set; }
        public short Yas { get { return yasHesapla(); } }
        private short yasHesapla()
        {
            DateTime dtar = DogumTarihi;
            DateTime bugun = DateTime.Today;
            int yas = bugun.Year - dtar.Year;
            if (dtar > bugun.AddYears(-yas))
            {
                yas--;
            }
            return (short)(yas);
        }
        public Ogrenci()
        {

        }

        public Ogrenci(int ıD, string kimlikNo, string ogrenciNo, string ad, string soyad, DateTime dogumTarihi, byte[] resim)
        {
            ID = ıD;
            KimlikNo = kimlikNo;
            OgrenciNo = ogrenciNo;
            Ad = ad;
            Soyad = soyad;
            DogumTarihi = dogumTarihi;
            Resim = resim;
        }

        public string Kisalt(string uzunMetin)
        {
            string kisaMetin = uzunMetin.Substring(0, 2);
            for (int i = 2; i < uzunMetin.Length; i++)
            {
                kisaMetin += "*";
            }
            return kisaMetin;
            //Abdurrahman
            //Ab*****
        }

        public byte[] ResimToByteDizi(Image gelenResim)
        {
            using (var ms = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(gelenResim);
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public Image ByteDiziToResim(byte[] gelenByteDizi)
        {
            using (var ms = new MemoryStream(gelenByteDizi))
            {
                return Image.FromStream(ms);
            }

        }
    }
}





