using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DERSHAREKETManager
    {
        private Repository<DERSHAREKET> repoDersHareket = new Repository<DERSHAREKET>();
        private Repository<UNIVERSITE> repouni = new Repository<UNIVERSITE>();
        private Repository<DERTHAREKETDETAILS> repoDertHareketDetails = new Repository<DERTHAREKETDETAILS>();
        private Repository<LOGINUSER> repologin = new Repository<LOGINUSER>();
        public List<DERSHAREKET> GetAll()
        {

            return repoDersHareket.List();
        }
        public List<DERTHAREKETDETAILS> GetAllHarekets()
        {

            return repoDertHareketDetails.List();
        }

        public int AddDersHareket(DERSHAREKET p)
        {
            return repoDersHareket.Insert(p);
           
        }

        public int EditDersHareket(DERSHAREKET p)
        {
            DERSHAREKET dh = repoDersHareket.Find(x => x.ID == p.ID);
            dh.UNIVERSITEID = p.UNIVERSITEID;
            UNIVERSITE uni = repouni.Find(x => x.ID == dh.UNIVERSITEID);
            dh.UNIVERSITEADI = uni.ADI;


            // akd.FOTOGRAFYOL=p.FOTOGRAFYOL
            return repoDersHareket.Update(dh);
        }

        public int DersOnay(DERSHAREKET p)
        {
            DERSHAREKET dh = repoDersHareket.Find(x => x.ID == p.ID);
            dh.STATE = p.STATE;


            // akd.FOTOGRAFYOL=p.FOTOGRAFYOL
            return repoDersHareket.Update(dh);
        }
        public int DeleteDersHareket(int id)
        {
            DERSHAREKET akd = repoDersHareket.Find(x => x.ID == id);
            return repoDersHareket.Delete(akd);
        }

        public DERSHAREKET FindDersHareket(int id)
        {
            return repoDersHareket.Find(x => x.ID == id);
        }
        public DERTHAREKETDETAILS FindDertHareket(int id)
        {
            return repoDertHareketDetails.Find(x => x.ID == id);
        }

        public int AddDertHareket(DERTHAREKETDETAILS p)
        {
            return repoDertHareketDetails.Insert(p);
        }

        public int DeleteDertHareket(int pkid, int dersid)
        {
            DERTHAREKETDETAILS dhd = repoDertHareketDetails.Find(x => x.PKID == pkid && x.DERSID == dersid);
            return repoDertHareketDetails.Delete(dhd);
        }

        public void DeleteDertHareketByPKID(int pkid)
        {
            List<DERTHAREKETDETAILS> temp = repoDertHareketDetails.List().Where(x => x.PKID == pkid).ToList();
            foreach (var item in temp)
            {
                DERTHAREKETDETAILS dh = repoDertHareketDetails.Find(x => x.ID == item.ID);
                repoDertHareketDetails.Delete(dh);

            }
        }

        public int DertOnay(int id)
        {
            DERTHAREKETDETAILS p = repoDertHareketDetails.Find(x=>x.ID==id);

            p.STATE = 1;
            return repoDertHareketDetails.Update(p);
        }
    }

}

