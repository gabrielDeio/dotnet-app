using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories.interfaces;

namespace WebApplication2.Services;

public class ClienteServices : IClienteServices
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteServices(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<List<ClienteModel>> ListarClientes()
    {
        List<ClienteModel> clientes = await _clienteRepository.ListarClientes();
        return clientes;
    }
    
    public async Task<ClienteModel> InserirCliente( ClienteModel clienteModel)
    {
        ClienteModel cliente = await _clienteRepository.InserirCliente(clienteModel);

        return cliente;
    }

    public async Task<List<ClienteModel>> InserirListaDeClientes(List<ClienteModel> clientes)
    {
        List<ClienteModel> result = [];
        foreach (var clienteModel in clientes)
        {
            ClienteModel cliente = await InserirCliente(clienteModel);
            result.Add(cliente);
        }

        return result;
    }
    
    public async Task<ClienteModel> EditarCliente( ClienteModel clienteModel, int id)
    {
        clienteModel.IdCliente = id;
        ClienteModel cliente = await _clienteRepository.EditarCliente(clienteModel, id);

        return cliente;
    }
    
    public async Task<bool> ExcluirCliente(int id)
    {
        bool result = await _clienteRepository.ExcluirCliente(id);

        return result;
    }
}