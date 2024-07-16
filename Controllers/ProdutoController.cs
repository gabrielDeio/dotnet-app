using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoServices _produtoServices;

    
    public ProdutoController(IProdutoServices produtoServices)
    {
        _produtoServices = produtoServices;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ProdutoModel>>> ListarProdutos()
    {
        List<ProdutoModel> produtos = await _produtoServices.ListarProdutos();
        return Ok(produtos);
    }

    [HttpPost]
    public async Task<ActionResult<ProdutoModel>> InserirProduto([FromBody] ProdutoModel produtoModel)
    {
        ProdutoModel produto = await _produtoServices.InserirProduto(produtoModel);
        return Ok(produto);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<ProdutoModel>> EditarProduto([FromBody] ProdutoModel produtoModel, int id)
    {
        ProdutoModel produto = await _produtoServices.EditarProduto(produtoModel, id);

        return Ok(produto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> ExcluirProduto(int id)
    {
        bool result = await _produtoServices.ExcluirProduto(id);

        return Ok(result);
    }
}