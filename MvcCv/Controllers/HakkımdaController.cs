using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcCv.Controllers
{
    public class HakkımdaController : Controller
    {
        DbCvEntities db = new DbCvEntities();
         GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hak = repo.List();
            return View(hak);
        }
        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Mail = p.Mail;
            t.Resim = p.Resim;
            t.Aciklama = p.Aciklama;
            t.Adres = p.Adres;
            t.Telefon = p.Telefon;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}