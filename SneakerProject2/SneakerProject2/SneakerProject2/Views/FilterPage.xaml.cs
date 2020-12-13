using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SneakerProject2.Models;
using SneakerProject2.Repositories;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SneakerProject2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        public FilterPage()
        {
            InitializeComponent();
            FillPicker();
        }

        private async Task FillPicker()
        {
            Brands brands = await ShoesRepository.GetShoeBrandsAsync();
            BrandEntry.ItemsSource = brands.Result;
        }

        private void SearchByBrand(object sender, EventArgs e)
        {
            //kijken of filter leeg is of gevuld
            string brand = "";
            try
            {
                 brand = (BrandEntry.SelectedItem).ToString();
            }
            catch (Exception)
            {

                 brand = "empty";
            }
            
            var MainPage = new MainPage(brand);
            Navigation.PushModalAsync(MainPage);
        }

        //Change page 
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            changePage();
        }

        private async Task changePage()
        {
            string action = await DisplayActionSheet("Go To Page", "Cancel", null, "home", "favorites");
            if (action == "home")
            {
                var home = new MainPage("empty");
                Navigation.PushModalAsync(home);
            }
            if (action == "favorites")
            {
                var favorites = new Views.Favorites();
                Navigation.PushModalAsync(favorites);
            }
        }
    }
}