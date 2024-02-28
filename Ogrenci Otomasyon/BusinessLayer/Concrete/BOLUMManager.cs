using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
   public class BOLUMManager
    {
        private Repository<BOLUM> repotable = new Repository<BOLUM>();

        public List<BOLUM> GetAll()
        {
            return repotable.List();
        }

        public int AddBOLUM(BOLUM p)
        {
            return repotable.Insert(p);
        }

        public int EditBOLUM(BOLUM p)
        {
            BOLUM tbl = repotable.Find(x => x.ID == p.ID);
            tbl.ADI = p.ADI;

            return repotable.Update(tbl);
        }

        public int DeleteBOLUM(int id)
        {
            BOLUM tbl = repotable.Find(x => x.ID == id);
            return repotable.Delete(tbl);
        }

        public BOLUM FindBOLUM(int id)
        {
            return repotable.Find(x => x.ID == id);
        }
    }
}
