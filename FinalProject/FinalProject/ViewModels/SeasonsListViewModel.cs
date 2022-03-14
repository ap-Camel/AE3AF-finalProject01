using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Essentials;

using FinalProject.Models;
using FinalProject.Services;
using FinalProject.Views;

namespace FinalProject.ViewModels
{
    class SeasonsListViewModel : BaseViewModel
    {

        public ObservableCollection<Season> seasons { get; }

        private Season selectedSeason;

        public Season SelectedSeason
        {
            get { return selectedSeason; }
            set { SetProperty(ref selectedSeason, value); }
        }

        public ICommand GetDataCommand { private set; get; }
        public ICommand GoToDetailsCommand { private set; get; }

        public async Task GetData()
        {
            IsBusy = true;

            List<Season> seasonsList = CustomServices.GetSeasons();
            seasons.Clear();

            foreach(Season s in seasonsList)
            {
                seasons.Add(s);
            }

            IsBusy = false;
        }

        public async Task GoToDetails()
        {
            if (selectedSeason != null)
            {
                EpisodesListViewModel vm = new EpisodesListViewModel();
                EpisodesListView page = new EpisodesListView();

                page.BindingContext = vm;

                vm.SelectedSeason = selectedSeason;
                await Task.Run(() => vm.LoadDataCommand.Execute(null));


                await App.Current.MainPage.Navigation.PushAsync(page);
            }
        }

        public SeasonsListViewModel()
        {
            seasons = new ObservableCollection<Season>();

            GetDataCommand = new Command(async () => await GetData());
            GoToDetailsCommand = new Command(async () => await GoToDetails());
        }

    }
}
