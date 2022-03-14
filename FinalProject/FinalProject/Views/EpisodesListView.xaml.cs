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
    public partial class EpisodesListView : ContentPage
    {

        EpisodesListViewModel vm;
        public EpisodesListView()
        {
            InitializeComponent();

            vm = new EpisodesListViewModel();
        }

        protected async override void OnAppearing()
        {            
            vm.SelectedEpisode = null;
        }
    }
}