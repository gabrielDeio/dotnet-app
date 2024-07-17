using WebApplication2.Models;

namespace WebApplication2.Repositories.interfaces;

public interface IVendaRepository
{
    Task<List<VendaModel>> ListarVendas();
    Task<VendaModel> BuscarVenda(int id);
    Task<VendaModel> InserirVenda(VendaModel venda);
    Task<VendaModel> EditarVenda(VendaModel venda, int id);
    Task<bool> ExcluirVenda(int id);
}