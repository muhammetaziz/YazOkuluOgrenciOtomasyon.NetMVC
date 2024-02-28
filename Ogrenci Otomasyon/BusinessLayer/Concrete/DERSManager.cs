using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DERSManager
    {
        private Repository<DERS> repotable = new Repository<DERS>();

        public List<DERS> GetAll()
        {
            return repotable.List();
        }

        public int AddDers(DERS p)
        {
            return repotable.Insert(p);
        }

        public int EditDers(DERS p)
        {
            DERS tbl = repotable.Find(x => x.ID == p.ID);
            tbl.ADI = p.ADI;
            tbl.AKTS = p.AKTS;
            tbl.BOLUMID = p.BOLUMID;
            tbl.FAKULTEID = p.FAKULTEID;
            tbl.KREDI = p.KREDI;
            tbl.AKADEMIKPERSONELID = p.AKADEMIKPERSONELID;

            return repotable.Update(tbl);
        }

        public int DeleteDers(int id)
        {
            DERS tbl = repotable.Find(x => x.ID == id);
            return repotable.Delete(tbl);
        }

        public DERS FindDers(int id)
        {
            return repotable.Find(x => x.ID == id);
        }

    }
}
