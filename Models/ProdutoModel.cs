using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class ProdutoModel
{
    [Key]
    public int IdProduto { get; set; }
    public string DscProduto { get; set; }
    public float VlrUnitario { get; set; }
}