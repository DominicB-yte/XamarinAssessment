using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TexasRangers.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    .InstalledApp("com.companyname.texasrangers")
                    .EnableLocalScreenshots()
                    .StartApp();
            }
            else { return ConfigureApp.iOS.StartApp(); }
        }
    }
}