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
        Fetcher fetcher = new Fetcher();

        public MainPage()
        {
            var layout = new StackLayout();

            layout.Children.Add(textLabel = new Label
            {
                Text = "Search the urban slang you want to know more about."
            });

            layout.Children.Add(searchEntry = new Entry
            {
                Placeholder = "Enter urban word here..."
            });

            layout.Children.Add(searchButton = new Button
            {
                Text = "Search"
            });

            layout.Children.Add(errorText = new Label
            {
                Text = "Something is wrong with the search text.",
                TextColor = Color.Red,
                IsVisible = false
            });

            searchButton.Clicked += SearchClick;

            Content = layout;
        }

        private async void SearchClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(searchEntry.Text))
            {
                errorText.IsVisible = false;
                var result = fetcher.SearchForWord(searchEntry.Text);
                SearchPage searchPage = new SearchPage(await result, searchEntry.Text);
                await Navigation.PushAsync(searchPage);
            }
            else
            {
                errorText.IsVisible = true;
            }
        }
    }
}
