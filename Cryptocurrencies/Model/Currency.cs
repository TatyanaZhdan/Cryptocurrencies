using CryptoCurrencies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLibrary
{
    public class Currency
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public double Price { get; set; }
        public List<History> Histories {get;set;}
        public List<Market> Markets { get;set;}
    }
}
