using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class DERS
    {
        public int ID { get; set; }
        public string ADI { get; set; }
        public int KREDI { get; set; }
        public int AKTS { get; set; }
        public int BOLUMID { get; set; }
        
        public int FAKULTEID { get; set; }
        public virtual FAKULTE FAKULTEs { get; set; }
        public int AKADEMIKPERSONELID { get; set; }
        public virtual AKADEMIKPERSONEL AKADEMIKPERSONELs { get; set; }

        public ICollection<DERTHAREKETDETAILS> DERTHAREKETDETAILSs { get; set; }
    }
}
