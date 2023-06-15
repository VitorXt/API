using Desafio_1;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

class Program
{
    static async Task Main()
    {
        await ObterDadosIP();
    }

    static async Task ObterDadosIP()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = "https://ipapi.co/json/";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                API ipData = Newtonsoft.Json.JsonConvert.DeserializeObject<API>(responseBody);

                Console.WriteLine($"IP: {ipData.ip}");
                Console.WriteLine($"Rede: {ipData.network}");
                Console.WriteLine($"Versão: {ipData.version}");
                Console.WriteLine($"Cidade: {ipData.city}");
                Console.WriteLine($"Região: {ipData.region}");
                Console.WriteLine($"Código da Região: {ipData.region_code}");
                Console.WriteLine($"País: {ipData.country_name}");
                Console.WriteLine($"Código do País: {ipData.country_code}");
                Console.WriteLine($"Capital do País: {ipData.country_capital}");
                Console.WriteLine($"Continente: {ipData.continent_code}");
                Console.WriteLine($"CEP: {ipData.postal}");
                Console.WriteLine($"Latitude: {ipData.latitude}");
                Console.WriteLine($"Longitude: {ipData.longitude}");
                Console.WriteLine($"Fuso Horário: {ipData.timezone}");
                Console.WriteLine($"Deslocamento UTC: {ipData.utc_offset}");
                Console.WriteLine($"Código de Chamada do País: {ipData.country_calling_code}");
                Console.WriteLine($"Moeda: {ipData.currency_name}");
                Console.WriteLine($"Idiomas: {ipData.languages}");
                Console.WriteLine($"Área do País: {ipData.country_area}");
                Console.WriteLine($"População do País: {ipData.country_population}");
                Console.WriteLine($"ASN: {ipData.asn}");
                Console.WriteLine($"Organização: {ipData.org}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Ocorreu um erro na requisição HTTP: {e.Message}");
            }
        }
    }
}
