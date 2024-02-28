using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Ogrenci
    {
        [Key]
        public int ID { get; set; }
        public string OGRENCINO { get; set; }
        public string ADI { get; set; }
        public string SOYADI { get; set; }
        public string TCNO { get; set; }

        public int BOLUMID { get; set; }
        public virtual BOLUM BOLUMs { get; set; }
        public int FAKULTEID { get; set; }
        public virtual FAKULTE FAKULTEs { get; set; }
        public int UNIVERSITEID { get; set; }
        public virtual UNIVERSITE UNIVERSITEs { get; set; }

        public int DANISMANID { get; set; }
        public virtual AKADEMIKPERSONEL AKADEMIKPERSONELs { get; set; }

        public ICollection<DERSHAREKET> DERSHAREKETs { get; set; }


    }
}
