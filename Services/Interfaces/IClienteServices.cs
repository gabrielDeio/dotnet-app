using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IClienteServices
{
    Task<List<ClienteModel>> ListarClientes();
    Task<ClienteModel> InserirCliente(ClienteModel cliente);
    Task<ClienteModel> EditarCliente(ClienteModel clinte, int id);
    Task<bool> ExcluirCliente(int id);

    Task<List<ClienteModel>> InserirListaDeClientes(List<ClienteModel> clientes);
}