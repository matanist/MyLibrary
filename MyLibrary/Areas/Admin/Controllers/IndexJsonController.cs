using MyLibrary.Areas.Admin.Data;
using System.Linq;
using System.Web.Mvc;

namespace MyLibrary.Areas.Admin.Controllers
{
    public class IndexJsonController : Controller
    {
        InsertEntities db = new InsertEntities();
        // GET: Admin/IndexJson
        public ActionResult MaxValue()
        {
            var result = (from a in db.Books
                          join b in db.Authors on a.Book_author_id equals b.Author_id
                          select new
                          {
                              name = b.Author_name,
                              surname = b.Author_surname,
                          });
            var name2 = result.GroupBy(q => q);
            var name3 = name2.OrderByDescending(gp => gp.Count());
            var name4 = name3.Take(1);
            var name5 = name4.Select(g => g.Key).ToList();



            return Json(name5, JsonRequestBehavior.AllowGet);


        }
        public ActionResult MaxValueTur()
        {
            var result = (from a in db.Books
                          join b in db.Genres on a.Book_genre_id equals b.Genres_id
                          select new
                          {
                              genre = b.Genre_name
                          })

            .GroupBy(q => q)
            .OrderByDescending(gp => gp.Count())
            .Take(1)
            .Select(g => g.Key).ToList();



            return Json(result, JsonRequestBehavior.AllowGet);


        }
        public ActionResult MaxValueYayınevi()
        {
            var result = (from a in db.Books
                          join b in db.Publishers on a.Book_publisher_id equals b.Publisher_id
                          select new
                          {
                              publisher = b.Publisher_name
                          })

            .GroupBy(q => q)
            .OrderByDescending(gp => gp.Count())
            .Take(1)
            .Select(g => g.Key).ToList();



            return Json(result, JsonRequestBehavior.AllowGet);


        }
        public ActionResult MaxValueDil()
        {
            var result = (from a in db.Books
                          join b in db.Languages on a.Book_language_id equals b.Language_id
                          select new
                          {
                              language = b.Language1
                          })

            .GroupBy(q => q)
            .OrderByDescending(gp => gp.Count())
            .Take(1)
            .Select(g => g.Key).ToList();



            return Json(result, JsonRequestBehavior.AllowGet);


        }

    }
}