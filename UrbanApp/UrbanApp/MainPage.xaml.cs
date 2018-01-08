using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanApp.Models;
using Xamarin.Forms;

namespace UrbanApp
{
	public partial class MainPage : ContentPage
	{
        private Label textLabel;
        private Button searchButton;
        private Entry searchEntry;
        private Label errorText;
        public string searchWord;

        public MainPage()
		{
            var layout = new StackLayout();

            layout.Children.Add(textLabel = new Label
            {
                Text = "Search the urban slang you want to know more about."
            });

            layout.Children.Add(searchEntry = new Entry
            {
                Text = "Enter urban word here..."
            });

            layout.Children.Add(searchButton = new Button
            {
                Text = "Search"
            });

            layout.Children.Add(errorText = new Label
            {
                Text = "",
                TextColor = Color.Red,
                IsVisible = false
            });

            searchButton.Clicked += SearchClick;

            Content = layout;
		}

        private async void SearchClick(object sender, EventArgs e)
        {
            //Validating so it there is no empty string coming in.
            if (!string.IsNullOrEmpty(searchEntry.Text))
            {
                errorText.IsVisible = false;
                var result = Fetcher.SearchForWord(searchEntry.Text);
                SearchPage searchPage = new SearchPage(result);
                await Navigation.PushAsync(searchPage);
            }
            else
            {
                errorText.IsVisible = true;
                errorText.Text = "Something is wrong with the search text.";
            }
        }
    }
}
