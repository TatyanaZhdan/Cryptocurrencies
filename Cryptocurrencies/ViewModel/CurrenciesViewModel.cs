
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
        private ApiManager apiManager;
        private Currency selectedCurrency; 
        private Currency currency1; 
        private Currency currency2; 
        private string searchText;
        private List<Currency> cur;
        private double convertResult;


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
        public Currency Currency1
        {
            get => currency1;
            set
            {
                currency1 = value;
                NotifyOfPropertyChanged();
            }
        }
        public Currency Currency2
        {
            get => currency2;
            set
            {
                currency2 = value;
                NotifyOfPropertyChanged();
            }
        }
        public double ConvertResult
        {
            get => convertResult;
            set
            {
                convertResult = value;
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
            Currency1= new Currency();
            Currency2 = new Currency();
            ConvertResult = 0;
            ShowCurrency = new RelayCommand(obj =>
            {
                var win = new Window1(selectedCurrency);
                win.Show();
            });
            SearchCommand = new RelayCommand(obj => {
                
                Currencies = new ObservableCollection<Currency>(cur.Where(item => item.Name.Contains(SearchText) || item.Id.Contains(SearchText)));
            });
            ConvertCommand = new RelayCommand(obj => {
                ConvertResult = Currency1.Price / Currency2.Price;
            });
        }
        public ICommand ShowCurrency { get;private set; }
        public ICommand SearchCommand { get; private set; }
        public ICommand ConvertCommand { get; private set; }

    }
}
