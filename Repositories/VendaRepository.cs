using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories.interfaces;

namespace WebApplication2.Repositories;

public class VendaRepository : IVendaRepository
{
    private readonly AppDBContext _dbContext;

    public VendaRepository(AppDBContext appDbContext)
    {
        _dbContext = appDbContext;
    }
    
    public async Task<List<VendaModel>> ListarVendas()
    {
        return await _dbContext.Vendas
            .Include(v => v.Cliente)
            .Include(v => v.Produto)
            .ToListAsync();
    }

    public async Task<VendaModel> BuscarVenda(int id)
    {
        return await _dbContext.Vendas.FirstOrDefaultAsync(x => x.IdVenda == id);
    }

    public async Task<VendaModel> InserirVenda(VendaModel vendaModel)
    {
        var clienteExistente = await _dbContext.Clientes.AnyAsync(c => c.IdCliente == vendaModel.IdCliente);
        if(!clienteExistente)
        {
            throw new InvalidOperationException($"Cliente com Id {vendaModel.IdCliente} não encontrado.");
        }
        var produtoExistente = await _dbContext.Produtos.AnyAsync(c => c.IdProduto == vendaModel.IdProduto);
        if(!produtoExistente)
        {
            throw new InvalidOperationException($"Produto com Id {vendaModel.IdProduto} não encontrado.");
        }

        await _dbContext.Vendas.AddAsync(vendaModel);
        await _dbContext.SaveChangesAsync();

        return vendaModel;
    }

    public async Task<VendaModel> EditarVenda(VendaModel vendaModel, int id)
    {
        VendaModel venda = await BuscarVenda(id);

        if(venda == null)
        {
            throw new Exception($"Venda com ID : {id} não encontrado");
        }

        venda.IdCliente = vendaModel.IdCliente;
        venda.DthVenda = vendaModel.DthVenda;
        venda.IdProduto = vendaModel.IdProduto;
        venda.QtdVenda = vendaModel.QtdVenda;
        venda.VlrUnitarioVenda = vendaModel.VlrUnitarioVenda;

        await _dbContext.SaveChangesAsync();

        return venda;
    }

    public async Task<bool> ExcluirVenda(int id)
    {
        VendaModel venda = await BuscarVenda(id);

        if(venda == null)
        {
            throw new Exception($"Venda com ID : {id} não encontrado");
        }

        _dbContext.Vendas.Remove(venda);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}