using System.Collections;
using System.Collections.Generic;
using MVC_Nhibernet_Repository.DAL;
using NHibernate;
using System.Linq;
using System.Web.Mvc;
using MVC_Nhibernet_Repository.Models;
using NHibernate.Util;
using UIService;

namespace MVC_Nhibernet_Repository.Controllers
{
    public class ScientistController : Controller
    {
        // GET: Scientist
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Scientists dataModel)
        {
            #region Insert
            using (var session = DatabaseModule.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    Scientists scientistEntities = new Scientists { FirstName = dataModel.FirstName, LastName = dataModel.LastName, Title = dataModel.Title };
                    session.Save(scientistEntities);
                    tran.Commit();

                    return View();
                }
            }
            #endregion
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetScientists()
        {
            using (var session = DatabaseModule.OpenSession())
            {
                var scientistResult = session.QueryOver<Scientists>().List();
                return Json(scientistResult.OrderByDescending(a => a.ID), JsonRequestBehavior.AllowGet);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetInventions()
        {
            using (var session = DatabaseModule.OpenSession())
            {
                //var inventionsResult = session.QueryOver<Inventions>()
                // .Where(x => x.InventionID > 0).Fetch(l => l.ScientistID).Default.List();

                var inventionsResult = session.QueryOver<Inventions>().List();
                return Json(inventionsResult, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteScientist(DeleteScientistRequest request)
        {
            var response = new DeleteScientistResponse
            {
                Result = false
            };

            using (var session = DatabaseModule.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    if (request.Id > 0)
                    {
                        var scientistForDelete = session.Get<Scientists>(request.Id);

                        var invention = session.QueryOver<Inventions>()
                               .Where(x => x.ScientistID.ID == scientistForDelete.ID).List().FirstOrDefault();

                        if (invention != null)
                        {
                            response.Result = false;
                            response.ResultMessage =
                            scientistForDelete.FirstName + " has an invention, Please delete " + invention.Description + " invention firstly."; // TODO : Make dynamic and localized 
                        }
                        else
                        {
                            session.Delete(scientistForDelete);
                            tran.Commit();
                            response.Result = true;
                            response.ResultMessage = "Deleted succesfully"; // TODO : Make dynamic and localized
                        }
                    }

                    return Json(response);
                }
            }
        }

        [HttpPost]
        public JsonResult UpdateScientist(Scientists _scientists)
        {
            var response = new UpdateScientistResponse()
            {
                Result = false
            };
            #region Update
            using (var session = DatabaseModule.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    if (!string.IsNullOrEmpty(_scientists.FirstName.ToString().Trim()) && !string.IsNullOrEmpty(_scientists.LastName.ToString().Trim()))
                    {
                        session.Update(_scientists); //Update
                        tran.Commit();
                        response.Result = true;
                        response.ResultMessage = "Updated succesfully"; // TODO : Make dynamic and localized
                    }
                }
            }
            return Json(response);
            #endregion
        }
    }
}