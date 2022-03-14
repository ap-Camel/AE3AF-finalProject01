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
    public class CharacterDetailsViewModel : BaseViewModel
    {
        public ObservableCollection<String> occupations { get; }
        public ObservableCollection<int> appearances { get; }

        private Character selectedCharacter;

        public ICommand SaveCommand { private set; get; }
        public ICommand DeleteCommand { private set; get; }
        public ICommand ClearCommand { private set; get; }
        public ICommand ShareCommand { private set; get; }


        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set { SetProperty(ref selectedCharacter, value); }
        }

        private async Task Save()
        {
            FavCharacter character = new FavCharacter();

            List<FavCharacter> list = new List<FavCharacter>();
            list = await App.DbContext.GetItems<FavCharacter>();

            bool check = false;

            character.char_id = selectedCharacter.char_id;
            character.name = selectedCharacter.name;
            character.nickname = selectedCharacter.nickname;
            character.img = selectedCharacter.img;
            character.portrayed = selectedCharacter.portrayed;
            character.status = selectedCharacter.status;
            character.birthday = selectedCharacter.birthday;

            foreach(FavCharacter fc in list)
            {
                if(fc.char_id == character.char_id) { check = true; }
            }

            bool op = false;

            if (!check)
            {
                op = await App.DbContext.AddItem<FavCharacter>(character);
            }

            if (op)
            {
                await App.Current.MainPage.DisplayAlert("Success!", "Character was added to favourits", "Ok");
            }
            else
                await App.Current.MainPage.DisplayAlert("Error!", "character is already favourited", "Ok");
        }

        public async Task ShareText()
        {

            string text = $" In Breaking bad, I like the character named {selectedCharacter.name}";
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "Share Text"
            });
        }


        public CharacterDetailsViewModel()
        {
            occupations = new ObservableCollection<string>();
            appearances = new ObservableCollection<int>();

            SaveCommand = new Command(async () => await Save());
            ShareCommand = new Command(async () => await ShareText());
        }
    }
}
