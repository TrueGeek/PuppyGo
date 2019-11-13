using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PuppyGo.Helpers
{

    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {

        private const string ResourceId = "PuppyGo.Resources.AppResources";

        public string Text { get; set; }

        private static readonly Lazy<ResourceManager> ResourceManager = new Lazy<ResourceManager>(
            () => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public object ProvideValue(IServiceProvider serviceProvider)
        {

            if (Text == null) return null;

            var translation = ResourceManager.Value.GetString(Text, CultureInfo.CurrentCulture);

            // if we weren't able to find a translation then try it again for English
            if (string.IsNullOrEmpty(translation) && CultureInfo.CurrentCulture.TwoLetterISOLanguageName != "en")
            {
                return ResourceManager.Value.GetString(Text, CultureInfo.GetCultureInfo("en-US"));
            }

            return translation;

        }

    }

}
