using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InternetProg.Models;

namespace InternetProg.Controllers
{
    public class ManageController : Controller
    {
        VeriTabaniContext db = new VeriTabaniContext();

        bool AdminDegilseAt()
        {
            if (Session["Rol"] == null || Session["Rol"].ToString() != "Admin")
            {
                return true;
            }
            return false; 
        }

        public ActionResult Index()
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            return RedirectToAction("Kullanicilar");
        }

        public ActionResult SliderListesi()
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            var resimler = db.SliderResimleri.ToList();
            return View(resimler);
        }

        public ActionResult SliderEkle()
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public ActionResult SliderEkle(SliderResim s)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                db.SliderResimleri.Add(s);
                db.SaveChanges();
                return RedirectToAction("SliderListesi");
            }
            return View(s);
        }

        public ActionResult SliderSil(int? id)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            if (id == null) return RedirectToAction("SliderListesi");

            var resim = db.SliderResimleri.Find(id);
            if (resim != null)
            {
                db.SliderResimleri.Remove(resim);
                db.SaveChanges();
            }
            return RedirectToAction("SliderListesi");
        }

        public ActionResult SehirListesi()
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            var sehirler = db.Sehirler.ToList();
            return View(sehirler);
        }

        public ActionResult SehirEkle()
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public ActionResult SehirEkle(Sehir s)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            if (ModelState.IsValid)
            {
                db.Sehirler.Add(s);
                db.SaveChanges();
                return RedirectToAction("SehirListesi");
            }
            return View(s);
        }

        public ActionResult SehirDuzenle(int? id)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            if (id == null) return RedirectToAction("SehirListesi");

            var sehir = db.Sehirler.Find(id);
            if (sehir == null) return HttpNotFound();

            return View(sehir);
        }

        [HttpPost]
        public ActionResult SehirDuzenle(Sehir s)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                var eski = db.Sehirler.Find(s.Id);
                if (eski != null)
                {
                    eski.SehirAdi = s.SehirAdi;
                    eski.Nufus = s.Nufus;
                    eski.OneCikan = s.OneCikan;
                    eski.ResimUrl = s.ResimUrl;
                    eski.Bilgi = s.Bilgi;
                    db.SaveChanges();
                }
                TempData["Mesaj"] = "Şehir başarıyla güncellendi.";
                return RedirectToAction("SehirListesi");
            }
            return View(s);
        }

        public ActionResult SehirSil(int? id)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            if (id == null) return RedirectToAction("SehirListesi");

            var sehir = db.Sehirler.Find(id);
            if (sehir != null)
            {
                db.Sehirler.Remove(sehir);
                db.SaveChanges();
            }
            return RedirectToAction("SehirListesi");
        }

        public ActionResult NufusListesi()
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            var nufus = db.NufusBilgileri.OrderBy(x => x.Yil).ToList();
            return View(nufus);
        }

        public ActionResult NufusEkle()
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public ActionResult NufusEkle(NufusBilgi n)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            if (ModelState.IsValid)
            {
                db.NufusBilgileri.Add(n);
                db.SaveChanges();
                return RedirectToAction("NufusListesi");
            }
            return View(n);
        }

        public ActionResult NufusSil(int? id)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            if (id == null) return RedirectToAction("NufusListesi");

            var kayit = db.NufusBilgileri.Find(id);
            if (kayit != null)
            {
                db.NufusBilgileri.Remove(kayit);
                db.SaveChanges();
            }
            return RedirectToAction("NufusListesi");
        }

        public ActionResult TuristikListesi()
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            var yerler = db.TuristikYerler.ToList();
            return View(yerler);
        }

        public ActionResult TuristikEkle()
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public ActionResult TuristikEkle(TuristikYer t)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            if (ModelState.IsValid)
            {
                db.TuristikYerler.Add(t);
                db.SaveChanges();
                return RedirectToAction("TuristikListesi");
            }
            return View(t);
        }

        public ActionResult TuristikDuzenle(int? id)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            if (id == null) return RedirectToAction("TuristikListesi");

            var yer = db.TuristikYerler.Find(id);
            if (yer == null) return HttpNotFound();

            return View(yer);
        }

        [HttpPost]
        public ActionResult TuristikDuzenle(TuristikYer t)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            if (ModelState.IsValid)
            {
                var eski = db.TuristikYerler.Find(t.Id);
                if (eski != null)
                {
                    eski.YerAdi = t.YerAdi;
                    eski.Aciklama = t.Aciklama;
                    eski.ResimUrl = t.ResimUrl;
                    db.SaveChanges();
                }
                return RedirectToAction("TuristikListesi");
            }
            return View(t);
        }

        public ActionResult TuristikSil(int? id)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            if (id == null) return RedirectToAction("TuristikListesi");

            var yer = db.TuristikYerler.Find(id);
            if (yer != null)
            {
                db.TuristikYerler.Remove(yer);
                db.SaveChanges();
            }
            return RedirectToAction("TuristikListesi");
        }

        public ActionResult Kullanicilar()
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
          
            var kullanicilar = db.Kullanicilar.ToList();
            return View(kullanicilar);
        }

        [HttpPost]
        public ActionResult RolGuncelle(int id, string yeniRol)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");

            var user = db.Kullanicilar.Find(id);
            if (user != null)
            {
                user.Rol = yeniRol;
                db.SaveChanges();
            }
            return RedirectToAction("Kullanicilar");
        }

        public ActionResult KullaniciSil(int? id)
        {
            if (AdminDegilseAt()) return RedirectToAction("Login", "Account");
            if (id == null) return RedirectToAction("Kullanicilar");

            var user = db.Kullanicilar.Find(id);
            if (user != null)
            {
    
                db.Kullanicilar.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("Kullanicilar");
        }
    }
}