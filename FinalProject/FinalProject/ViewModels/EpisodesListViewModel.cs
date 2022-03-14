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
    public class EpisodesListViewModel : BaseViewModel
    {

        public ObservableCollection<Episode> episodes { get; }

        private Episode selectedEpisode;

        public Episode SelectedEpisode
        {
            get { return selectedEpisode; }
            set { SetProperty(ref selectedEpisode, value); }
        }

        private Season selectedSeason;

        public Season SelectedSeason
        {
            get { return selectedSeason; }
            set { SetProperty(ref selectedSeason, value); }
        }

        public ICommand LoadDataCommand { private set; get; }
        public ICommand GoToDetailsCommand { private set; get; }

        public async Task LoadData()
        {
            IsBusy = true;

            List<Episode> episodesList = await ApiServices.GetItems<Episode>("episodes");
            episodes.Clear();

            foreach (Episode e in episodesList)
            {
                if(e.season == selectedSeason.id.ToString() && e.series != "Better Call Saul")
                {
                    e.imgUrl = selectedSeason.imgUrl;
                    episodes.Add(e);
                }
            }

            IsBusy = false;
        }

        public async Task GoToDetails()
        {
            if (selectedEpisode != null)
            {
                EpisodeDetailsViewModel vm = new EpisodeDetailsViewModel();
                EpisodeDetailsView page = new EpisodeDetailsView();

                page.BindingContext = vm;

                vm.SelectedEpisode = selectedEpisode;
                vm.SelectedEpisode.imgUrl = selectedSeason.imgUrl;

                foreach (string s in selectedEpisode.characters)
                {
                    vm.characters.Add(s);
                }                

                await App.Current.MainPage.Navigation.PushAsync(page);
            }
        }

        public EpisodesListViewModel()
        {
            episodes = new ObservableCollection<Episode>();

            LoadDataCommand = new Command(async () => await LoadData());
            GoToDetailsCommand = new Command(async () => await GoToDetails());
        }



    }
}
