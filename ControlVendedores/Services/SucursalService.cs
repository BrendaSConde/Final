using ControlVendedores.Data;
using ControlVendedores.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlVendedores.Services;

public class SucursalService : ISucursalService
{
    private readonly VentaContext _context;

    public SucursalService(VentaContext context)
    {
        _context = context;
    }
    public void Create(Sucursal obj)
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

    public List<Sucursal> GetAll(string nameFilter)
    {
        var query = GetQuery();
        if (!string.IsNullOrEmpty(nameFilter))
        {
            query = query.Where(x => x.Nombre.ToLower().Contains(nameFilter.ToLower()));
        }
        return query.ToList();
    }

    public List<Sucursal> GetAll()
    {
        var query = GetQuery();
        return query.Include(x=>x.Vendedores).ToList();
    }

    public Sucursal? GetById(int id)
    {
        var sucursal = GetQuery()
            .Include(x => x.Vendedores)
            .FirstOrDefault(x => x.Id == id);

        return sucursal;
    }

    public void Update(Sucursal obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Sucursal> GetQuery()
    {
        return from sucursal in _context.Sucursal select sucursal;
    }
}