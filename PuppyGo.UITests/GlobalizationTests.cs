using System.Collections;
using System.Globalization;
using System.Resources;
using NUnit.Framework;

namespace PuppyGo.UITests
{

    [TestFixture]
    public class GlobalizationTests
    {

        [Test]
        public void AppResourcesFilesHaveSameNumberOfSets()
        {

            // get LPA's Resource Manager
            var resourceManager = new PuppyGo.Resources.ResourcesTestHelper().GetResourceManager();

            var countEnglishResources = this.GetCountOfResourcesInResoureSet(resourceManager, "en-US");
            var countGermanResources = this.GetCountOfResourcesInResoureSet(resourceManager, "de");

            Assert.AreEqual(countEnglishResources, countGermanResources);

        }

        private int GetCountOfResourcesInResoureSet(ResourceManager resourceManager, string cultureName)
        {

            // for some reason this won't work until we use the
            // Resource Manager once for the requested culture
            var valueOfOkayInFrench = resourceManager.GetString("tabs_browse", CultureInfo.GetCultureInfo(cultureName));

            // get the requested set
            var resourceSet = resourceManager.GetResourceSet(
                CultureInfo.GetCultureInfo(cultureName),
                false,
                true);

            // if there wasn't a set then it's easy to count
            if (resourceSet == null) return 0;

            // count up all the values in the set
            var count = 0;
            foreach (DictionaryEntry resourceValue in resourceSet)
            {
                count++;
            }

            return count;

        }

    }

}
