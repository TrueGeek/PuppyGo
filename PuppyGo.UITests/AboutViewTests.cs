using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace PuppyGo.UITests
{

    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class AboutViewTests
    {

        IApp app;
        Platform platform;

        public AboutViewTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {

            // go to about page
            app.Tap("AboutTab");

            // get text of label on about page
            var versionLabelText = app.Query("VersionLabel").FirstOrDefault().Text;

            // take a screen shot while we're here
            app.Screenshot("About Page");

            // Assert
            Assert.AreEqual(versionLabelText, "PuppyGo 1.0");
        }

    }

}
