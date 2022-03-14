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
    public class CharactersListViewModel : BaseViewModel
    {

        public ObservableCollection<Character> characters { get; }

        private Character selectedCharacter;

        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set { SetProperty(ref selectedCharacter, value); }
        }

        public ICommand LoadDataCommand { private set; get; }
        public ICommand GoToDetailsCommand { private set; get; }

        public async Task LoadData()
        {
            IsBusy = true;

            List<Character> charactersList = await ApiServices.GetItems<Character>("characters");
            characters.Clear();

            foreach(Character c in charactersList)
            {
                characters.Add(c);
            }
           

            IsBusy = false;
        }

        public async Task GoToDetails()
        {
            if (selectedCharacter != null)
            {
                CharacterDetailsViewModel vm = new CharacterDetailsViewModel();
                CharacterDetailsView page = new CharacterDetailsView();

                page.BindingContext = vm;

                vm.SelectedCharacter = selectedCharacter;

                foreach(string s in selectedCharacter.occupation)
                {
                    vm.occupations.Add(s);
                }

                foreach(int i in selectedCharacter.appearance)
                {
                    vm.appearances.Add(i);
                }

                await App.Current.MainPage.Navigation.PushAsync(page);
            }
        }

        public CharactersListViewModel()
        {
            characters = new ObservableCollection<Character>();

            LoadDataCommand = new Command(async () => await LoadData());
            GoToDetailsCommand = new Command(async () => await GoToDetails());
        }


    }
}
