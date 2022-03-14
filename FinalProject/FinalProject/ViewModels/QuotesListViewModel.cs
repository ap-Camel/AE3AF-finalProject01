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
    public class QuotesListViewModel : BaseViewModel
    {

        public ObservableCollection<Quote> quotes { get; }

        public ICommand LoadDataCommand { private set; get; }


        public async Task LoadData()
        {
            IsBusy = true;

            List<Quote> quotesList = await ApiServices.GetItems<Quote>("quotes");
            quotes.Clear();

            foreach (Quote c in quotesList)
            {
                quotes.Add(c);
            }


            IsBusy = false;
        }

        public QuotesListViewModel()
        {
            quotes = new ObservableCollection<Quote>();

            LoadDataCommand = new Command(async () => await LoadData());
        }
        

    }
}
