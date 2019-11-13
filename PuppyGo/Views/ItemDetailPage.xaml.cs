using System.ComponentModel;
using Xamarin.Forms;
using PuppyGo.ViewModels;

namespace PuppyGo.Views
{

    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {

            InitializeComponent();

            BindingContext = viewModel;

        }

    }

}