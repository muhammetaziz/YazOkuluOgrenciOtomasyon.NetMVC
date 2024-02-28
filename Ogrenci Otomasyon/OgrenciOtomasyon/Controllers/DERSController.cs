using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace OgrenciOtomasyon.Controllers
{
    public class DERSController : Controller
    {
        // GET: DERS
        private DERSManager dm = new DERSManager();
        private AKADEMIKPERSONELManager akm = new AKADEMIKPERSONELManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDers()
        {
            var dersValues = dm.GetAll();
            var list = akm.GetAll();
            ViewBag.value1 = list;
            return View(dersValues);

        }
        [HttpGet]
        public ActionResult DersEkle()
        {
            Context c = new Context();
           
            List<SelectListItem> Fakulte = (from x in c.Fakultes.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ADI,
                                                Value = x.ID.ToString()
                                            }).ToList();
            List<SelectListItem> Bolum = (from x in c.Bolums.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ADI,
                                              Value = x.ID.ToString()
                                          }).ToList();
            List<SelectListItem> Akademisyen = (from x in c.Akademısyens.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ADI +" "+x.SOYADI,
                                              Value = x.ID.ToString()
                                          }).ToList();
            
            ViewBag.values1 = Akademisyen;
            ViewBag.values2 = Fakulte;
            ViewBag.values3 = Bolum;
            return View();
        }

        [HttpPost]
        public ActionResult DersEkle(DERS p)
        {
            dm.AddDers(p);
            return RedirectToAction("GetDers");
        }
        [HttpGet]
        public ActionResult UpdateDers(int id)
        {
            Context c = new Context();

            List<SelectListItem> Fakulte = (from x in c.Fakultes.ToList()
                select new SelectListItem
                {
                    Text = x.ADI,
                    Value = x.ID.ToString()
                }).ToList();
            List<SelectListItem> Bolum = (from x in c.Bolums.ToList()
                select new SelectListItem
                {
                    Text = x.ADI,
                    Value = x.ID.ToString()
                }).ToList();

            List<SelectListItem> Akademisyen = (from x in c.Akademısyens.ToList()
                select new SelectListItem
                {
                    Text = x.ADI + " " + x.SOYADI,
                    Value = x.ID.ToString()
                }).ToList();

            ViewBag.values1 = Akademisyen;
            ViewBag.values2 = Fakulte;
            ViewBag.values3 = Bolum;


            DERS ders = dm.FindDers(id);
            return View(ders);
        }
        [HttpPost]
        public ActionResult UpdateDers(DERS p)
        {
            dm.EditDers(p);

            return RedirectToAction("GetDers");
        }

        public ActionResult DeleteDers(int id)
        {
            dm.DeleteDers(id);

            return RedirectToAction("GetDers");

        }
    }
}