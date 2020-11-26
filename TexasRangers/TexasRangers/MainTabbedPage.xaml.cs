using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TexasRangers.Model;
using RestSharp;
using Newtonsoft.Json;

namespace TexasRangers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPage : TabbedPage
    {
        private RestClient client;
        public MainTabbedPage()
        {
            InitializeComponent();

            this.BindingContext = GetJokes();
        }
        
        private async void btnFood_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FoodsPage());
        }

        private async void btnDrinks_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DrinksPage());
        }

        private ChuckNorris GetJokes()
        {
            ChuckNorris chuck;
            client = new RestClient("https://api.chucknorris.io/jokes/random");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            chuck = JsonConvert.DeserializeObject<ChuckNorris>(response.Content);

            return chuck;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnReserveAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReservationPage
            {
                BindingContext = new Reservations()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ReservationPage
                {
                    BindingContext = e.SelectedItem as Reservations
                });
            }
        }
    }
}