using System;
using System.Linq;
using System.Windows.Input;
using PuppyGo.Models.Petfinder;
using Xamarin.Forms;

namespace PuppyGo.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {

        public Animal Animal { get; set; }

        public string Photo { get; set; }

        public ItemDetailViewModel(Animal animal = null)
        {
            Animal = animal;
            Photo = animal?.photos.FirstOrDefault(x => !string.IsNullOrEmpty(x.full))?.full;
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri(Animal.url)));
        }

        public ICommand OpenWebCommand { get; }

    }
}
