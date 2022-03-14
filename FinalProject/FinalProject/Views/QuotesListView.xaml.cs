using FinalProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotesListView : ContentPage
    {
        QuotesListViewModel vm;
        public QuotesListView()
        {
            InitializeComponent();

            vm = new QuotesListViewModel();

            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (vm.quotes.Count == 0)
            {
                await Task.Run(() => vm.LoadDataCommand.Execute(null));
            }
        }
    }
}