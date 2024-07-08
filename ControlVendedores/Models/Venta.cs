namespace ControlVendedores.Models;

public class Venta
{
    public int Id { get; set; }

    public string NumTicket { get; set; }

    public DateOnly FechaVenta { get; set; }

    public int Unidades { get; set; }

    public decimal Monto { get; set; }

    public int VendedorId { get; set; }

    public virtual Vendedor Vendedor { get; set; }


}