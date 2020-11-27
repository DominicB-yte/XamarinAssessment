using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TexasRangers.Model;

namespace TexasRangers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        public ReservationPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var reservations = (Reservations)BindingContext;
            reservations.reCreated = DateTime.UtcNow;
            await App.Database.SaveReservationAsync(reservations);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var reservations = (Reservations)BindingContext;
            await App.Database.DeleteReservationAsync(reservations);
            await Navigation.PopAsync();
        }
    }
}