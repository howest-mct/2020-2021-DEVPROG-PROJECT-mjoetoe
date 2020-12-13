using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SneakerProject2.Models;

namespace SneakerProject2.Repositories
{
    class TrelloRepository
    {
        private const string _APIKEY = "afab28e30bc925fb6e19e20ff78bce7d";
        private const string _USERTOKEN = "bba8b5173d5ee8404cbfbf0f7638d270692351333e03f6e0adc4ffe64e8f6cf3";
        private const string _BASEURI = "https://api.trello.com/1";

        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "application/json");
            return client;
        }

        public static async Task<List<TrelloCard>> GetTrelloCardAsync(string boardId)
        {
            string url = $"{_BASEURI}/list/{boardId}/cards?key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    Console.WriteLine(boardId);
                    string json = await client.GetStringAsync(url);
                    List<TrelloCard> list = JsonConvert.DeserializeObject<List<TrelloCard>>(json);
                    return list;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        public static async Task AddCardAsync(string listId, TrelloCard card)
        {
            string url = $"{_BASEURI}/cards?idList={listId}&key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(card);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"Unsuccesful PUT to url: {url}, object: {json}";
                        throw new Exception(errorMsg);
                    }
                    //string json = await client.GetStringAsync(url);
                    //TrelloCard item = JsonConvert.DeserializeObject<TrelloCard>(json);
                    //return item;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        public static async Task DeleteCardAsync(string cardId)
        {
            string url = $"{_BASEURI}/cards/{cardId}/?key={_APIKEY}&token={_USERTOKEN}";

            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    var response = await client.DeleteAsync(url);
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorMsg = $"Unsuccesful DELETE to url: {url}";
                        throw new Exception(errorMsg);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }
    }
}
