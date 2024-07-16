using System.Xml.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class IntegrationServices : IIntegrationServices
{
    private readonly ClienteServices _clienteServices;
    private readonly ProdutoServices _produtoServices;

    public IntegrationServices(ClienteServices clienteServices, ProdutoServices produtoServices)
    {
        _clienteServices = clienteServices;
        _produtoServices = produtoServices;
    }
    public async Task<string> ObterDadosDeUrl(string url)
    {
        var httpClient = new HttpClient();

        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
                     
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Resposta da API: {responseBody}");
                var jsonString = JsonConvert.DeserializeObject<string>(responseBody);
                return jsonString;
            }
            else
            {
                Console.WriteLine($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erro de requisição HTTP: {ex.Message}");
        }
        finally
        {
            httpClient.Dispose();
        }

        return null;
    }

    public async Task<List<ClienteModel>> ObterESalvarDadosClientes()
    {
        string jsonString = await ObterDadosDeUrl("https://camposdealer.dev/Sites/TesteAPI/cliente");
        var jsonObject = JsonConvert.DeserializeObject<List<ClienteModel>>(jsonString);
        List<ClienteModel> clientesInseridos = await _clienteServices.InserirListaDeClientes(jsonObject);
        return clientesInseridos;
    }

    public async Task<List<ProdutoModel>> ObterESalvarDadosProdutos()
    {
        string jsonString = await ObterDadosDeUrl("https://camposdealer.dev/Sites/TesteAPI/produto");
        var jsonObject = JsonConvert.DeserializeObject<List<ProdutoModel>>(jsonString);
        List<ProdutoModel> produtosInseridos = await _produtoServices.InserirListaDeProdutos(jsonObject);

        return produtosInseridos;
    }
    
    
}