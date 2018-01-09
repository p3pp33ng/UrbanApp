using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UrbanApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrbanNavigationPageMaster : ContentPage
    {
        public ListView ListView;

        public UrbanNavigationPageMaster()
        {
            InitializeComponent();

            BindingContext = new UrbanNavigationPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class UrbanNavigationPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<UrbanNavigationPageMenuItem> MenuItems { get; set; }
            
            public UrbanNavigationPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<UrbanNavigationPageMenuItem>(new[]
                {
                    new UrbanNavigationPageMenuItem { Id = 0, Title = "Page 1" },
                    new UrbanNavigationPageMenuItem { Id = 1, Title = "Page 2" },
                    new UrbanNavigationPageMenuItem { Id = 2, Title = "Page 3" },
                    new UrbanNavigationPageMenuItem { Id = 3, Title = "Page 4" },
                    new UrbanNavigationPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}