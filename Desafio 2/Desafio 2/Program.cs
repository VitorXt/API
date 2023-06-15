using Desafio_2;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

class Program
{
    private static readonly HttpClient httpClient = new HttpClient();

    static async Task Main(string[] args)
    {

        while (true)
        {
            ShowMenu();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    await PorMoeda();
                    break;
                case "2":
                    await PorContinente();
                    break;
                case "3":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine(" ");
        Console.WriteLine("1 – Procurar Por Moeda.");
        Console.WriteLine("2 – Por Continente.");
        Console.WriteLine("3 - Sair.");
        Console.WriteLine(" ");
        Console.Write("Escolha uma opção: ");
    }

    static async Task PorMoeda()
    {
        Console.Write("Digite a moeda para consulta dos países: ");
        string currency = Console.ReadLine();
        Console.WriteLine();

        try
        {
            string url = $"https://restcountries.com/v3.1/currency/{currency}?fields=name,capital";
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List <DadosMoeda> _Moeda = Newtonsoft.Json.JsonConvert.DeserializeObject <List<DadosMoeda>>(responseBody);

            foreach (var item in _Moeda)
            {
                Console.WriteLine($"Nome: {item.name.common}");
                foreach (var item2 in item.capital)
                {
                    Console.WriteLine($"Capital: {item2}");
                }  
                Console.WriteLine(" ");
            }
        }

        catch (HttpRequestException e)
        {
            Console.WriteLine($"Ocorreu um erro na requisição HTTP: {e.Message}");
        }
    }

    static async Task PorContinente()
    {
        Console.Write("Digite o continente para consultar os países: ");
        string continent = Console.ReadLine();
        Console.WriteLine();

        try
        {
            string url = $"https://restcountries.com/v3.1/region/{continent}?fields=name,capital";
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            List<DadosContinente> _Continente = Newtonsoft.Json.JsonConvert.DeserializeObject <List<DadosContinente>>(responseBody);

            foreach (var item in _Continente)
            {
                Console.WriteLine($"Nome: {item.name.common}");
                foreach (var item2 in item.capital)
                {
                    Console.WriteLine($"Capital: {item2}");
                }
                Console.WriteLine(" ");
            }
        }

        catch (HttpRequestException e)
        {
            Console.WriteLine($"Ocorreu um erro na requisição HTTP: {e.Message}");
        }
    }
}
