using ControlVendedores.Models;

namespace ControlVendedores.Services;

public interface ISucursalService
{
    void Create(Sucursal obj);
    List<Sucursal> GetAll(string nameFilter);
    List<Sucursal> GetAll();
    void Update(Sucursal obj);
    void Delete(int id);
    Sucursal? GetById(int id);


}