using System;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class QueryResult
    {
        public DateTime RequestTime { get; private set; }
        public TimeSpan Elapsed 
        {
            get 
            {
                return DateTime.UtcNow - this.RequestTime;
            }
        }
        
        public IList<String> Rows { get; set; }

        public IList<String> Columns { get; set; }

        public QueryResult()
        {
            this.Rows = new List<string>();
            this.Columns = new List<string>();
            this.RequestTime = DateTime.UtcNow;
        }
    }
}
