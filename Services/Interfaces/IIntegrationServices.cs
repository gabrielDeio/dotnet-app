using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IIntegrationServices
{
    Task<string> ObterDadosDeUrl(string url);
    Task<List<ClienteModel>> ObterESalvarDadosClientes();
    Task<List<ProdutoModel>> ObterESalvarDadosProdutos();
}