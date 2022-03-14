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
    public class FavListViewModel : BaseViewModel
    {

        public ObservableCollection<FavCharacter> favCaracters { get; }

        private FavCharacter selectedCharacter;

        public FavCharacter SelectedCharacter
        {
            get { return selectedCharacter; }
            set { SetProperty(ref selectedCharacter, value); }
        }


        public ICommand LoadDataCommand { private set; get; }
        public ICommand DeleteCommand { private set; get; }

        private async Task LoadData()
        {
            List<FavCharacter> characters = await App.DbContext.GetItems<FavCharacter>();

            favCaracters.Clear();

            foreach (FavCharacter c in characters)
            {
                favCaracters.Add(c);
            }
        }

        private async Task Delete()
        {
            if (SelectedCharacter != null)
            {
                bool op = await App.Current.MainPage.DisplayAlert("delete item", "Do you want to delete item from favourites?", "Yes", "no");

                if (op)
                {
                    op = await App.DbContext.DeleteItem<FavCharacter>(selectedCharacter);


                    if (op)
                    {
                        await LoadData();
                        await App.Current.MainPage.DisplayAlert("Success!", "The item was erased successfully", "Ok");
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Error!", "The item was not deleted. Check your data", "Ok");
                }
            }
        }

        public FavListViewModel()
        {
            favCaracters = new ObservableCollection<FavCharacter>();

            LoadDataCommand = new Command(async () => await LoadData());
            DeleteCommand = new Command(async () => await Delete());
        }

    }
}
