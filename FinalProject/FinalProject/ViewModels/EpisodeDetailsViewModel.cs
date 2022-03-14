using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FinalProject.ViewModels
{
    public class EpisodeDetailsViewModel : BaseViewModel
    {

        public ObservableCollection<string> characters { get; }

        private Episode selectedEpisode;

        public Episode SelectedEpisode
        {
            get { return selectedEpisode; }
            set { SetProperty(ref selectedEpisode, value); }
        }

        public ICommand SaveCommand { private set; get; }
        public ICommand ShareCommand { private set; get; }

        private async Task Save()
        {
            FavEpisode episode = new FavEpisode();

            List<FavEpisode> list = new List<FavEpisode>();
            list = await App.DbContext.GetItems<FavEpisode>();

            bool check = false;

            episode.episode = selectedEpisode.episode;
            episode.air_date = selectedEpisode.air_date;
            episode.season = selectedEpisode.season;
            episode.episode_id = selectedEpisode.episode_id;
            episode.title = selectedEpisode.title;
            episode.series = selectedEpisode.series;
            episode.imgUrl = selectedEpisode.imgUrl;

            foreach(FavEpisode fe in list)
            {
                if(fe.episode_id == episode.episode_id)
                {
                    check = true;
                }
            }

            bool op = false;

            if (!check)
            {
                op = await App.DbContext.AddItem<FavEpisode>(episode);
            }

            if (op)
            {
                await App.Current.MainPage.DisplayAlert("Success!", "The episode was added to favourits", "Ok");
            }
            else
                await App.Current.MainPage.DisplayAlert("Error!", "The episode is already favourited", "Ok");
        }

        public async Task ShareText()
        {

            string text = $" in Breaking bad, I like episode {selectedEpisode.episode}\n" +
                $"in season {selectedEpisode.season}";
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "Share Text"
            });
        }

        public EpisodeDetailsViewModel()
        {
            characters = new ObservableCollection<string>();

            SaveCommand = new Command(async () => await Save());
            ShareCommand = new Command(async () => await ShareText());
        }


    }
}
