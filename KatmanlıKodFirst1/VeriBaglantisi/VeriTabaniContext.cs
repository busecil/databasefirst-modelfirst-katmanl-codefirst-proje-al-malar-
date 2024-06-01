using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Varliklar;

namespace VeriBaglantisi
{
    public class VeriTabaniContext:DbContext
    {
        DbSet<Ogrenci> Ogrenciler { get; set; }
    }
}
