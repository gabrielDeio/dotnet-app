using System.Xml.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class IntegrationServices : IIntegrationServices
{
    private readonly ClienteServices _clienteServices;

    public IntegrationServices(ClienteServices clienteServices)
    {
        _clienteServices = clienteServices;
    }
    public async Task<List<ClienteModel>> ObterDadosDeClientes()
    {
        var httpClient = new HttpClient();

        try
        {
            HttpResponseMessage response = await httpClient.GetAsync("https://camposdealer.dev/Sites/TesteAPI/cliente");
                     
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Resposta da API: {responseBody}");
                var jsonString = JsonConvert.DeserializeObject<string>(responseBody);
                var jsonObject = JsonConvert.DeserializeObject<List<ClienteModel>>(jsonString);

                List<ClienteModel> clientesInseridos = await _clienteServices.InserirListaDeClientes(jsonObject);
                
                return clientesInseridos;
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
}