using ControlVendedores.Models;

namespace ControlVendedores.ViewModels;

public class VendedorViewModel
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
    public List<Venta> Ventas { get; set; } = new List<Venta>();
    public List<Sucursal> Sucursales { get; set; } = new List<Sucursal>();
    public string? NameFilter { get; set; }

    public List<int> SucursalesSeleccionadas { get; set; }

}