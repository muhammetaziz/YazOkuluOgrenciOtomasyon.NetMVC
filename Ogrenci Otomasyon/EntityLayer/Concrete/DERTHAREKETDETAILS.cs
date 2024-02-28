using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace EntityLayer.Concrete
{
    public class DERTHAREKETDETAILS
    {
        [Key]
        public int ID { get; set; }
        public int DERSID { get; set; }
        public virtual DERS DERSs { get; set; }
        public int PKID { get; set; }
        public virtual DERSHAREKET DERSHAREKETs { get; set; }
        public int STATE { get; set; }

    }
}
