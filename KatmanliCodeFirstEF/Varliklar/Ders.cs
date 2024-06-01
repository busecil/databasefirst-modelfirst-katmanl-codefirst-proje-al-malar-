using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Varliklar
{
    [Table("Dersler")]
    public class Ders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(20)]
        [Required] 
        public string dersKodu { get; set; }

        [MaxLength(100)]
        [Required]
        public string dersAdi { get; set; }
        public int akts { get; set; }

        public Ders()
        {

        }

        public Ders(int ID, string dersKodu, string dersAdi, int akts)
        {
            this.ID = ID;
            this.dersKodu = dersKodu;
            this.dersAdi = dersAdi;
            this.akts = akts;
        }
    }
}

