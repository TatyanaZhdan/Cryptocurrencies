using CryptoCurrencies.Model;
using CryptoLibrary;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencies.ApyLibrary
{
    public class ApiManager
    {
        private readonly NetworkManager networkManager;

        public ApiManager()
        {
            networkManager=new NetworkManager();
        }
        public List<Currency> GetCurrencies()
        {
            string json = networkManager.GetJson(CoinCapApiConfig.BaseUrl+ "/v2/assets");
            JObject currency=JObject.Parse(json);
            IList<JToken> currencies = currency["data"].Children().ToList();
            List<Currency> currencyList = new List<Currency>();
            //foreach (JToken token in currencies)
            for (int i = 0; i < 10; i++)
            
            {
                currencyList.Add(new Currency
                {
                    Id = currencies[i]["id"].ToString(),
                    Name = currencies[i]["name"].ToString(),
                    Volume = Convert.ToDouble(currencies[i]["volumeUsd24Hr"]),
                    Price = Convert.ToDouble(currencies[i]["priceUsd"]),
                    Histories=GetHistories(currencies[i]["id"].ToString())
                }) ;
            }
            return currencyList;
        }

        private List<History> GetHistories(string id)
        {
            string json = networkManager.GetJson(CoinCapApiConfig.BaseUrl + $"/v2/assets/{id}/history?interval=d1");
            JObject h = JObject.Parse(json);
            IList<JToken> histories =h["data"].Children().ToList();
            List<History> historyList = new List<History>();
       
            for (int i = 0; i < histories.Count; i++)

            {
                historyList.Add(new History
                {                  
                    Price = Convert.ToDouble(histories[i]["priceUsd"]),
                    Time = Convert.ToDateTime(histories[i]["time"])
                });
            }
            return historyList;
        }
    }
}
