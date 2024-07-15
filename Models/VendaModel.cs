using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class VendaModel
{
    [Key]
    public int IdVenda { get; set; }
    public int ClienteId { get; set; }
    public virtual ClienteModel Cliente { get; set; } 
    
    public int ProdutoId { get; set; }
    public virtual ProdutoModel Produto { get; set; }
    public int QtdVenda { get; set; }
    public float VlrUnitarioVenda { get; set; }
    public DateTime DthVenda { get; set; }

    public float VlrTotalVenda
    {
        get
        {
            return QtdVenda * VlrUnitarioVenda;
        }
    }
}