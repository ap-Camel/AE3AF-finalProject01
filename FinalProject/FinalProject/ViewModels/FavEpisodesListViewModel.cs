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
    public class FavEpisodesListViewModel : BaseViewModel
    {

        public ObservableCollection<FavEpisode> favEpisodes { get; }

        private FavEpisode selectedEpisode;

        public FavEpisode SelectedEpisode
        {
            get { return selectedEpisode; }
            set { SetProperty(ref selectedEpisode, value); }
        }


        public ICommand LoadDataCommand { private set; get; }
        public ICommand DeleteCommand { private set; get; }

        private async Task LoadData()
        {
            List<FavEpisode> episodes = await App.DbContext.GetItems<FavEpisode>();

            favEpisodes.Clear();

            foreach (FavEpisode e in episodes)
            {
                favEpisodes.Add(e);
            }
        }

        private async Task Delete()
        {
            if (selectedEpisode != null)
            {
                bool op = await App.Current.MainPage.DisplayAlert("delete item", "Do you want to delete item from favourites?", "Yes", "no");

                if (op)
                {
                    op = await App.DbContext.DeleteItem<FavEpisode>(selectedEpisode);
                    

                    if (op)
                    {
                        await LoadData();
                        await App.Current.MainPage.DisplayAlert("Success!", "The Item was erased successfully", "Ok");
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Error!", "The Item was not deleted. Check your data", "Ok");
                }
            }
        }

        public FavEpisodesListViewModel()
        {
            favEpisodes = new ObservableCollection<FavEpisode>();

            LoadDataCommand = new Command(async () => await LoadData());
            DeleteCommand = new Command(async () => await Delete());
        }

    }
}
