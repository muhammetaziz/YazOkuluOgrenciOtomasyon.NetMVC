using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class AKADEMIKPERSONELManager
    {
        private Repository<AKADEMIKPERSONEL> repoakademik = new Repository<AKADEMIKPERSONEL>();
        private Repository<LOGINUSER> repologin = new Repository<LOGINUSER>();
        public List<AKADEMIKPERSONEL> GetAll()
        {
            return repoakademik.List();
        }

        public int AddAkademikPersonel(AKADEMIKPERSONEL p)
        {
            int x= repoakademik.Insert(p);
            LOGINUSER luser = new LOGINUSER();
            luser.UserName = p.SICILNO;
            luser.Password = p.SICILNO;
            luser.ROLE = "AKADEMIKPERSONEL";
            luser.USERID = p.ID;
            var y = repologin.Insert(luser);
            if (x == 1 && y == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int EditAkademikPersonel(AKADEMIKPERSONEL p)
        {
            AKADEMIKPERSONEL akd = repoakademik.Find(x => x.ID == p.ID);
            akd.ADI = p.ADI;
            akd.BOLUMID = p.BOLUMID;
            akd.SOYADI = p.SOYADI;
            akd.UNVAN = p.UNVAN;
           // akd.FOTOGRAFYOL=p.FOTOGRAFYOL
            return repoakademik.Update(akd);
        }

        public int KomisyonaEkle(int id)
        {
            AKADEMIKPERSONEL akm = repoakademik.Find(x => x.ID == id);
            akm.FOTOGRAFYOL = "KOMISYON";
            repoakademik.Update(akm);
            LOGINUSER p = repologin.Find(x => x.USERID == id);
            p.ROLE = "KOMISYON";
            return repologin.Update(p);

        }
        public int KomisyondanCikar(int id)
        {
            AKADEMIKPERSONEL akm = repoakademik.Find(x => x.ID == id);
            akm.FOTOGRAFYOL = "";
            repoakademik.Update(akm);
            LOGINUSER p = repologin.Find(x => x.USERID == id);
            p.ROLE = "AKADEMIKPERSONEL";
            return repologin.Update(p);

        }
        public int DeleteAkademikPersonel(int id)
        {
            AKADEMIKPERSONEL akd = repoakademik.Find(x => x.ID == id);
            return repoakademik.Delete(akd);
        }

        public AKADEMIKPERSONEL FindAkademikPersonel(int id)
        {
            return repoakademik.Find(x => x.ID == id);
        }
    }
}
