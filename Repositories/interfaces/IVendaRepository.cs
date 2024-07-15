using WebApplication2.Models;

namespace WebApplication2.Repositories.interfaces;

public interface IVendaRepository
{
    Task<List<VendaModel>> ListarVendas();
    Task<List<VendaModel>> InserirVenda(VendaModel venda);
    Task<List<VendaModel>> EditarVenda(VendaModel venda, int id);
    Task<bool> ExcluirProduto(int id);
}