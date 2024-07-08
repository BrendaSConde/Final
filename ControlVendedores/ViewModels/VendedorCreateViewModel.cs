using ControlVendedores.Models;
namespace ControlVendedores.ViewModels;

public class VendedorCreateViewModel
{

    public int Id { get; set; }

    public string Nombre { get; set; }

    public virtual List<int> SucursalIds { get; set; }
}