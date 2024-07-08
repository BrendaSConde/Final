using System.ComponentModel.DataAnnotations;
using ControlVendedores.Models;

namespace ControlVendedores.ViewModels;
public class VentaCreateViewModel
{
    public int Id { get; set; }

    public string NumTicket { get; set; }

    public DateOnly FechaVenta { get; set; }

    public int Unidades { get; set; }

    public decimal Monto { get; set; }
  
    [Display(Name = "Vendedor")]
    public int VendedorId { get; set; }

}