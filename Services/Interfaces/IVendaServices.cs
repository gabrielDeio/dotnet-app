using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IVendaServices
{
    Task<List<VendaModel>> ListarVendas();
    Task<VendaModel> InserirVenda(VendaModel vendaModel);
    Task<List<VendaModel>> InserirListaDeVendas(List<VendaModel> vendaModels);
    Task<VendaModel> EditarVenda(VendaModel vendaModel, int id);
    Task<bool> ExcluirVenda(int id);
}