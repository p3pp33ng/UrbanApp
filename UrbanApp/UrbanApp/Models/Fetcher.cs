using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace UrbanApp.Models
{
    public static class Fetcher
    {
        public static SearchResult SearchForWord(string searchString)
        {
            //sending a get with the searchword
            using (var client = new HttpClient())
            {

            }
            //Getting back a response form web API.
            return new SearchResult();
        }
    }
}
