using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PuppyGo.Models;
using PuppyGo.Views;
using PuppyGo.ViewModels;
using PuppyGo.Models.Petfinder;

namespace PuppyGo.Views
{

    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {

            var animal = args.SelectedItem as Animal;
            if (animal == null) return;

            this.Title = string.Empty;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(animal)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.Title = PuppyGo.Resources.AppResources.itemspage_title;

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}