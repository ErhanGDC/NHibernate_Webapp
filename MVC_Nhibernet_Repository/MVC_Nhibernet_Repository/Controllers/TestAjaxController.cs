using MVC_Nhibernet_Repository.DAL;
using MVC_Nhibernet_Repository.Models;
using System;
using System.Web.Mvc;

namespace MVC_Nhibernet_Repository.Controllers
{
    public class TestAjaxController : Controller
    {
        // GET: TestAjax
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod(int id)
        {
            using (var session=DatabaseModule.OpenSession())
            {
                var scientistResult = session.QueryOver<Scientists>().Where(x => x.ID == id).List();
                return Json(scientistResult, JsonRequestBehavior.AllowGet);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult AjaxJsonResult()
        {
            using (var session = DatabaseModule.OpenSession())
            {
                var scientistResult = session.QueryOver<Scientists>().List();
                return Json(scientistResult, JsonRequestBehavior.AllowGet);
            }
        }
    }
}