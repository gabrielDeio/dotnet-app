using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;


public class VendaModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int IdVenda { get; set; }
    
    public int IdCliente { get; set; }
    public virtual  ClienteModel? Cliente { get; set; } 
    
    public int IdProduto { get; set; }
    public virtual ProdutoModel? Produto { get; set; }
    public int QtdVenda { get; set; }
    public float VlrUnitarioVenda { get; set; }
    public DateTime DthVenda { get; set; }

    [NotMapped]
    public float ?VlrTotalVenda
    {
        get
        {
            return QtdVenda * VlrUnitarioVenda;
        }
    }
}