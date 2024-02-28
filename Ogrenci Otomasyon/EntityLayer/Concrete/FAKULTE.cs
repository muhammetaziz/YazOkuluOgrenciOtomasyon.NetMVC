using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FAKULTE
    {
        [Key]
        public int ID { get; set; }
        public string ADI { get; set; }
        public ICollection<Ogrenci> Ogrencis { get; set; }
        public ICollection<DERS> DERSs { get; set; }
    }
}
