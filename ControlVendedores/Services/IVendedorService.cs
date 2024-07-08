using ControlVendedores.Models;

namespace ControlVendedores.Services;

public interface IVendedorService
{
    void Create(Vendedor obj);
    List<Vendedor> GetAll(string nameFilter);
    List<Vendedor> GetAll();
    void Update(Vendedor obj);
    void Delete(int id);
    Vendedor? GetById(int id);


}