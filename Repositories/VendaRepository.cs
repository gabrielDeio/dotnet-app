using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repositories;

public class VendaRepository
{
    private readonly AppDBContext _dbContext;

    public VendaRepository(AppDBContext appDbContext)
    {
        _dbContext = appDbContext;
    }
    
    public async Task<List<VendaModel>> ListarVendas()
    {
        return await _dbContext.Vendas.ToListAsync();
    }

    public async Task<VendaModel> BuscarVenda(int id)
    {
        return await _dbContext.Vendas.FirstOrDefaultAsync(x => x.IdCliente == id);
    }

    public async Task<VendaModel> InserirVenda(VendaModel vendaModel)
    {
        await _dbContext.Vendas.AddAsync(vendaModel);
        await _dbContext.SaveChangesAsync();

        return vendaModel;
    }

    public async Task<VendaModel> EditarVenda(VendaModel vendaModel, int id)
    {
        VendaModel venda = await BuscarVenda(id);

        if(venda == null)
        {
            throw new Exception($"Produto com ID : {id} não encontrado");
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
            throw new Exception($"Produto com ID : {id} não encontrado");
        }

        _dbContext.Vendas.Remove(venda);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}