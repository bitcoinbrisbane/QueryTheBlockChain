using System;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class QueryResult
    {
        public DateTime RequestTime { get; private set; }

        /// <summary>
        /// Total time taken including data reader
        /// </summary>
        public TimeSpan Elapsed 
        {
            get 
            {
                return DateTime.UtcNow - this.RequestTime;
            }
        }

        /// <summary>
        /// SQL query time
        /// </summary>
        public TimeSpan ExecutionTime { get; set; }
        
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
