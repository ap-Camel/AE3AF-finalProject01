using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeasonsListView : ContentPage
    {
        SeasonsListViewModel vm;
        public SeasonsListView()
        {
            InitializeComponent();

            vm = new SeasonsListViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await Task.Run(() => vm.GetDataCommand.Execute(null));
            vm.SelectedSeason = null;
        }
    }
}