using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class HomeViewModel
    {
        [Required]
        public String Query { get; set; }

        public IEnumerable<Models.Query> Queries { get; set; }

        public HomeViewModel()
        {
            Queries = new List<Models.Query>();
        }
    }
}