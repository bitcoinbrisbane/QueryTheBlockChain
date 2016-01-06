using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class BlockChainController : Controller
    {
        // GET: BlockChain
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