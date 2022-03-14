using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FinalProject.ViewModels;

namespace FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavEpisodeView : ContentPage
    {
        FavEpisodesListViewModel vm;
        public FavEpisodeView()
        {
            InitializeComponent();

            vm = new FavEpisodesListViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await Task.Run(() => vm.LoadDataCommand.Execute(null));
        }
    }
}