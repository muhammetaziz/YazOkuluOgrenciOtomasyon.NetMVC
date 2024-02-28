using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;

namespace OgrenciOtomasyon.Controllers
{
    public class DEF_TABLE_CRUDController : Controller
    {
        // GET: DEF_TABLE_CRUD
         UNIVERSITEManager um = new UNIVERSITEManager();
         FAKULTEManager fm = new FAKULTEManager();
         BOLUMManager bm = new BOLUMManager();

        #region Universite
        public ActionResult UniversiteList()
        {
            var pValues = um.GetAll();
            return View(pValues);
        }
        [HttpGet]
        public ActionResult UniversiteEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UniversiteEkle(UNIVERSITE p)
        {
            um.AddUNIVERSITE(p);
            return RedirectToAction("UniversiteList");
        }
        [HttpGet]
        public ActionResult UpdateUniversite(int id)
        {
            UNIVERSITE p = um.FindUNIVERSITE(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult UpdateUniversite(UNIVERSITE p)
        {
            um.EditUNIVERSITE(p);

            return RedirectToAction("UniversiteList");
        }

        public ActionResult DeleteUniversite(int id)
        {
            um.DeleteUNIVERSITE(id);

            return RedirectToAction("UniversiteList");

        }
        #endregion

        #region Fakulte
        public ActionResult FakulteList()
        {
            var pValues = fm.GetAll();
            return View(pValues);
        }
        [HttpGet]
        public ActionResult FakulteEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FakulteEkle(FAKULTE p)
        {
            fm.AddFAKULTE(p);
            return RedirectToAction("FakulteList");
        }
        [HttpGet]
        public ActionResult UpdateFakulte(int id)
        {
            FAKULTE p = fm.FindFAKULTE(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult UpdateFakulte(FAKULTE p)
        {
            fm.EditFAKULTE(p);

            return RedirectToAction("FakulteList");
        }

        public ActionResult DeleteFakulte(int id)
        {
            fm.DeleteFAKULTE(id);

            return RedirectToAction("FakulteList");

        }
        #endregion

        #region Bolum
        public ActionResult BolumList()
        {
            var pValues = bm.GetAll();
            return View(pValues);
        }
        [HttpGet]
        public ActionResult BolumEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BolumEkle(BOLUM p)
        {
            bm.AddBOLUM(p);
            return RedirectToAction("BolumList");
        }
        [HttpGet]
        public ActionResult UpdateBolum(int id)
        {
            FAKULTE p = fm.FindFAKULTE(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult UpdateBolum(BOLUM p)
        {
            bm.EditBOLUM(p);

            return RedirectToAction("BolumList");
        }

        public ActionResult DeleteBolum(int id)
        {
            bm.DeleteBOLUM(id);

            return RedirectToAction("BolumList");

        }
        #endregion
    }
}