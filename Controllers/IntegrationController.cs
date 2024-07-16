using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Xml.Serialization;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IntegrationController : ControllerBase
{
       private readonly IntegrationServices _integrationServices;

       public IntegrationController(IntegrationServices integrationServices)
       {
              _integrationServices = integrationServices;
       }
       [HttpGet]
       public async Task<ActionResult<List<ClienteModel>>> ObterDadosDeClientes()
       {
              List<ClienteModel> clientes = await _integrationServices.ObterDadosDeClientes();

              if (clientes == null)
              {
                     return BadRequest("Not found");
              }

              return clientes;
       }
}