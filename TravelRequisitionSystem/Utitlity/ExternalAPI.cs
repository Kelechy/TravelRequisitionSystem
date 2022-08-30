using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TravelRequisitionSystem.Model;

namespace TravelRequisitionSystem.Utitlity
{
    public static class ExternalAPI
    {
        public static async Task<List<CountrySearchResponse>> GetCountryDetails(IConfiguration config, string Country)
        {
            var endpoint = config.GetValue<string>("ExternalAPIS:CountrySearch");
            var url = String.Format(endpoint, Country);

            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<List<CountrySearchResponse>>(response.Content);
                return result;
            }
            else
            {
                throw new Exception("Erro Getting Country Details");
            }
        }

        public static async Task<WeatherSearchResponse> GetWeatherDetails(IConfiguration config, string Country)
        {
            var endpoint = config.GetValue<string>("ExternalAPIS:WeatherSearch");
            var APIKey = config.GetValue<string>("ExternalAPIS:APIKey");

            var url = String.Format(endpoint, Country, APIKey);
            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<WeatherSearchResponse>(response.Content);
                return result;
            }
            else
            {
                throw new Exception("Erro Getting Country Details");
            }
        }
    }
}
