using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendaController : ControllerBase
{
    private readonly IVendaServices _vendaServices;

    public VendaController(IVendaServices vendaServices)
    {
        _vendaServices = vendaServices;
    }

    [HttpGet]
    public async Task<ActionResult<List<VendaModel>>> ListarVendas()
    {
        List<VendaModel> vendaModels = await _vendaServices.ListarVendas();

        return Ok(vendaModels);
    }

    [HttpPost]
    public async Task<ActionResult<VendaModel>> InserirVenda([FromBody] VendaModel vendaModel)
    {
        VendaModel result = await _vendaServices.InserirVenda(vendaModel);

        return Ok(result);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<VendaModel>> EditarVenda([FromBody] VendaModel vendaModel, int id)
    {
        VendaModel result = await _vendaServices.EditarVenda(vendaModel, id);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> ExcluirVenda(int id)
    {
        bool result = await _vendaServices.ExcluirVenda(id);

        return Ok(result);
    }
}