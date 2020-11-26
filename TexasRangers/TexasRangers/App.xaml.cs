using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TexasRangers.Data;
using System.IO;

namespace TexasRangers
{
    public partial class App : Application
    {
        static Reservations_db database;

        public static Reservations_db Database
        {
            get
            {
                if (database == null)
                {
                    database = new Reservations_db(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Reservations.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainTabbedPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
