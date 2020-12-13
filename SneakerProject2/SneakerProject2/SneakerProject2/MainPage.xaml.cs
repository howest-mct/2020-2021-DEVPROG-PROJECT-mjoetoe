using SneakerProject2.Models;
using SneakerProject2.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SneakerProject2
{
    public partial class MainPage : ContentPage
    {
        private List<Results2> Shoe = new List<Results2>();
        public MainPage(string filter)
        {
            InitializeComponent();

            string brand = filter;
            //kijken of er een filter is
            if(brand == "empty")
            {
                FillFrames();
            }
            else
            {
                FillFramesByBrand(filter);
            }
        }

        //Frames vullen op basis van Filter result
        private async Task FillFramesByBrand(string brand)
        {
            List<Results2> shoeData = await ShoesRepository.GetShoesByBrandAsync(brand);
            foreach (var item in shoeData)
            {
                if (item.ImgUrl == "")
                {
                    item.ImgUrl = "https://stockx-assets.imgix.net/media/New-Product-Placeholder-Default.jpg?fit=fill&bg=FFFFFF&w=700&h=500&auto=format,compress&trim=color&q=90&dpr=2&updated_at=0";
                }
                if (item.RetailPrice == "")
                {
                    item.RetailPrice = "N/A";
                }
                if (item.EstimatedMarketValue == "")
                {
                    item.EstimatedMarketValue = "N/A";
                }
            }
            //data aan itemsource binden
            Shoe = shoeData;
            lvwShoes.ItemsSource = shoeData;
        }

        private async Task FillFrames()
        {
            //Shoes2 shoe = await ShoesRepository.GetShoesAsync();
            List<Results2> shoeData = await ShoesRepository.GetShoesAsync();
            // als er lege value's zijn deze vervangen door placeholders
            foreach (var item in shoeData)
            {
                if(item.ImgUrl =="")
                {
                    item.ImgUrl = "https://stockx-assets.imgix.net/media/New-Product-Placeholder-Default.jpg?fit=fill&bg=FFFFFF&w=700&h=500&auto=format,compress&trim=color&q=90&dpr=2&updated_at=0";
                }
                if(item.RetailPrice =="")
                {
                    item.RetailPrice = "N/A";
                }
                if(item.EstimatedMarketValue =="")
                {
                    item.EstimatedMarketValue = "N/A";
                }
            }
            //data aan itemsource binden
            Shoe = shoeData;
            lvwShoes.ItemsSource = shoeData;
        }
        //naar nieuwe detailpage gaan en de info meegeven
        private void btnClickedInfo(object sender, EventArgs args)
        {
            Results2 g = (sender as Button).BindingContext as Results2;
            var DetailPage = new Views.DetailPage(g);
            Navigation.PushModalAsync(DetailPage);
        }

        //Frames vullen op basis van searchbar
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            string search = searchBar.Text;
            if (search == "")
            {
                FillFrames();
            }
            else
            {
                FillFramesByName(search);
            }
        }

        //Frames vullen op basis van searchbar
        private async Task FillFramesByName(string name)
        {
            lvwShoes.ItemsSource = null;
            List<Results2> shoeData = await ShoesRepository.GetShoesByNameAsync(name);
            foreach (var item in shoeData)
            {
                if (item.ImgUrl == "")
                {
                    item.ImgUrl = "https://stockx-assets.imgix.net/media/New-Product-Placeholder-Default.jpg?fit=fill&bg=FFFFFF&w=700&h=500&auto=format,compress&trim=color&q=90&dpr=2&updated_at=0";
                }
                if (item.RetailPrice == "")
                {
                    item.RetailPrice = "N/A";
                }
                if (item.EstimatedMarketValue == "")
                {
                    item.EstimatedMarketValue = "N/A";
                }
            }
            //data aan itemsource binden
            Shoe = shoeData;
            lvwShoes.ItemsSource = shoeData;
        }

        //Add favorite to Trello cards 
        private void AddFavorite(object sender, EventArgs e)
        {
            Results2 g = (sender as Button).BindingContext as Results2;
            addcard(g);
        }

        private async Task addcard(Results2 result)
        {
            await DisplayAlert("Alert", "You added this shoe as favorite", "OK");
            string listId = "5fd4e03623dc8d8494238fd9";
            TrelloCard newCard = new TrelloCard { name = result.Name, CardDesc = result.ImgUrl, IsClosed = false };
            await TrelloRepository.AddCardAsync(listId, newCard);
        }

        //Change page 
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            changePage();
        }

        private async Task changePage()
        {
            string action = await DisplayActionSheet("Go To Page", "Cancel", null, "filter", "favorites");
            if (action == "filter")
            {
                var filter = new Views.FilterPage();
                Navigation.PushModalAsync(filter);
            }
            if (action == "favorites")
            {

                var favorites = new Views.Favorites();
                Navigation.PushModalAsync(favorites);
            }
        }
    }
}
