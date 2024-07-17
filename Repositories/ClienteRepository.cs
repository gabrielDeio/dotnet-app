using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories.interfaces;

namespace WebApplication2.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDBContext _dbContext;

    public ClienteRepository(AppDBContext appDbContext)
    {
        _dbContext = appDbContext;
    }
    public async Task<List<ClienteModel>> ListarClientes()
    {
        return await _dbContext.Clientes.ToListAsync();
    }

    public async Task<ClienteModel> BuscarCliente(int id)
    {
        return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);
    }
    
    public async Task<ClienteModel> InserirCliente(ClienteModel cliente)
    {
        var clienteExistente = await _dbContext.Clientes.AnyAsync(c => c.IdCliente == cliente.IdCliente);
        if(clienteExistente)
        {
            throw new InvalidOperationException($"Cliente com Id {cliente.IdCliente} já existe.");
        }
        await _dbContext.Clientes.AddAsync(cliente);
        await _dbContext.SaveChangesAsync();

        return cliente;
    }

    public async Task<ClienteModel> EditarCliente(ClienteModel cliente, int id)
    {
        ClienteModel clientePerId = await BuscarCliente(id);

        if (clientePerId == null)
        {
            throw new Exception($"Cliente com ID : {id} não encontrado");
        }

        clientePerId.NmCliente = cliente.NmCliente;
        clientePerId.Cidade = cliente.Cidade;

        await _dbContext.SaveChangesAsync();

        return clientePerId;
    }

    public async Task<bool> ExcluirCliente(int id)
    {
        ClienteModel clientePerId = await BuscarCliente(id);

        if (clientePerId == null)
        {
            throw new Exception($"Cliente com ID : {id} não encontrado");
        }

        _dbContext.Clientes.Remove(clientePerId);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}