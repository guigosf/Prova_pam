using Prova.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Prova.Service
{
    public class CepService
    {
        HttpClient client;
        Cep cep;
        JsonSerializerOptions options;

    public CepService()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions
            {
               PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
               WriteIndented = true
            };
        }

        public async Task<Cep> GetCep()
        {
            string url = "https://brasilapi.com.br/api/cep/v1/{cep}";

            HttpResponseMessage response = await this.client.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();
                cep =
                       JsonSerializer.Deserialize<Cep>(JsonResponse, options);
                return cep;
            }
            return new Cep();
        }
    }
}
