using MVC_Nhibernet_Repository.DAL;
using MVC_Nhibernet_Repository.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using UIService;
using UIService.Invention;

namespace MVC_Nhibernet_Repository.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var session = DatabaseModule.OpenSession())
            {
                #region Select

                var inventionsResult = session.QueryOver<Inventions>()
                 .Where(x => x.InventionID > 0).Fetch(l => l.ScientistID).Default.List();

                //var inventionsResult = session.QueryOver<Inventions>().List();
                var scientistResult = session.QueryOver<Scientists>().List();

                DataModel dataModel = new DataModel { Invention = (List<Inventions>)inventionsResult, Scientists = (List<Scientists>)scientistResult };

                #endregion


                #region Update
                //using (var transaction = session.BeginTransaction())
                //{

                //    var record = session.QueryOver<Scientists>().Where(x => x.ID ==
                //         session.QueryOver<Scientists>().Select(
                //     Projections.Max<Scientists>(a => a.ID)).SingleOrDefault<int>()).List();

                //    List<Scientists> personel = (List<Scientists>)record;
                //    personel[0].LastName = "Gidici";
                //    personel[0].Title = "Software Developer";

                //    Scientists personelForUpdate = personel[0];

                //    session.Update(personelForUpdate);

                //    transaction.Commit();
                //}
                #endregion

                #region Delete
                //using (ITransaction transaction = session.BeginTransaction())
                //{
                //    //var record = session.QueryOver<Personel>().OrderBy(u => u.Id).Desc.SingleOrDefault();

                //    var record = session.QueryOver<Scientists>().Where(x => x.ID ==
                //        session.QueryOver<Scientists>().Select(
                //    Projections.Max<Scientists>(a => a.ID)).SingleOrDefault<int>()).List(); //Getting last Record

                //    List<Scientists> personel = (List<Scientists>)record;

                //    session.Delete(personel[0]);
                //    transaction.Commit();
                //}
                #endregion

                return View(dataModel);
            }
        }

        [HttpPost]
        public ActionResult About(Inventions _dataModel)
        {
            #region Insert
            using (var session = DatabaseModule.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    Inventions inventionsEntities = new Inventions { InventionID = _dataModel.InventionID, ScientistID = _dataModel.ScientistID };
                    session.Save(inventionsEntities);
                    tran.Commit();

                    return View();
                }
            }
            #endregion
        }

        public ActionResult About()
        {
            using (var session = DatabaseModule.OpenSession())
            {
                #region Select
                var inventionsResult = session.QueryOver<Inventions>().List();
                var scientistResult = session.QueryOver<Scientists>().List();
                DataModel dataModel = new DataModel { Invention = (List<Inventions>)inventionsResult, Scientists = (List<Scientists>)scientistResult };
                #endregion

                return View(dataModel);
            }
        }

        public ActionResult Contact()
        {
            using (var session = DatabaseModule.OpenSession())
            {
                #region Select
                var inventionsResult = session.QueryOver<Inventions>().List();
                var scientistResult = session.QueryOver<Scientists>().List();
                DataModel dataModel = new DataModel { Invention = (List<Inventions>)inventionsResult, Scientists = (List<Scientists>)scientistResult };
                #endregion

                return View(dataModel);
            }
        }

        [HttpPost]
        public ActionResult Contact(Invention _invention)
        {
            #region Insert
            using (var session = DatabaseModule.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    if (_invention.Description != null || _invention.ScientistID != null)
                    {
                        Inventions inventions = new Inventions { ScientistID = _invention.ScientistID, Description = _invention.Description.ToString() };
                        session.Save(inventions);
                        tran.Commit();
                    }
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
                return Json(scientistResult, JsonRequestBehavior.AllowGet);
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
        public JsonResult DeleteInvention(DeleteInventionRequest request)
        {
            var response = new DeleteInventionRespose() { Result = false };

            using (var session = DatabaseModule.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    if (request.Id > 0)
                    {
                        var inventionsForDelete = session.Get<Inventions>(request.Id);
                        session.Delete(inventionsForDelete);
                        tran.Commit();
                        response.Result = true;
                        response.ResultMessage = "Deleted succesfully"; // TODO : Make dynamic and localized
                    }
                    return Json(response);
                }
            }
        }

        [HttpPost]
        public JsonResult UpdateInvention(Inventions _invention)
        {
            var response = new UpdateInventionResponse() { Result = false };
            #region Update
            using (var session = DatabaseModule.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    if (!string.IsNullOrEmpty(_invention.Description.ToString().Trim()) || _invention.ScientistID.ID > 0)
                    {
                        session.Update(_invention); //Update
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