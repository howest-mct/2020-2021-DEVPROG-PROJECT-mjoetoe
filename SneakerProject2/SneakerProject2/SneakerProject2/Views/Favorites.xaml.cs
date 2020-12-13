using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SneakerProject2.Models;
using SneakerProject2.Repositories;

namespace SneakerProject2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favorites : ContentPage
    {
        public Favorites()
        {
            InitializeComponent();
            getlists(lvwTrelloLists);
        }

        private void lvwTrelloLists_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            NavigateToShoePage();
        }

        private async Task NavigateToShoePage()
        {
            TrelloCard card = (TrelloCard)lvwTrelloLists.SelectedItem;
            List<Results2> shoeData = await ShoesRepository.GetShoesByNameAsync(card.name);
            Results2 shoe = shoeData[0];
            var DetailPage = new Views.DetailPage(shoe);
            Navigation.PushModalAsync(DetailPage);
        }

        //fill the listview with favorite shoes from trello API
        private async Task getlists(Xamarin.Forms.ListView lvw)
        {
            lvw.ItemsSource = "";

            string listId = "5fd4e03623dc8d8494238fd9";
            List<TrelloCard> trelloCards = await TrelloRepository.GetTrelloCardAsync(listId);
            lvw.ItemsSource = await TrelloRepository.GetTrelloCardAsync(listId);

        }

        //delete shoe out favorites
        private void Btn_DeleteCard(object sender, EventArgs e)
        {
            TrelloCard card = (sender as Button).BindingContext as TrelloCard;
            DeleteCard(card);
        }

        private async Task DeleteCard(TrelloCard e)
        {
            bool answer = await DisplayAlert("Are you sure?", "Would you like to delete this shoe as favorite ?", "Yes", "No");
            if (answer == true)
            {
                await TrelloRepository.DeleteCardAsync(e.CardId);
                getlists(lvwTrelloLists);
            }
        }

        //Change page 
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            changePage();
        }

        private async Task changePage()
        {
            string action = await DisplayActionSheet("Go To Page", "Cancel", null, "filter", "home");
            if (action == "filter")
            {
                var filter = new Views.FilterPage();
                Navigation.PushModalAsync(filter);
            }
            if (action == "home")
            {
                var home = new MainPage("empty");
                Navigation.PushModalAsync(home);
            }
        }
    }
}