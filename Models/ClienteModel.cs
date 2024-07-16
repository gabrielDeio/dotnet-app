using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public class ClienteModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int IdCliente { get; set; }
    public string NmCliente { get; set; }
    public string Cidade { get; set; }
}