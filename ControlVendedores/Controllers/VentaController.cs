using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlVendedores.Data;
using ControlVendedores.Models;
using ControlVendedores.Services;
using ControlVendedores.ViewModels;

namespace ControlVendedores.Controllers;
[Authorize]
public class VentaController : Controller
{
    private IVentaService _ventaService;
    private IVendedorService _vendedorService;

    public VentaController(IVentaService ventaService, IVendedorService vendedorService)
    {

        _ventaService = ventaService;
        _vendedorService = vendedorService;
    }

    // GET: Venta
    public async Task<IActionResult> Index(string nameFilter)
    {
        var list = _ventaService.GetAll(nameFilter);
        var model = new VentaViewModel();
        model.Ventas = list;
        var vendedorList = _vendedorService.GetAll();
        ViewData["Vendedores"] = new SelectList(vendedorList, "Id", "Nombre");
        return View(model);


    }

    // GET: Venta/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var venta = _ventaService.GetById(id.Value);
        if (venta == null)
        {
            return NotFound();
        }

        var model = new VentaViewModel();
        model.NumTicket = venta.NumTicket;
        model.Id = venta.Id;
        model.FechaVenta = venta.FechaVenta;
        model.Unidades = venta.Unidades;
        model.Monto = venta.Monto;
        model.VendedorId = venta.VendedorId;
        var vendedorList = _vendedorService.GetAll();
        ViewData["Vendedores"] = new SelectList(vendedorList, "Id", "Nombre");
        return View(model);
    }

    // GET: Venta/Create
    [Authorize(Roles = "Encargado")]
    public IActionResult Create()
    {
        var vendedorList = _vendedorService.GetAll();
        ViewData["Vendedores"] = new SelectList(vendedorList, "Id", "Nombre");
        return View();
    }

    // POST: Venta/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,NumTicket,FechaVenta,Unidades,Monto,VendedorId")] VentaCreateViewModel ventaView)
    {
        if (ModelState.IsValid)
        {
            var vendedor = _vendedorService.GetById(ventaView.VendedorId);
            var venta = new Venta
            {
                NumTicket = ventaView.NumTicket,
                FechaVenta = ventaView.FechaVenta,
                Unidades = ventaView.Unidades,
                Monto = ventaView.Monto,
                VendedorId = vendedor.Id
            };
            _ventaService.Create(venta);
            return RedirectToAction(nameof(Index));
        }

        return View(ventaView);
    }

    // GET: Venta/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var venta = _ventaService.GetById(id.Value);
        if (venta == null)
        {
            return NotFound();
        }

        VentaEditViewModel ventaEdit = new VentaEditViewModel();
        ventaEdit.Id = venta.Id;
        ventaEdit.NumTicket = venta.NumTicket;
        ventaEdit.FechaVenta = venta.FechaVenta;
        ventaEdit.Unidades = venta.Unidades;
        ventaEdit.Monto = venta.Monto;

        var vendedorList = _vendedorService.GetAll();
        ViewData["Vendedor"] = new SelectList(vendedorList, "Id", "Nombre");
        return View(ventaEdit);
    }

    // POST: Venta/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,NumTicket,FechaVenta,Unidades,Monto,VendedorId")] VentaEditViewModel ventaview)
    {
        if (id != ventaview.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var vendedor = _vendedorService.GetById(ventaview.VendedorId);
            var ventaAModificar = _ventaService.GetById(ventaview.Id);
            ventaAModificar.NumTicket = ventaview.NumTicket;
            ventaAModificar.FechaVenta = ventaview.FechaVenta;
            ventaAModificar.Unidades = ventaview.Unidades;
            ventaAModificar.Monto = ventaview.Monto;
            ventaAModificar.VendedorId = vendedor.Id;

            _ventaService.Update(ventaAModificar);
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: Venta/Delete/5
    [Authorize(Roles = "Encargado")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var venta = _ventaService.GetById(id.Value);
        if (venta == null)
        {
            return NotFound();
        }
        VentaViewModel ventaN = new VentaViewModel();
        ventaN.Id = venta.Id;
        ventaN.NumTicket = venta.NumTicket;
        ventaN.FechaVenta = venta.FechaVenta;
        ventaN.Unidades = venta.Unidades;
        ventaN.Monto = venta.Monto;
        return View(ventaN);
    }

    // POST: Venta/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var venta = _ventaService.GetById(id);

        if (venta != null)
        {
            _ventaService.Delete(venta.Id);
        }
        return RedirectToAction(nameof(Index));
    }

    private bool VentaExists(int id)
    {
        return _ventaService.GetById(id) != null;
    }
}

