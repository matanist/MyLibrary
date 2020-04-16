using MyLibrary.Areas.Admin.Data;
using System.Linq;
using System.Web.Mvc;

namespace MyLibrary.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if(Session["OturumID"] != null)
            {
                return View();
            }
            else
            {
                Response.Redirect("/");
                return Json("0");
            }
        }
        public ActionResult BookListPage()
        {
            if(Session["OturumID"] != null)
            {
                InsertEntities db = new InsertEntities();
                var sıralı = db.Books.ToList();
                var sıralı2 = sıralı.OrderByDescending(x=>x.Book_id);
                return View(sıralı2);
            }
            Response.Redirect("/");
            return Json("0");
        }

        public ActionResult Other()
        {
            
            return View();
        }
    }
}