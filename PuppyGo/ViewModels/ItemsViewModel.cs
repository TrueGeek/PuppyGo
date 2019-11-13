using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using PuppyGo.Resources;
using Xamarin.Forms;

namespace PuppyGo.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {

        public ObservableCollection<Models.Petfinder.Animal> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Items = new ObservableCollection<Models.Petfinder.Animal>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {

            if (IsBusy) return;

            IsBusy = true;

            try
            {

                Items.Clear();

                var items = await new Services.PetFinderService().GetDogs();

                foreach (var item in items)
                {
                    Items.Add(item);
                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);

            }
            finally
            {

                IsBusy = false;

            }

        }
    }
}