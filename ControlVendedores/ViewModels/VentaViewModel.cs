using System.ComponentModel.DataAnnotations;
using ControlVendedores.Models;

namespace ControlVendedores.ViewModels;
public class VentaViewModel
{
    public List<Venta> Ventas { get; set; } = new List<Venta>();

    public string? NameFilter { get; set; }

    public int Id { get; set; }

    public string NumTicket { get; set; }

    public DateOnly FechaVenta { get; set; }

    public int Unidades { get; set; }

    public decimal Monto { get; set; }
    
    [Display (Name = "Vendedor")]
    public int VendedorId { get; set; }
    public virtual Vendedor Vendedor { get; set; }

}