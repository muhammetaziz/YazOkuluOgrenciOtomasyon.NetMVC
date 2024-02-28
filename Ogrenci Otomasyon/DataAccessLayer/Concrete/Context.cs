using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Ogrenci> Ogrencis { get; set; }
        public DbSet<AKADEMIKPERSONEL> Akademısyens { get; set; }
        public DbSet<FAKULTE> Fakultes { get; set; }
        public DbSet<BOLUM> Bolums { get; set; }
        public DbSet<UNIVERSITE> Unıversıtes { get; set; }
        public DbSet<DANISMANISLEMLER> Danısmanıslemlers { get; set; }
        public DbSet<LOGINUSER> Logınusers { get; set; }
        public DbSet<DERSHAREKET> Dersharekets { get; set; }
        public DbSet<DERS> Derss { get; set; }
        public DbSet<DERTHAREKETDETAILS> DertHareketDetailss { get; set; }
    }
}
