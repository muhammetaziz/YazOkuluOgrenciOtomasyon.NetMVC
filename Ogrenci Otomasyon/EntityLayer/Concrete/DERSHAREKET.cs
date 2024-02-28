using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class DERSHAREKET
    {
        [Key]
        public int ID { get; set; }
        public DateTime INSERT_DATE { get; set; }
        public int DANISMANID { get; set; }
        public virtual AKADEMIKPERSONEL AKADEMIKPERSONELs { get; set; }
        public int OGRENCIID { get; set; }
        public virtual Ogrenci Ogrencis { get; set; }
        public int STATE { get; set; }
        public int UNIVERSITESTATE { get; set; }
        public string UNIVERSITEADI { get; set; }
        public int UNIVERSITEID { get; set; }

        public ICollection<DERTHAREKETDETAILS> DERTHAREKETDETAILSs { get; set; }
    }
}
