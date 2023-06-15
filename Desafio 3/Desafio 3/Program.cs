using Desafio_3;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string apiUrl = "https://economia.awesomeapi.com.br/last/USD-BRL,EUR-BRL,BTC-BRL";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Root Cambio = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(responseBody);

                    Console.WriteLine($"1 Dolar (USD) = {Cambio.USDBRL.high} Real (BRL)");
                    Console.WriteLine($"1 Euro (EUR) = {Cambio.EURBRL.high} Real (BRL)");
                    Console.WriteLine($"1 BitCoin (BTC) = {Cambio.BTCBRL.high} Real (BRL)");

                }
                else
                {
                    Console.WriteLine("Falha na solicitação da API. Status: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro durante a solicitação da API: " + ex.Message);
            }
        }
    }
}