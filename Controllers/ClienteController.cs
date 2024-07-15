using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories.interfaces;

namespace WebApplication2.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ClienteModel>>> ListarClientes()
    {
        List<ClienteModel> clientes = await _clienteRepository.ListarClientes();
        return Ok(clientes);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteModel>> InserirCliente([FromBody] ClienteModel clienteModel)
    {
        ClienteModel cliente = await _clienteRepository.InserirCliente(clienteModel);

        return Ok(cliente);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<ClienteModel>> EditarCliente([FromBody] ClienteModel clienteModel, int id)
    {
        clienteModel.IdCliente = id;
        ClienteModel cliente = await _clienteRepository.EditarCliente(clienteModel, id);

        return Ok(cliente);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> ExcluirCliente(int id)
    {
        bool result = await _clienteRepository.ExcluirCliente(id);

        return Ok(result);
    }
}