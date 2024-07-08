using ControlVendedores.Models;

namespace ControlVendedores.ViewModels;

public class SucursalViewModel
{
    public int Id { get; set; }

    public string Nombre { get; set; }
    
    public List<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
    
    public List<Sucursal> Sucursales { get; set; } = new List<Sucursal>();

    public string? NameFilter { get; set; }


}