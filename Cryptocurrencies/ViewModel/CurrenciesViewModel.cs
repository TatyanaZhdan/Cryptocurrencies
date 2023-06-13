using CryptoCurrencies.ApyLibrary;
using CryptoLibrary;
using Shop.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencies.ViewModel
{
    public class CurrenciesViewModel : BaseNotifyPropertyChanget
    {
        ApiManager apiManager;
        public CurrenciesViewModel()
        {
            apiManager = new ApiManager();
            LoadCurrencies();
        }
        public ObservableCollection<Currency> currencies { get; set; }
        public ObservableCollection<Currency> Currencies { 
            get=>currencies;
            set {
                currencies = value;
                NotifyOfPropertyChanged();

            }
        }
        private void LoadCurrencies()
        {
            var cur=apiManager.GetCurrencies();
            Currencies = new ObservableCollection<Currency>(cur);
        }
    }
}
