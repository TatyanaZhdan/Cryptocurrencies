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
            for (int i = 0; i < currencies.Count; i++)
            
            {
                currencyList.Add(new Currency
                {
                    Id = currencies[i]["id"].ToString(),
                    Rank=Convert.ToInt32(currencies[i]["rank"]),
                    Name = currencies[i]["name"].ToString(),
                    Volume = Convert.ToDouble(currencies[i]["volumeUsd24Hr"]),
                    Price = Convert.ToDouble(currencies[i]["priceUsd"]),
                    //Histories=GetHistories(currencies[i]["id"].ToString()),
                    //Markets=GetMerkets(currencies[i]["id"].ToString())
                }) ;
            }
            return currencyList;
        }

        private List<Market> GetMerkets(string id)
        {
            string json = networkManager.GetJson(CoinCapApiConfig.BaseUrl + $"/v2/assets/{id}/markets");
            JObject mark = JObject.Parse(json);
            IList<JToken> markets = mark["data"].Children().ToList();
            List<Market> marketList = new List<Market>();
            for (int i = 0; i < markets.Count; i++)
            {
                


                marketList.Add(new Market
                {
                    ExchangeId = markets[i]["exchangeId"].ToString(),
                    Price = Convert.ToDouble(markets[i]["priceUsd"])                   
                }); 
            }
            return marketList;
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
                    Time = histories[i]["time"].ToString()
                });
            }
            return historyList;
        }
    }
}
