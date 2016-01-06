using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class QueryController : ApiController
    {
        [OutputCache(Duration = 30, VaryByParam = "query")]
        public IHttpActionResult GetProduct(String query)
        {
            try
            {
                ViewModels.QueryResult results = Utilities.SQL.Execute(query);
                return Ok(results);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
