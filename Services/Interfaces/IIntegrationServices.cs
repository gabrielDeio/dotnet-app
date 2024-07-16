using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IIntegrationServices
{
    Task<List<ClienteModel>> ObterDadosDeClientes();
}