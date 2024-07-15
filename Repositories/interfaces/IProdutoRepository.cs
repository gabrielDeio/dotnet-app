using WebApplication2.Models;

namespace WebApplication2.Repositories.interfaces;

public interface IProdutoRepository
{
    Task<List<ProdutoModel>> ListarProdutos();
    Task<ProdutoModel> BuscarProduto(int id);
    Task<ProdutoModel> InserirProduto(ProdutoModel produto);
    Task<ProdutoModel> EditarProduto(ProdutoModel produto, int id);
    Task<bool> ExcluirProduto(int id);
}