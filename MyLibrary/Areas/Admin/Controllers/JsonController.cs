using MyLibrary.Areas.Admin.Data;
using System.Linq;
using System.Web.Mvc;

namespace MyLibrary.Areas.Admin.Controllers
{
    public class JsonController : Controller
    {
        // GET: Admin/Ekle
        [HttpPost]
        public ActionResult EkleKitap(KitapModel model)
        {
            
            InsertEntities db = new InsertEntities();
            Book bk = new Book();
            bk.Book_author_id = model.yazarKategori;
            bk.Book_genre_id = model.turKategori;
            bk.Book_publisher_id = model.yayineviKategori;
            bk.Book_language_id = model.dilKategori;
         
            if (model.kitapSayfasi == 0 || model.kitapBaskisi == 0 || model.kitapBaskiYili == 0 || model.kitapAdi == null)
            {
                return Json("0");
            }
            else
            {
                bk.Book_edition = model.kitapBaskisi;
                bk.Book_edition_year = model.kitapBaskiYili;
                bk.Book_title = model.kitapAdi;
                bk.Book_pages = model.kitapSayfasi;
                bk.Book_price = model.kitapFiyati;
                db.Books.Add(bk);
                db.SaveChanges();
                return Json("1");

            }

        }

        [HttpPost]
        public ActionResult DuzenleKitap(KitapModel md)
        {
            InsertEntities db = new InsertEntities();     
            var editKitapSorgu = db.Books.Where(x => x.Book_id == md.kitapId).FirstOrDefault();
            if (editKitapSorgu != null)
            {
                editKitapSorgu.Book_edition = md.kitapBaskisi;
                editKitapSorgu.Book_edition_year = md.kitapBaskiYili;
                editKitapSorgu.Book_title = md.kitapAdi;
                editKitapSorgu.Book_pages = md.kitapSayfasi;
                editKitapSorgu.Book_price = md.kitapFiyati;
                editKitapSorgu.Book_author_id = md.yazarKategori;
                editKitapSorgu.Book_genre_id = md.turKategori;
                editKitapSorgu.Book_publisher_id = md.yayineviKategori;
                editKitapSorgu.Book_language_id = md.dilKategori;
         
                db.SaveChanges();
            }
            return Json("1");
        }

        [HttpPost]
        public ActionResult silKitap (KitapModel md)
        {
            InsertEntities db = new InsertEntities();
            var deleteKitapSorgu = db.Books.Where(x => x.Book_id == md.kitapId).FirstOrDefault();
            db.Books.Remove(deleteKitapSorgu);
            db.SaveChanges();
            return Json("1");
            
        }
        
    }

    public class KitapModel
    {
        public int kitapId { get; set; }
        public string kitapAdi { get; set; }
        public int kitapSayfasi { get; set; }
        public int kitapBaskisi { get; set; }
        public int kitapBaskiYili { get; set; }
        public double kitapFiyati { get; set; }
        public int yazarKategori { get; set; }
        public int turKategori { get; set; }
        public int yayineviKategori { get; set; }
        public int dilKategori { get; set; }
    }

}