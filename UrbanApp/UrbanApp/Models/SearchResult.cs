using System;
using System.Collections.Generic;
using System.Text;

namespace UrbanApp.Models
{
    public class SearchResult
    {
        public string[] tags { get; set; }
        public string result_type { get; set; }
        public List<Result> list { get; set; }
        public object[] sounds { get; set; }
        public string ErrorText { get; set; }
    }
}
