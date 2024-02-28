using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace OgrenciOtomasyon.Controllers
{
    public class OGRENCIController : Controller
    {
        // GET: OGRENCI
        private OGRENCIManager om = new OGRENCIManager();
        public ActionResult OgrenciList()
        {
            var OgrenciValues = om.GetAll();
            return View(OgrenciValues);
        } 
        public ActionResult OgrenciListByDanisman()
        {
            int DanismanId = (int)Session["UserId"];
            var OgrenciValues = om.GetAll().Where(x=>x.DANISMANID== DanismanId);
            //var OgrenciValues = om.GetAll().Where(x=>!danismanValues.Contains(x));
            return View(OgrenciValues);
        }
        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            Context c = new Context();
            List<SelectListItem> Universite = (from x in c.Unıversıtes.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ADI,
                                              Value = x.ID.ToString()
                                          }).ToList();
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
            List<SelectListItem> Danisman = (from x in c.Akademısyens.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.ADI + " " + x.SOYADI + " -- " + x.UNVAN,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.values1 = Universite;
            ViewBag.values2 = Fakulte;
            ViewBag.values3 = Bolum;
            ViewBag.values4 = Danisman;
            return View();
        }

        [HttpPost]
        public ActionResult OgrenciEkle(Ogrenci p)
        {
            om.AddOgrenci(p);
            return RedirectToAction("OgrenciList");
        }
        [HttpGet]
        public ActionResult UpdateOgrenci(int id)
        {
            Context c = new Context();
            List<SelectListItem> Universite = (from x in c.Unıversıtes.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.ADI,
                                                   Value = x.ID.ToString()
                                               }).ToList();
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
            List<SelectListItem> Danisman = (from x in c.Akademısyens.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ADI+" "+x.SOYADI +" -- "+x.UNVAN,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.values1 = Universite;
            ViewBag.values2 = Fakulte;
            ViewBag.values3 = Bolum;
            ViewBag.values4 = Danisman;
            Ogrenci ogr = om.FindOgrenci(id);
            return View(ogr);
        }
        [HttpPost]
        public ActionResult UpdateOgrenci(Ogrenci p)
        {
            om.EditOgrenci(p);

            return RedirectToAction("OgrenciList");
        }

        public ActionResult DeleteOgrenci(int id)
        {
            om.DeleteOgrenci(id);

            return RedirectToAction("OgrenciList");

        }
    }
}