using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SneakerProject2.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SneakerProject2.Repositories
{
    class ShoesRepository
    {
        //set base URI
        private const string _BASEURI = "https://www.thesneakerdatabase.com/api/";
        //prepare httpClient
        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        //GET RANDOM SHOE
        public static async Task<List<Results2>> GetShoesAsync()
        {
            string url = $"{_BASEURI}newReleases";
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    //ask for json data 
                    string json = await client.GetStringAsync(url);

                    //convert to object 
                    JObject fullObject = JsonConvert.DeserializeObject<JObject>(json);
                    JToken data = fullObject.SelectToken("data");

                    return data.ToObject<List<Results2>>();
                }
            }
            catch (Exception ex)
            {
                //always add breakpoint here!
                throw ex;
            }
        }

        //GET RANDOM SHOE BRAND
        public static async Task <Brands> GetShoeBrandsAsync()
        {
            string url = $"https://api.thesneakerdatabase.com/v1/brands";
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    //ask for json data 
                    string json = await client.GetStringAsync(url);

                    //convert to object 
                    JObject fullObject = JsonConvert.DeserializeObject<JObject>(json);
                    JToken data = fullObject.SelectToken("results");
                    //return to class
                    return fullObject.ToObject<Brands>();
                }
            }
            catch (Exception ex)
            {
                //always add breakpoint here!
                throw ex;
            }
        }

        //GET SHOE BY BRAND
        public static async Task<List<Results2>> GetShoesByBrandAsync(string brand)
        {
            string url = $"{_BASEURI}getData?brand=" + brand;
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    //ask for json data 
                    string json = await client.GetStringAsync(url);

                    //convert to object 
                    JObject fullObject = JsonConvert.DeserializeObject<JObject>(json);
                    JToken data = fullObject.SelectToken("data");

                    return data.ToObject<List<Results2>>();
                }
            }
            catch (Exception ex)
            {
                //always add breakpoint here!
                throw ex;
            }
        }
        //GET SHOE BY NAME
        public static async Task<List<Results2>> GetShoesByNameAsync(string Name)
        {
            string url = $"{_BASEURI}getData?name=" + Name;
            try
            {
                using (HttpClient client = GetHttpClient())
                {
                    //ask for json data 
                    string json = await client.GetStringAsync(url);

                    //convert to object 
                    JObject fullObject = JsonConvert.DeserializeObject<JObject>(json);
                    JToken data = fullObject.SelectToken("data");

                    return data.ToObject<List<Results2>>();
                }
            }
            catch (Exception ex)
            {
                //always add breakpoint here!
                throw ex;
            }
        }
    }
}
