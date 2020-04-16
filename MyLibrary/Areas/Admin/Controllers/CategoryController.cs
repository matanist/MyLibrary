using MyLibrary.Areas.Admin.Data;
using System.Linq;
using System.Web.Mvc;

namespace MyLibrary.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        InsertEntities db = new InsertEntities();
        // GET: Admin/Category
        [HttpGet]
        public JsonResult YazarKategoriYukle()
        {         
            var sorgu = (from i in db.Authors
                         select new
                         {
                             id = i.Author_id,
                             kategoriAdi = i.Author_name,
                             kategoriSoyadi = i.Author_surname
                         }).ToList();

            return Json(sorgu, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult TurKategoriYukle()
        {
            var sorgu = (from a in db.Genres
                         select new
                         {
                             id = a.Genres_id,
                             turAdi = a.Genre_name

                         }).ToList();
            return Json(sorgu, JsonRequestBehavior.AllowGet);
        }
        //[HttpGet]

        public JsonResult YayineviKategoriYukle()
        {
            var sorgu = (from y in db.Publishers
                         select new
                         {
                             id = y.Publisher_id,
                             yayineviAdi = y.Publisher_name,
                         }).ToList();
            return Json(sorgu, JsonRequestBehavior.AllowGet);

        }
        public JsonResult DilKategoriYukle()
        {
            var sorgu = (from y in db.Languages
                         select new
                         {
                             id = y.Language_id,
                             dilAdi = y.Language1,
                         }).ToList();
            return Json(sorgu, JsonRequestBehavior.AllowGet);

        }

        public JsonResult YazarListele()
        {
            var sorgu = (from i in db.Authors
                         select new
                         {
                             id = i.Author_id,
                             yazarAdi = i.Author_name,
                             yazarSoyadi = i.Author_surname,

                         }).OrderBy(x => x.yazarAdi).ToList();
            return Json(sorgu);
        }

        public JsonResult TurListele()
        {
            var sorgu = (from i in db.Genres
                         select new
                         {
                             id = i.Genres_id,
                             turu = i.Genre_name,
                         }).OrderBy(x => x.turu).ToList();
            return Json(sorgu);
                
        }

        public JsonResult YayineviListele()
        {
            var sorgu = (from i in db.Publishers
                         select new
                         {
                             id = i.Publisher_id,
                             yayinevi = i.Publisher_name,
                         }).OrderBy(x=>x.yayinevi).ToList();
            
            return Json(sorgu);
        }

        public JsonResult DilListele()
        {
            var sorgu = (from i in db.Languages
                         select new
                         {
                             id = i.Language_id,
                             dili = i.Language1,
                         }).OrderBy(x => x.dili).ToList();
            return Json(sorgu);
        }   

        [HttpPost]
        public ActionResult YazarEkle(Yazar yazars)
        {
            Author au = new Author();
            au.Author_name = yazars.ad;
            au.Author_surname = yazars.soyad;
            if (yazars.ad == null || yazars.soyad == null)
            {
                return Json("0");
            }
            else
            {
                au.Author_name = yazars.ad;
                au.Author_surname = yazars.soyad;
                db.Authors.Add(au);
                db.SaveChanges();
                return Json("1");
            }
        }
        public class Yazar
        {
            public int id { get; set; }
            public string ad { get; set; }
            public string soyad { get; set; }
        }

        public ActionResult TurEkle(Tur turs)
        {
            Genre ge = new Genre();
            ge.Genre_name = turs.turAdi;
            if (turs.turAdi == null )
            {
                return Json("0");
            }
            else
            {
                ge.Genre_name = turs.turAdi;
                db.Genres.Add(ge);
                db.SaveChanges();
                return Json("1");
            }
        }
        public class Tur
        {
            public int id { get; set; }
            public string turAdi { get; set; }
        }

        public ActionResult YayıneviEkle(Yayinevi yye)
        {
            Publisher pb = new Publisher();
            pb.Publisher_name = yye.yayinevi;
            if (yye.yayinevi == null)
            {
                return Json("0");
            }
            else
            {
                db.Publishers.Add(pb);
                db.SaveChanges();
                return Json("1");
            }
        }

        public class Yayinevi
        {
            public int id { get; set; }
            public string yayinevi { get; set; }
        }
        public ActionResult DilEkle(Dil dl)
        {
            Language la = new Language();
            la.Language1 = dl.dilAdi;
            if (dl.dilAdi == null)
            {
                return Json("0");
            }
            else
            {
                db.Languages.Add(la);
                db.SaveChanges();
                return Json("1");
            }
        }
        public class Dil
        {
            public int id { get; set; }
            public string dilAdi { get; set; }
        }
        [HttpPost]
        public ActionResult YazarDuzenle(Yazar yzr)
        {
            var editAuthor = db.Authors.Where(x => x.Author_id == yzr.id).FirstOrDefault();
            if(editAuthor != null)
            {
                editAuthor.Author_name = yzr.ad;
                editAuthor.Author_surname = yzr.soyad;
                db.SaveChanges();
            }
      
            return Json("1");
        }

        public ActionResult TurDuzenle(Tur turs)
        {
            var editTur = db.Genres.Where(x => x.Genres_id == turs.id).FirstOrDefault();
            if(editTur != null)
            {
                editTur.Genre_name = turs.turAdi;
                db.SaveChanges();
            }
                   
            return Json("1");
        }
        public ActionResult YayıneviDuzenle(Yayinevi yyev)
        {
            var editYayınevi = db.Publishers.Where(x => x.Publisher_id == yyev.id).FirstOrDefault();
            if (editYayınevi != null)
            {
                editYayınevi.Publisher_name = yyev.yayinevi;
                db.SaveChanges();
            }

            return Json("1");
        }
        public ActionResult DilDuzenle(Dil dil)
        {
            var editDil = db.Languages.Where(x => x.Language_id == dil.id).FirstOrDefault();
            if (editDil != null)
            {
                editDil.Language1 = dil.dilAdi;
                db.SaveChanges();
            }

            return Json("1");
        }

        public ActionResult YazarSil(Yazar yzr)
        {
        
            var deleteYazar = db.Authors.Where(x => x.Author_id == yzr.id).FirstOrDefault();
            db.Authors.Remove(deleteYazar);
            db.SaveChanges();
            return Json("1");

        }

        public ActionResult TurSil(Tur tr)
        {

            var deleteTur = db.Genres.Where(x => x.Genres_id == tr.id).FirstOrDefault();
            db.Genres.Remove(deleteTur);
            db.SaveChanges();
            return Json("1");

        }

        public ActionResult YayıneviSil(Yayinevi yyev)
        {

            var deleteYayinevi = db.Publishers.Where(x => x.Publisher_id == yyev.id).FirstOrDefault();
            db.Publishers.Remove(deleteYayinevi);
            db.SaveChanges();
            return Json("1");

        }

        public ActionResult DilSil(Dil dl)
        {

            var deleteDil = db.Languages.Where(x => x.Language_id == dl.id).FirstOrDefault();
            db.Languages.Remove(deleteDil);
            db.SaveChanges();
            return Json("1");

        }


    }
}


