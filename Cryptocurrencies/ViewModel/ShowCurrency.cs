using CryptoCurrencies.ApyLibrary;
using CryptoCurrencies.Model;
using CryptoCurrencies.View;
using CryptoLibrary;
using Shop.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoCurrencies.ViewModel
{
    class ShowCurrency:BaseNotifyPropertyChanget
    {
        private ApiManager apiManager;
        private Currency currency;
        private ObservableCollection<History> histories;
        private ObservableCollection<Market> markets;
        private List<string> listTime;
        private string selectedTime;

        public ShowCurrency()
        {
           
        }

        public ShowCurrency(Currency currency)
        {
            apiManager = new ApiManager();
            Currency = currency;
            
            LoadHistory();
            LoadMarkets();
            
        }
        public Currency Currency
        {
            get => currency;
            set
            {
                currency = value;
                NotifyOfPropertyChanged();
            }
        }
        public ObservableCollection<History> Histories
        {
            get => histories;
            set
            {
                histories = value;
                NotifyOfPropertyChanged();
            }
        }
        public ObservableCollection<Market>Markets
        {
            get => markets;
            set
            {
                markets = value;
                NotifyOfPropertyChanged();
            }
        }
        public List<string> ListTime
        {
            get => listTime;
            set
            {
                listTime = value;
                NotifyOfPropertyChanged();
            }
        }
        public string SelectedTime
        {
            get => selectedTime;
            set
            {
                selectedTime = value;
                NotifyOfPropertyChanged();
            }
        }
        private void LoadHistory()
        {                  
            Histories = new ObservableCollection<History>(apiManager.GetHistories(currency.Id,"d1"));
        }
        private void LoadMarkets()
        {
            Markets=new ObservableCollection<Market>(apiManager.GetMerkets(currency.Id));
        }
       
    }
}
