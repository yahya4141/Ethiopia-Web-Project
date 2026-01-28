using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using InternetProg.Models;

namespace InternetProg.Controllers
{
    public class AccountController : Controller
    {
        VeriTabaniContext db = new VeriTabaniContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string sifre)
        {
            var user = db.Kullanicilar.FirstOrDefault(x => x.Email == email && x.Sifre == sifre);

            if (user != null)
            {
                //navbar da kullanıcı adını göstermek için
                Session["KullaniciAdi"] = user.Ad + " " + user.Soyad;
                // --------------------------------

                Session["Ad"] = user.Ad;
                Session["Soyad"] = user.Soyad;
                Session["Rol"] = user.Rol;
                Session["UyeId"] = user.Id;

                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Hata = "E-Posta adresi veya şifre hatalı!";
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Kullanici k)
        {
            if (ModelState.IsValid)
            {
                var varMi = db.Kullanicilar.FirstOrDefault(x => x.Email == k.Email);
                if (varMi != null)
                {
                    ViewBag.Hata = "Bu E-Posta adresi zaten kayıtlı.";
                    return View(k);
                }

                k.Rol = "Uye";

                db.Kullanicilar.Add(k);
                db.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(k);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}