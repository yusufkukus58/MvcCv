using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositories;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class SefrikalarController : Controller
    {
        GenericRepository<TblSerfikalarim> repo = new GenericRepository<TblSerfikalarim>();
        public ActionResult Index()
        {
            var sefrika = repo.List();
            return View(sefrika);
        }
        [HttpGet]
        public ActionResult SefrikaGetir(int id)
        {
            var sefrika = repo.Find(x=>x.ID==id);
            return View(sefrika);
        }
        [HttpPost]
        public ActionResult SefrikaGetir(TblSerfikalarim p)
        {
            var sefrika = repo.Find(x => x.ID == p.ID);
            sefrika.Aciklama = p.Aciklama;
            sefrika.Tarih = p.Tarih;
            repo.TUpdate(sefrika);
            return RedirectToAction("Index");
        }
    }
}