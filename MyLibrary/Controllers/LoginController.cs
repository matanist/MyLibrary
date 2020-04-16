using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLibrary.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login       
        public ActionResult Index()
        {
            Session["OturumID"] = null;
            return View();
            
        }

        MyLibraryDatabaseEntities db = new MyLibraryDatabaseEntities();
        [HttpPost]
        
        public JsonResult Index(GirisModel girisYap)
        {
            if (db.UsersAccounts.Where(x => x.user_account_name == girisYap.KADI).FirstOrDefault() != null)
            {
                if (db.UsersAccounts.Where(x => x.user_account_name == girisYap.KADI).FirstOrDefault().user_passwd == girisYap.PASS)
                {
                    var sessionAl = db.UsersAccounts.Where(x => x.user_account_name == girisYap.KADI).FirstOrDefault().user_id;
                    Session["OturumID"] = sessionAl;
                    return Json("1");
                    
                }
                else
                return Json("2");

            }
            return Json("2");

        }

    }
}    