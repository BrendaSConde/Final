namespace ControlVendedores.Models;

public class Vendedor
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public virtual List<Sucursal> Sucursales { get; set; }

    public virtual List<Venta> Ventas { get; set; }

}