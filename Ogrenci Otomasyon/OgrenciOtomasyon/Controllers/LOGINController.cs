using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace OgrenciOtomasyon.Controllers
{
    public class LOGINController : Controller
    {
        // GET: LOGIN
        private LOGINUSERManager lm = new LOGINUSERManager();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OgrenciLogin()
        {
            Context c = new Context();
            var admin =c.Logınusers.FirstOrDefault(x => x.UserName == "admin");
            if (admin == null)
            {
                LOGINUSER p = new LOGINUSER();
                p.ROLE = "ADMIN";
                p.UserName = "admin";
                p.Password = "admin";
                p.ROLE = "ADMIN";
                lm.AddUser(p);

            }


            return View();
        }
        [HttpPost]
        public ActionResult OgrenciLogin(LOGINUSER p)
        {
            Context c = new Context();

            var userdata = c.Logınusers.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);

            if (userdata != null)
            {

                FormsAuthentication.SetAuthCookie(userdata.UserName, false);

                FormsAuthentication.SetAuthCookie(userdata.UserName, false);
                Session["UserName"] = userdata.UserName.ToString();
                Session["UserId"] = userdata.USERID;
                Session["UserRole"] = userdata.ROLE;
                string kullanici = (string)Session["UserName"];

                int deneme = (int)Session["UserId"];
                return RedirectToAction("OgrenciList", "OGRENCI");

            }
            else
            {
                return RedirectToAction("OgrenciLogin", "LOGIN");

            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("OgrenciLogin", "Login");
        }
    }
}