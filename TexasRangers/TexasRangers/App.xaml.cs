using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TexasRangers.Data;
using System.IO;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

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
            AppCenter.Start("android=2c0ff759-e8f2-4953-8020-8d0b804988df;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
