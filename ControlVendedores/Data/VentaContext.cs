using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ControlVendedores.Models;

namespace ControlVendedores.Data
{
    public class VentaContext : IdentityDbContext
    {
        public VentaContext (DbContextOptions<VentaContext> options)
            : base(options)
        {
        }

        public DbSet<ControlVendedores.Models.Sucursal> Sucursal { get; set; } = default!;

        public DbSet<ControlVendedores.Models.Vendedor> Vendedor { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sucursal>()
            .HasMany(p=> p.Vendedores)
            .WithMany(p=> p.Sucursales)
            .UsingEntity("SucursalVendedor");
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ControlVendedores.Models.Venta> Venta { get; set; } = default!;
    }
}
