using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace UrbanApp.Models
{
    public class Fetcher
    {
        public async Task<SearchResult> SearchForWord(string searchString)
        {
            SearchResult result = new SearchResult();
            //sending a http get with the searchword
            using (var client = SetUpClientWithAuth())
            {                
                HttpResponseMessage response = await client.GetAsync($"https://mashape-community-urban-dictionary.p.mashape.com/define?term={searchString}");
                if (response.IsSuccessStatusCode)
                {                    
                    result = JsonConvert.DeserializeObject<SearchResult>(await response.Content.ReadAsStringAsync());
                }
            }
            //Getting back a response form web API.
            return result;
        }

        private HttpClient SetUpClientWithAuth()
        {
            HttpClient client = new HttpClient();            

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-Mashape-Key", "wr9b0MEpR7mshVmgmNfPaDonplcDp1NjFpJjsnJInOBypL5TxS");
            client.DefaultRequestHeaders.Add("Accept", "text/plain");
            return client;
        }
    }
}
