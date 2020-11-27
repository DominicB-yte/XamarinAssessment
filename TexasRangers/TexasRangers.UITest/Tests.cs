using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TexasRangers.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void TextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("© 2020 Texas Rangers LLC"));
            app.Screenshot("Screenshot1");

            Assert.IsTrue(results.Any());
        }
    }
}
