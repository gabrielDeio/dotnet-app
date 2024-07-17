using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Xml.Serialization;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IntegrationController : ControllerBase
{
       private readonly IIntegrationServices _integrationServices;

       public IntegrationController(IIntegrationServices integrationServices)
       {
              _integrationServices = integrationServices;
       }
       [HttpPost("/clientes")]
       public async Task<ActionResult<List<ClienteModel>>> ObterDadosDeClientes()
       {
              List<ClienteModel> clientes = await _integrationServices.ObterESalvarDadosClientes();

              if (clientes == null)
              {
                     return BadRequest("Not found");
              }

              return clientes;
       }

       [HttpPost("/Produtos")]
       public async Task<ActionResult<List<ProdutoModel>>> ObterDadosDeProdutos()
       {
              List<ProdutoModel> produtos = await _integrationServices.ObterESalvarDadosProdutos();

              if (produtos == null)
              {
                     return BadRequest("Not found");
              }

              return produtos;
       }

       [HttpPost("/Vendas")]
       public async Task<ActionResult<List<VendaModel>>> ObterDadosDeVendas()
       {
              List<VendaModel> vendas = await _integrationServices.ObterESalvarDadosVendas();

              if (vendas == null)
              {
                     return BadRequest("Not found");
              }

              return vendas;
       }
}