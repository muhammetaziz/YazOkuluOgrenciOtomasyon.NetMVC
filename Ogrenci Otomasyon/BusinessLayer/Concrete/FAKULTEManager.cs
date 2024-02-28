using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
   public class FAKULTEManager
    {
        private Repository<FAKULTE> repotable = new Repository<FAKULTE>();

        public List<FAKULTE> GetAll()
        {
            return repotable.List();
        }

        public int AddFAKULTE(FAKULTE p)
        {
            return repotable.Insert(p);
        }

        public int EditFAKULTE(FAKULTE p)
        {
            FAKULTE tbl = repotable.Find(x => x.ID == p.ID);
            tbl.ADI = p.ADI;

            return repotable.Update(tbl);
        }

        public int DeleteFAKULTE(int id)
        {
            FAKULTE tbl = repotable.Find(x => x.ID == id);
            return repotable.Delete(tbl);
        }

        public FAKULTE FindFAKULTE(int id)
        {
            return repotable.Find(x => x.ID == id);
        }
    }
}
