using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class ClienteModel
{
    [Key]
    public int IdCliente { get; set; }
    public string NmCliente { get; set; }
    public string Cidade { get; set; }
}