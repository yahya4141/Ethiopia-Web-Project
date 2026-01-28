using System.Linq;
using System.Web.Mvc;
using InternetProg.Models;

namespace InternetProg.Controllers
{
    public class HomeController : Controller
    {
        VeriTabaniContext db = new VeriTabaniContext();
      
        [AllowAnonymous]
        public ActionResult Index()
        {
            var resimler = db.SliderResimleri.OrderBy(x => x.Sira).ToList();
            return View(resimler);
        }
        [Authorize]
        public ActionResult Bilgiler()
        {
            if (Session["KullaniciAdi"] == null && Session["Rol"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            SiteVeriModeli model = new SiteVeriModeli();
            model.SehirlerListesi = db.Sehirler.ToList();
            model.NufusListesi = db.NufusBilgileri.OrderBy(x => x.Yil).ToList();
            model.TuristikYerlerListesi = db.TuristikYerler.ToList();

            return View(model);
        }
    }
}