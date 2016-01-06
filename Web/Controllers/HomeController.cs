using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration=60)]
        public ActionResult Index()
        {
            ViewBag.Title = "Query the Block Chain";
            ViewModels.HomeViewModel model = new ViewModels.HomeViewModel()
            {
                Query = "SELECT Top 100 * FROM dbo.Blocks ORDER BY TimeStamp DESC"
            };

            return View(model);
        }

        public ActionResult Help()
        {
            ViewBag.Title = "Query the Block Chain";
            return View();
        }

        public ActionResult API()
        {
            return View();
        }

        // POST api/values
        [Obsolete]
        [OutputCache(Duration = 300, VaryByParam = "query")]
        public ActionResult Query([FromBody]string query)
        {
            try
            {
                ViewModels.QueryResult results = Utilities.SQL.Execute(query);
                ViewBag.Title = "Results";
                return View(results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/values
        //[HttpPost]
        //[AcceptVerbs="GET"]
        [OutputCache(Duration = 300, VaryByParam = "query")]
        public ActionResult Bitcoin([FromBody]string query)
        {
            try
            {
                ViewModels.QueryResult results = Utilities.SQL.Execute(query);
                ViewBag.Title = "Results";
                return View(results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
