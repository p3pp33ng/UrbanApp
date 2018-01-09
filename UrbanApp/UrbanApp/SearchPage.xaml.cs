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
        private Label errorText;
        private Label searchWord;
        private ListView searchResultList;
        public SearchPage(SearchResult result = null, string searchString = null)
        {
            var layout = new StackLayout();

            layout.Children.Add(searchWord = new Label
            {
                Text = searchString,
                FontSize = 32
            });

            layout.Children.Add(errorText = new Label
            {
                Text = "This word has no meaning, its rubbish...",
                TextColor = Color.Red,
                IsVisible = false
            });

            if (result.result_type != "no_results")
            {
                errorText.IsVisible = false;

                layout.Children.Add(searchResultList = new ListView
                {
                    ItemsSource = result.list.Take(5),
                    HasUnevenRows = true,
                    ItemTemplate = new DataTemplate(() =>
                    {
                        Label definition = new Label();
                        definition.FontSize = 12;
                        definition.FontAttributes = FontAttributes.Bold;
                        definition.SetBinding(Label.TextProperty, "definition");

                        Label example = new Label();
                        example.FontSize = 10;
                        example.FontAttributes = FontAttributes.Italic;
                        example.SetBinding(Label.TextProperty, "example");

                        Label author = new Label();
                        author.FontSize = 8;
                        author.SetBinding(Label.TextProperty, "author");

                        return new ViewCell
                        {
                            View = new StackLayout
                            {
                                Padding = new Thickness(0, 5, 0, 5),
                                Orientation = StackOrientation.Horizontal,
                                Children =
                            {
                                new StackLayout
                                {
                                    VerticalOptions = LayoutOptions.Center,
                                    Spacing = 0,
                                    Padding = new Thickness(0,5,0,5),
                                    Children =
                                    {
                                        definition,
                                        example,
                                        author
                                    }
                                }
                            }
                            }
                        };
                    })
                });
            }
            else
            {
                errorText.IsVisible = true;
            }
            Content = layout;
        }
    }
}