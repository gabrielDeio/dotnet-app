using WebApplication2.Models;
using WebApplication2.Repositories.interfaces;

namespace WebApplication2.Services;

public class VendaServices : IVendaServices
{
    private readonly IVendaRepository _vendaRepository;

    public VendaServices(IVendaRepository vendaRepository)
    {
        _vendaRepository = vendaRepository;
    }
    
    public async Task<List<VendaModel>> ListarVendas()
    {
        return await _vendaRepository.ListarVendas();
    }

    public async Task<VendaModel> InserirVenda(VendaModel vendaModel)
    {
        return await _vendaRepository.InserirVenda(vendaModel);
    }

    public async Task<List<VendaModel>> InserirListaDeVendas(List<VendaModel> vendaModels)
    {
        List<VendaModel> result = [];
        foreach (var vendaModel in vendaModels)
        {
            VendaModel venda = await _vendaRepository.InserirVenda(vendaModel);
            result.Add(venda);
        }

        return result;
    }

    public async Task<VendaModel> EditarVenda(VendaModel vendaModel, int id)
    {
        return await _vendaRepository.EditarVenda(vendaModel, id);
    }

    public async Task<bool> ExcluirVenda(int id)
    {
        return await _vendaRepository.ExcluirVenda(id);
    }
}