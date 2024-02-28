using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AKADEMIKPERSONEL
    {
        [Key]
        public int ID { get; set; }
        public string SICILNO { get; set; }
        public string ADI { get; set; }
        public string SOYADI { get; set; }
        public string UNVAN { get; set; }
        public string FOTOGRAFYOL { get; set; }
        public int BOLUMID { get; set; }
        public virtual BOLUM BOLUMs { get; set; }
        public ICollection<Ogrenci> Ogrencis { get; set; }
        public ICollection<DERSHAREKET> DERSHAREKETs { get; set; }
        public ICollection<DERS> DERSs { get; set; }

    }
}
