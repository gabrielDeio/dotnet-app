using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories.interfaces;

namespace WebApplication2.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDBContext _dbContext;

    public ProdutoRepository(AppDBContext appDbContext)
    {
        _dbContext = appDbContext;
    }
    
    public async Task<List<ProdutoModel>> ListarProdutos()
    {
        return await _dbContext.Produtos.ToListAsync();
    }

    public async Task<ProdutoModel> BuscarProduto(int id)
    {
        return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.IdProduto == id);
    }
    

    public async Task<ProdutoModel> InserirProduto(ProdutoModel produto)
    {
        var produtoExistente = await _dbContext.Produtos.AnyAsync(c => c.IdProduto == produto.IdProduto);
        if(produtoExistente)
        {
            throw new InvalidOperationException($"Produto com Id {produto.IdProduto} já existe.");
        }
        await _dbContext.Produtos.AddAsync(produto);
        await _dbContext.SaveChangesAsync();

        return produto;
    }

    public async Task<ProdutoModel> EditarProduto(ProdutoModel produto, int id)
    {
        ProdutoModel produtoPerId = await BuscarProduto(id);

        if (produtoPerId == null)
        {
            throw new Exception($"Produto com ID : {id} não encontrado");
        }

        produtoPerId.DscProduto = produto.DscProduto;
        produtoPerId.VlrUnitario = produto.VlrUnitario;

        await _dbContext.SaveChangesAsync();

        return produtoPerId;
    }

    public async Task<bool> ExcluirProduto(int id)
    {
        ProdutoModel produtoPerId = await BuscarProduto(id);

        if (produtoPerId == null)
        {
            throw new Exception($"Produto com ID : {id} não encontrado");
        }

        _dbContext.Produtos.Remove(produtoPerId);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}