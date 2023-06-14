
using CryptoCurrencies.ApyLibrary;
using CryptoCurrencies.View;
using CryptoLibrary;
using Shop.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CryptoCurrencies.ViewModel
{
    public class CurrenciesViewModel : BaseNotifyPropertyChanget
    {
        ApiManager apiManager;
        Currency selectedCurrency; 
        private string searchText;
        List<Currency> cur;


        public CurrenciesViewModel()
        {
            apiManager = new ApiManager();
            cur = apiManager.GetCurrencies();
            LoadCurrencies();
            InitComands();
        }
        public ObservableCollection<Currency> currencies { get; set; }
        
        public ObservableCollection<Currency> Currencies { 
            get=>currencies;
            set {
                currencies = value;
                NotifyOfPropertyChanged();

            }
        }
        public Currency SelectedCurrency
        {
            get => selectedCurrency;
            set
            {
                selectedCurrency = value;
                NotifyOfPropertyChanged();
            }
        }
        public string SearchText
        {
            get =>searchText; 
            set
            {
                searchText = value;
                NotifyOfPropertyChanged();
            }
        }
        private void LoadCurrencies()
        {
            
            Currencies = new ObservableCollection<Currency>(cur.Skip(0).Take(10));
        }
        private void InitComands()
        {
            SelectedCurrency = new Currency();
            ShowCurrency = new RelayCommand(obj =>
            {
                var win = new Window1(selectedCurrency);
                win.Show();
            });
            SearchCommand = new RelayCommand(obj => {
                
                Currencies = new ObservableCollection<Currency>(cur.Where(item => item.Name.Contains(SearchText)));
            });
        }
        public ICommand ShowCurrency { get;private set; }
        public ICommand SearchCommand { get; private set; }

    }
}
