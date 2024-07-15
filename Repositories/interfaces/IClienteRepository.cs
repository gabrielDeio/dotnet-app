using WebApplication2.Models;

namespace WebApplication2.Repositories.interfaces;

public interface IClienteRepository
{
    Task<List<ClienteModel>> ListarClientes();
    Task<ClienteModel> BuscarCliente(int id);
    Task<ClienteModel> InserirCliente(ClienteModel cliente);
    Task<ClienteModel> EditarCliente(ClienteModel cliente, int id);
    Task<bool> ExcluirCliente(int id);
}