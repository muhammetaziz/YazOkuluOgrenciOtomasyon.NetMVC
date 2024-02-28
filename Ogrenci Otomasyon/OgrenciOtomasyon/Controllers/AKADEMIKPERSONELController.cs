using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciOtomasyon.Controllers
{
    public class AKADEMIKPERSONELController : Controller
    {
        AKADEMIKPERSONELManager akm = new AKADEMIKPERSONELManager();
        DERSHAREKETManager dm = new DERSHAREKETManager();
        // GET: AKADEMIKPERSONEL
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AkademikPersonelList()
        {
            var akmList = akm.GetAll();
            return View(akmList);
        }

        public ActionResult KomisyonaEkle(int id)
        {
            akm.KomisyonaEkle(id);
            if (id == (int)Session["UserId"])
            {
                Session["UserRole"] = "KOMISYON";
            }

            return RedirectToAction("AkademikPersonelList");
        }

        public ActionResult KomisyondanCikar(int id)
        {
            akm.KomisyondanCikar(id);
            if (id == (int)Session["UserId"])
            {

                Session["UserRole"] = "AKADEMIKPERSONEL";
            }
            return RedirectToAction("AkademikPersonelList");
        }
        [HttpGet]
        public ActionResult AkademikPersonelEkle()
        {
            Context c = new Context();
            List<SelectListItem> Bolum = (from x in c.Bolums.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ADI,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.values1 = Bolum;
            return View();
        }
        [HttpPost]
        public ActionResult AkademikPersonelEkle(AKADEMIKPERSONEL p)
        {
            akm.AddAkademikPersonel(p);
            return RedirectToAction("AkademikPersonelList");
        }
        [HttpGet]
        public ActionResult UpdateAkademikPersonel(int id)
        {
            Context c = new Context();
            List<SelectListItem> Bolum = (from x in c.Bolums.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ADI,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.values1 = Bolum;
            AKADEMIKPERSONEL ap = akm.FindAkademikPersonel(id);
            return View(ap);
        }
        [HttpPost]
        public ActionResult UpdateAkademikPersonel(AKADEMIKPERSONEL p)
        {
            akm.EditAkademikPersonel(p);
            return RedirectToAction("AkademikPersonelList");
        }
        public ActionResult DeleteAkademikPersonel(int id)
        {
            akm.DeleteAkademikPersonel(id);
            return RedirectToAction("AkademikPersonelList");
        }

        public ActionResult OnayBekleyenYazOkulu()
        {
            int danismanid = (int)Session["UserId"];
            ViewBag.UserRole = Session["UserRole"].ToString();
            var akademiPersonel = akm.FindAkademikPersonel(danismanid);
            ViewBag.value1 = akademiPersonel.ADI + " " + akademiPersonel.SOYADI;
            var BekleyenKontrol = dm.GetAll().Where(x => x.DANISMANID == danismanid);
            return View(BekleyenKontrol);
        }
    }
}