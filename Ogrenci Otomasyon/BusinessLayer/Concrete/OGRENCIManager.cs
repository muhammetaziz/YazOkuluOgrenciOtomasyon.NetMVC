using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OGRENCIManager
    {
        private Repository<Ogrenci> repoogrenci = new Repository<Ogrenci>();
        private Repository<LOGINUSER> repologin = new Repository<LOGINUSER>();

        public List<Ogrenci> GetAll()
        {
            return repoogrenci.List();
        }

        public int AddOgrenci(Ogrenci p)
        {
            
            int x=repoogrenci.Insert(p);
            LOGINUSER luser = new LOGINUSER();
            luser.UserName = p.OGRENCINO;
            luser.Password = p.OGRENCINO;
            luser.ROLE = "OGRENCI";
            luser.USERID = p.ID;
            var y=repologin.Insert(luser);

            if (x ==1 && y == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int EditOgrenci(Ogrenci p)
        {
            Ogrenci ogr = repoogrenci.Find(x => x.ID == p.ID);
            ogr.ADI = p.ADI;
            ogr.SOYADI = p.SOYADI;
            ogr.OGRENCINO = p.OGRENCINO;
            ogr.BOLUMID = p.BOLUMID;
            ogr.FAKULTEID = p.FAKULTEID;
            ogr.UNIVERSITEID = p.UNIVERSITEID;
            ogr.TCNO = p.TCNO;
            ogr.DANISMANID = p.DANISMANID;
            return repoogrenci.Update(ogr);
        }

        public int DeleteOgrenci(int id)
        {
            Ogrenci ogr = repoogrenci.Find(x => x.ID == id);
            return repoogrenci.Delete(ogr);
        }

        public Ogrenci FindOgrenci(int id)
        {
            return repoogrenci.Find(x => x.ID == id);
        }
    }
}
