using CryptoLibrary;
using Shop.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencies.ViewModel
{
    class ShowCurrency:BaseNotifyPropertyChanget
    {
        Currency currency;

        public ShowCurrency()
        {
        }

        public ShowCurrency(Currency currency)
        {
            this.currency = currency;
        }
        public Currency Currency
        {
            get => Currency;
            set
            {
                Currency = value;
                NotifyOfPropertyChanged();
            }
        }
    }
}
