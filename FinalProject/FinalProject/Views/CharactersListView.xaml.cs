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
    public partial class CharactersListView : ContentPage
    {
        CharactersListViewModel vm;

        public CharactersListView()
        {
            InitializeComponent();

            vm = new CharactersListViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            if (vm.characters.Count == 0)
            {
                base.OnAppearing();

                await Task.Run(() => vm.LoadDataCommand.Execute(null));
            }
            vm.SelectedCharacter = null;
        }
    }
}