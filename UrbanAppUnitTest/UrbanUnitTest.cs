using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrbanApp;
using UrbanApp.Models;

namespace UrbanAppUnitTest
{
    [TestClass]
    public class UrbanUnitTest
    {
        [TestMethod]
        public async void APIGetTest()
        {
            var fetcher = new Fetcher();
            SearchResult result = await fetcher.SearchForWord("wat");
            Assert.AreEqual(new SearchResult(), result.GetType());
        }
    }
}
