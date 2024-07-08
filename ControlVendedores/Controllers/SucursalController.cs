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
    public class SucursalController : Controller
    {
        private ISucursalService _sucursalService;
        private IVendedorService _vendedorService;

        public SucursalController(ISucursalService sucursalService, IVendedorService vendedorService)
        {
            _sucursalService = sucursalService;
            _vendedorService = vendedorService;
        }

        // GET: Sucursal
        public async Task<IActionResult> Index(string nameFilter)
        {
            var list = _sucursalService.GetAll(nameFilter);
            var model = new SucursalViewModel();
            model.Sucursales = list;

            return View(model);
        }

        // GET: Sucursal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursal = _sucursalService.GetById(id.Value);
            if (sucursal == null)
            {
                return NotFound();
            }

            var model = new SucursalViewModel();
            model.Vendedores = sucursal.Vendedores;
            model.Nombre = sucursal.Nombre;
            model.Id = sucursal.Id;

            return View(model);
        }

        // GET: Sucursal/Create
        [Authorize(Roles = "Adm")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sucursal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] SucursalCreateViewModel sucursalView)
        {
            if (ModelState.IsValid)
            {
                var sucursal = new Sucursal
                {
                    Nombre = sucursalView.Nombre,
                };

                _sucursalService.Create(sucursal);

                return RedirectToAction(nameof(Index));
            }
            return View(sucursalView);
        }

        // GET: Sucursal/Edit/5
        [Authorize(Roles = "Adm,Gerente")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursal = _sucursalService.GetById(id.Value);
            if (sucursal == null)
            {
                return NotFound();
            }
            SucursalCreateViewModel sucursalN = new SucursalCreateViewModel();
            sucursalN.Id = sucursal.Id;
            sucursalN.Nombre = sucursal.Nombre;

            return View(sucursalN);
        }

        // POST: Sucursal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] SucursalCreateViewModel sucursalView)
        {
            if (id != sucursalView.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sucursalNueva = _sucursalService.GetById(sucursalView.Id);
                sucursalNueva.Nombre = sucursalView.Nombre;
                _sucursalService.Update(sucursalNueva);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Sucursal/Delete/5
        [Authorize(Roles = "Adm,Gerente")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursal = _sucursalService.GetById(id.Value);
            if (sucursal == null)
            {
                return NotFound();
            }
            SucursalViewModel sucursalN = new SucursalViewModel();
            sucursalN.Id = sucursal.Id;

            return View(sucursalN);
        }

        // POST: Sucursal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucursal = _sucursalService.GetById(id);

            if (sucursal != null)
            {
                _sucursalService.Delete(sucursal.Id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SucursalExists(int id)
        {
            return _sucursalService.GetById(id) != null;
        }
    }

