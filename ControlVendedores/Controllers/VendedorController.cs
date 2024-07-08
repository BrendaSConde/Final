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
    public class VendedorController : Controller
    {
        private ISucursalService _sucursalService;
        private IVendedorService _vendedorService;

        public VendedorController(ISucursalService sucursalService, IVendedorService vendedorService)
        {
            _sucursalService = sucursalService;
            _vendedorService = vendedorService;
        }

        // GET: Vendedor
        public async Task<IActionResult> Index(string nameFilter)
        {
            var list = _vendedorService.GetAll(nameFilter);
            var model = new VendedorViewModel();
            model.Vendedores = list;
            var sucursalList = _sucursalService.GetAll();
            ViewData["Sucursales"] = new SelectList(sucursalList, "Id", "Nombre");
            return View(model);
        }

        // GET: Vendedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = _vendedorService.GetById(id.Value);
            if (vendedor == null)
            {
                return NotFound();
            }

            var model = new VendedorViewModel();
            model.Sucursales = vendedor.Sucursales;
            model.Nombre = vendedor.Nombre;
            model.Id = vendedor.Id;

            return View(model);
        }

        // GET: Vendedor/Create
        [Authorize(Roles = "Adm,Gerente")]
        public IActionResult Create()
        {
            var sucursalList = _sucursalService.GetAll();
            ViewData["Sucursales"] = new SelectList(sucursalList, "Id", "Nombre");
            return View();
        }

        // POST: Vendedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,SucursalIds")] VendedorCreateViewModel vendedorView)
        {

            if (ModelState.IsValid)
            {
                var sucursales = _sucursalService.GetAll().Where(x => vendedorView.SucursalIds.Contains(x.Id)).ToList();
                var vendedor = new Vendedor
                {
                    Nombre = vendedorView.Nombre,
                    Sucursales = sucursales
                };

                _vendedorService.Create(vendedor);

                return RedirectToAction(nameof(Index));
            }
            return View(vendedorView);
        }



        // GET: Vendedor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = _vendedorService.GetById(id.Value);
            if (vendedor == null)
            {
                return NotFound();
            }
            VendedorCreateViewModel vendedorN = new VendedorCreateViewModel();
            vendedorN.Id = vendedor.Id;
            vendedorN.Nombre = vendedor.Nombre;

            var sucursalList = _sucursalService.GetAll();
            ViewData["Sucursales"] = new SelectList(sucursalList, "Id", "Nombre");

            return View(vendedorN);
        }

        // POST: Vendedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,SucursalIds")] VendedorCreateViewModel vendedorView)
        {
            if (id != vendedorView.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sucursales = _sucursalService.GetAll().Where(x => vendedorView.SucursalIds.Contains(x.Id)).ToList();
                var vendedorN = _vendedorService.GetById(vendedorView.Id);
                vendedorN.Nombre = vendedorView.Nombre;
                vendedorN.Sucursales = sucursales;
                _vendedorService.Update(vendedorN);

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Vendedor/Delete/5
        [Authorize(Roles = "Adm,Gerente")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = _vendedorService.GetById(id.Value);
            if (vendedor == null)
            {
                return NotFound();
            }
            VendedorViewModel vendedorN = new VendedorViewModel();
            vendedorN.Id = vendedor.Id;

            return View(vendedorN);
        }

        // POST: Vendedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendedor = _vendedorService.GetById(id);

            if (vendedor != null)
            {
                _vendedorService.Delete(vendedor.Id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool VendedorExists(int id)
        {
            return _vendedorService.GetById(id) != null;
        }
    }

