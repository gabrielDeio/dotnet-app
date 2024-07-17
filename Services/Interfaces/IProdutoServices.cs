using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IProdutoServices
{
    Task<List<ProdutoModel>> ListarProdutos();
    Task<ProdutoModel> InserirProduto(ProdutoModel produtoModel);
    Task<List<ProdutoModel>> InserirListaDeProdutos(List<ProdutoModel> produtoModels);
    Task<ProdutoModel> EditarProduto(ProdutoModel produtoModel, int id);
    Task<bool> ExcluirProduto(int id);
}