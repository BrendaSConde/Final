using ControlVendedores.Models;

namespace ControlVendedores.Services;
public interface IVentaService
{
    void Create(Venta obj);
    List<Venta> GetAll(string nameFilter);
    List<Venta> GetAll();
    void Update(Venta obj);
    void Delete(int id);
    Venta? GetById(int id);


}