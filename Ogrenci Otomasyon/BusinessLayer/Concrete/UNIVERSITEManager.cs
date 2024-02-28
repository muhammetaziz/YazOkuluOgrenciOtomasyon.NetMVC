using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
   public class UNIVERSITEManager
    {
        private Repository<UNIVERSITE> repotable = new Repository<UNIVERSITE>();

        public List<UNIVERSITE> GetAll()
        {
            return repotable.List();
        }

        public int AddUNIVERSITE(UNIVERSITE p)
        {
            return repotable.Insert(p);
        }

        public int EditUNIVERSITE(UNIVERSITE p)
        {
            UNIVERSITE tbl = repotable.Find(x => x.ID == p.ID);
            tbl.ADI = p.ADI;
            
            return repotable.Update(tbl);
        }

        public int DeleteUNIVERSITE(int id)
        {
            UNIVERSITE tbl = repotable.Find(x => x.ID == id);
            return repotable.Delete(tbl);
        }

        public UNIVERSITE FindUNIVERSITE(int id)
        {
            return repotable.Find(x => x.ID == id);
        }
    }
}
