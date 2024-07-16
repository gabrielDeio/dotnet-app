using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;


public class ProdutoModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int IdProduto { get; set; }
    public string DscProduto { get; set; }
    public float VlrUnitario { get; set; }
}