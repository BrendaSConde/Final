using ControlVendedores.Data;
using ControlVendedores.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlVendedores.Services;

public class VendedorService : IVendedorService
{
    private readonly VentaContext _context;

    public VendedorService(VentaContext context)
    {
        _context = context;
    }

    public void Create(Vendedor obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var borrar = GetById(id);
        if (borrar != null)
        {
            _context.Remove(borrar);
            _context.SaveChanges();
        }
    }

    public List<Vendedor> GetAll(string nameFilter)
    {
        var query = GetQuery();
        if (!string.IsNullOrEmpty(nameFilter))
        {
            query = query.Where(x => x.Nombre.ToLower().Contains(nameFilter.ToLower()));
        }
        return query.ToList();
    }

    public List<Vendedor> GetAll()
    {
        var query = GetQuery();
        return query.Include(x => x.Sucursales).ToList();
    }

    public Vendedor? GetById(int id)
    {
        var vendedor = GetQuery()
            .Include(x => x.Sucursales)
            .FirstOrDefault(m => m.Id == id);

        return vendedor;
    }

    public void Update(Vendedor obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Vendedor> GetQuery()
    {
        return from vendedor in _context.Vendedor select vendedor;
    }
}