using System.ComponentModel;
using VokabelTrainerUI.ViewModels;
using Xamarin.Forms;

namespace VokabelTrainerUI.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}