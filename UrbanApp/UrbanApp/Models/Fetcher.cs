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
            //sending a get with the searchword
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri(Constants);
                
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization add mashape key here
                HttpResponseMessage response = await client.GetAsync($"https://mashape-community-urban-dictionary.p.mashape.com/define?term={searchString}");
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<SearchResult>(response.Content.ToString());
                }
            }
            //Getting back a response form web API.
            return result;
        }
    }
}
