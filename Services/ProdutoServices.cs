using WebApplication2.Models;
using WebApplication2.Repositories;
using WebApplication2.Repositories.interfaces;

namespace WebApplication2.Services;

public class ProdutoServices : IProdutoServices
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoServices(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }
    
    public async Task<List<ProdutoModel>> ListarProdutos()
    {
        return await _produtoRepository.ListarProdutos();
    }

    public async Task<ProdutoModel> InserirProduto(ProdutoModel produtoModel)
    {
        return await _produtoRepository.InserirProduto(produtoModel);
    }

    public async Task<List<ProdutoModel>> InserirListaDeProdutos(List<ProdutoModel> produtoModels)
    {
        List<ProdutoModel> result = [];
        foreach (var produtoModel in produtoModels)
        {
            ProdutoModel produto = await _produtoRepository.InserirProduto(produtoModel);
            result.Add(produto);
        }

        return result;
    }

    public async Task<ProdutoModel> EditarProduto(ProdutoModel produtoModel, int id)
    {
        return await _produtoRepository.EditarProduto(produtoModel, id);
    }

    public async Task<bool> ExcluirProduto(int id)
    {
        return await _produtoRepository.ExcluirProduto(id);
    }
}