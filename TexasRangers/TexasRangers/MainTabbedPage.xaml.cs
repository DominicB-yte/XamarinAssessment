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
        private List<ChuckNorris> ChuckNorris;
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
    }
}