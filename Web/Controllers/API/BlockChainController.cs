using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers.API
{
    public class BlockChainController : ApiController
    {
        public ViewModels.QueryResult Get(String query)
        {
            ViewModels.QueryResult results = Utilities.SQL.Execute(query);
            return results;
        }
    }
}
