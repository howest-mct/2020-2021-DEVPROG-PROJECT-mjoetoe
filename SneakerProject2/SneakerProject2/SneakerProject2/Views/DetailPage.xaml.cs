using SneakerProject2.Models;
using SneakerProject2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SneakerProject2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public Results2 shoe { get; set; }
        public DetailPage(Results2 result)
        {
            InitializeComponent();
            this.shoe = result;
            ShowDetails();
        }

        private void ShowDetails()
        {
            if(shoe.ImgUrl == "")
            {
                shoe.ImgUrl = "https://stockx-assets.imgix.net/media/New-Product-Placeholder-Default.jpg?fit=fill&bg=FFFFFF&w=700&h=500&auto=format,compress&trim=color&q=90&dpr=2&updated_at=0";
            }
            PictureShoe.Source = shoe.ImgUrl;
            lblShoename.Text = shoe.Name;
            lblShoeSku.Text = shoe.Sku;
            lblShoeBrand.Text = shoe.Brand;
            lblShoeDate.Text = shoe.ReleaseDate;

            if(shoe.RetailPrice =="")
            {
                shoe.RetailPrice = "N/A";
            }
            lblShoePrice.Text = shoe.RetailPrice;

            if (shoe.EstimatedMarketValue == "")
            {
                shoe.EstimatedMarketValue = "N/A";
            }
            lblShoeResell.Text = shoe.EstimatedMarketValue;

            if(shoe.Story == "")
            {
                shoe.Story = "No story available";
                rowStory.Height = 20;
            }
            lblShoeStory.Text = shoe.Story;
        }
        //product link openen 
        private void OpenGoatLink(object sender, EventArgs e)
        {
            string url = shoe.Links;
            string slicedurl = url.Substring(1, url.Length - 2); 
            Device.OpenUri(new Uri(slicedurl));
        }
        private void AddFavorite(object sender, EventArgs e)
        {
            addcard();
        }

        private async Task addcard()
        {
            await DisplayAlert("Alert", "You added this shoe as favorite", "OK");

            string listId = "5fd4e03623dc8d8494238fd9";
            TrelloCard newCard = new TrelloCard { name = shoe.Name, CardDesc = shoe.ImgUrl, IsClosed = false };
            await TrelloRepository.AddCardAsync(listId, newCard);
        }
    }
}