using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varliklar
{
    [Table("OgrenciDersler")]
    public class OgrenciDers
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Ogrenci))]
        public int OgrenciID { get; set;}
        [ForeignKey(nameof(Ders))]
        public int DersID { get; set;}
        public virtual Ogrenci Ogrenci { get; set;}
        public virtual Ders Ders { get; set; }

        public OgrenciDers()
        {
        }

        public OgrenciDers(int ID, int ogrenciID, int dersID, Ogrenci ogrenci, Ders ders)
        {
            this.ID = ID;
            OgrenciID = ogrenciID;
            DersID = dersID;
            Ogrenci = ogrenci;
            Ders = ders;
        }
    }
}
