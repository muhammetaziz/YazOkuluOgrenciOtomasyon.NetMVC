using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace OgrenciOtomasyon.Controllers
{
    public class DERSHAREKETController : Controller
    {
        // GET: DERSHAREKET
        private DERSHAREKETManager dm = new DERSHAREKETManager();
       
        private OGRENCIManager om = new OGRENCIManager();
        private DERSManager dema = new DERSManager();
        private AKADEMIKPERSONELManager akm = new AKADEMIKPERSONELManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDersHareket(bool? durum = null)
        {
            int OgrenciId = (int)Session["UserId"];
            var ogr = om.FindOgrenci(OgrenciId);
            var akademiPersonel = akm.FindAkademikPersonel(ogr.DANISMANID);
            ViewBag.value1 = akademiPersonel.ADI + " " + akademiPersonel.SOYADI;
            var dHareket = dm.GetAll().Where(x => x.OGRENCIID == OgrenciId);
             if (durum == false)
            {
                ViewBag.Success = false;
            }
            return View(dHareket);
        }

        public ActionResult AddDersHareket()
        {
            int OgrenciId = (int)Session["UserId"];
           
            var dHareket = dm.GetAll().Where(x => x.OGRENCIID == OgrenciId);

            if (dHareket.Count() > 0)
            {
                return RedirectToAction("GetDersHareket","DERSHAREKET",new {durum=false});
            }
            Ogrenci ogr = om.FindOgrenci((int)Session["UserId"]);
            DERSHAREKET dh = new DERSHAREKET();
            dh.OGRENCIID =  (int)Session["UserId"];
            dh.DANISMANID = ogr.DANISMANID;
            //dh.AKADEMIKPERSONELs.ID = ogr.DANISMANID;
            dh.INSERT_DATE=DateTime.Now;
            dh.STATE = 2;
            dh.UNIVERSITESTATE = 0;
            dh.UNIVERSITEADI = ogr.UNIVERSITEs.ADI;
            dm.AddDersHareket(dh);
            
            return RedirectToAction("GetDersHareket");

        }
        public ActionResult AddDersHareketAnotherUnivers()
        {
            int OgrenciId = (int)Session["UserId"];

            var dHareket = dm.GetAll().Where(x => x.OGRENCIID == OgrenciId);

            if (dHareket.Count() > 0)
            {
                return RedirectToAction("GetDersHareket", "DERSHAREKET", new { durum = false });
            }
            Ogrenci ogr = om.FindOgrenci((int)Session["UserId"]);
            DERSHAREKET dh = new DERSHAREKET();
            dh.OGRENCIID =  (int)Session["UserId"];
            dh.DANISMANID = ogr.DANISMANID;
            //dh.AKADEMIKPERSONELs.ID = ogr.DANISMANID;
            dh.INSERT_DATE=DateTime.Now;
            dh.STATE = 3;
            dh.UNIVERSITESTATE = 1;
            dm.AddDersHareket(dh);
            //string a = ogr.AKADEMIKPERSONELs.ADI;
            //string b = ogr.AKADEMIKPERSONELs.SOYADI;
            return RedirectToAction("GetDersHareket");

        }

        public ActionResult GetDersHareketDetails(int id)
        {
            dm.GetAllHarekets().Where(x => x.PKID == id);

            return View();
        }

        public PartialViewResult GetEklenecekDersler(int id)
        {
            Context c = new Context();
            var dershareket = dm.FindDersHareket(id);
            var ogrencibolum = dershareket.Ogrencis.BOLUMID;
            List<int> temp = (from x in c.DertHareketDetailss where x.PKID == id select x.DERSID).ToList();
            ViewBag.value1 = id;
            var dersler = dema.GetAll().Where(x => !temp.Contains(x.ID) && x.BOLUMID == ogrencibolum).ToList();


            return PartialView(dersler);
        }

        public ActionResult BekleyenYazOkuluDersOnayla(int id)
        {
            Context c = new Context();
            List<int> temp = (from x in c.Derss where x.AKADEMIKPERSONELID == id select x.ID).ToList();

            var verilenDers = dm.GetAllHarekets().Where(x => temp.Contains(x.DERSID)).ToList();


            return View(verilenDers);
        }
        public PartialViewResult GetEkliDersler(int id)
        {
            Context c = new Context();
            List<int> temp = (from x in c.DertHareketDetailss where x.PKID == id select x.DERSID).ToList();
            ViewBag.value1 = id;
            var dersler = dema.GetAll().Where(x => temp.Contains(x.ID)).ToList();
            

            
            return PartialView(dersler);
        }

        public ActionResult AddDers(int pkid,int dersid)
        {
            DERTHAREKETDETAILS p = new DERTHAREKETDETAILS();
            var dersHareket = dm.FindDersHareket(pkid);
            if (dersHareket.STATE == 3)
            {
                p.STATE = 0;
            }
            else
            {
                p.STATE = 1;
            }
            
            p.DERSID = dersid;
            p.PKID = pkid;
            dm.AddDertHareket(p);
            return RedirectToAction($"GetDersHareketDetails/{pkid}");
        }

        public ActionResult DeleteDers(int pkid, int dersid)
        {
            dm.DeleteDertHareket(pkid, dersid);
            return RedirectToAction($"GetDersHareketDetails/{pkid}");
        }

        [HttpGet]
        public ActionResult AddUniversite(int id)
        {
            Context c = new Context();
            List<SelectListItem> Universite = (from x in c.Unıversıtes.ToList()
                select new SelectListItem
                {
                    Text = x.ADI,
                    Value = x.ID.ToString()
                }).ToList();
            ViewBag.values1 = Universite;
            DERSHAREKET ogr = dm.FindDersHareket(id);
            return View(ogr);

        }
        [HttpPost]
        public ActionResult AddUniversite(DERSHAREKET p)
        {
            dm.EditDersHareket(p);

            return RedirectToAction("GetDersHareket");
        }

        public ActionResult DeleteDersHareket(int id)
        {

            dm.DeleteDertHareketByPKID(id);
            dm.DeleteDersHareket(id);
            return RedirectToAction("GetDersHareket");
        }
        public ActionResult GetDersHareketDetailsByAkademisyen(int id)
        {
            dm.GetAllHarekets().Where(x => x.PKID == id);

            return View();
        }
        public PartialViewResult GetEklenecekDerslerByAkademisyen(int id)
        {
            Context c = new Context();
            var dershareket = dm.FindDersHareket(id);
            var ogrencibolum = dershareket.Ogrencis.BOLUMID;
            List<int> temp = (from x in c.DertHareketDetailss where x.PKID == id select x.DERSID ).ToList();
            ViewBag.value1 = id;
            var dersler = dema.GetAll().Where(x => !temp.Contains(x.ID) && x.BOLUMID==ogrencibolum).ToList();



            return PartialView(dersler);
        }
        public PartialViewResult GetEkliDerslerByAkademisyen(int id)
        {
            Context c = new Context();
            List<int> temp = (from x in c.DertHareketDetailss where x.PKID == id select x.DERSID).ToList();
            ViewBag.value1 = id;
            var dersler = dema.GetAll().Where(x => temp.Contains(x.ID)).ToList();



            return PartialView(dersler);
        }

        public ActionResult KomisyonOnay(int id)
        {
            DERSHAREKET p = dm.FindDersHareket(id);
            p.STATE = 4;
            dm.DersOnay(p);

            return RedirectToAction("OnayBekleyenYazOkulu", "AKADEMIKPERSONEL");
        }
        public ActionResult DanismanOnay(int id)
        {
            DERSHAREKET p = dm.FindDersHareket(id);
            p.STATE = 2;
            dm.DersOnay(p);

            return RedirectToAction("OnayBekleyenYazOkulu", "AKADEMIKPERSONEL");
        }

        public ActionResult DersOnayla(int id)
        {
            dm.DertOnay(id);
            var dershareket = dm.FindDertHareket(id);
            var list = dm.GetAllHarekets().Where(x => x.PKID == dershareket.PKID);
            var checklist = dm.GetAllHarekets().Where(x => x.PKID == dershareket.PKID && x.STATE == 1);

            if (list.Count() == checklist.Count())
            {
                DERSHAREKET p = dm.FindDersHareket(dershareket.PKID);
                p.STATE = 0;
                dm.DersOnay(p);
            }
            int userid = (int)Session["UserId"];
            return RedirectToAction($"BekleyenYazOkuluDersOnayla/{userid}");
        }

    }
}