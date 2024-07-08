using ControlVendedores.Data;
using ControlVendedores.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlVendedores.Services;

public class VentaService : IVentaService
{
    private readonly VentaContext _context;

    public VentaService(VentaContext context)
    {
        _context = context;
    }
    public void Create(Venta obj)
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

    public List<Venta> GetAll(string nameFilter)
    {
        var query = GetQuery();
        if (!string.IsNullOrEmpty(nameFilter))
        {
            query = query.Where(x => x.NumTicket.ToLower().Contains(nameFilter.ToLower()) ||
                                x.Vendedor.Nombre.ToLower().Contains(nameFilter.ToLower()));
        }
        return query.ToList();
    }
    public List<Venta> GetAll()
    {
        var query = GetQuery();
        return query.Include(x=>x.Vendedor).ToList();
    }


    public Venta? GetById(int id)
    {
        var venta = GetQuery()
            .Include(x => x.Vendedor)
            .FirstOrDefault(m => m.Id == id);

        return venta;
    }

    public void Update(Venta obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Venta> GetQuery()
    {
        return from venta in _context.Venta select venta;
    }
}