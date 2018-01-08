using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UrbanApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
        private Label welcome;
		public SearchPage (SearchResult result = null)
		{
            var layout = new StackLayout();

            layout.Children.Add(welcome = new Label
            {
                Text = "HEJ",
                FontSize = 32
            });
			
		}
	}
}