using Bookstore.ViewModels;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class ProdController : Controller
    {
        private readonly IUnitOfWork<Product> _product;
        private readonly IHostingEnvironment _hosting;
        public ProdController(IUnitOfWork<Product> product, IHostingEnvironment hosting)
        {
            _product = product;
             _hosting = hosting;
        }
        public ActionResult Index()
        {
            return View(_product.Entity.GetAll());
        }

        // GET: ProdController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prod = _product.Entity.GetById(id);
            if (prod == null)
            {
                return NotFound();
            }

            return View(prod);
          
        }

        // GET: ProdController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string fullPath = Path.Combine(uploads, model.File.FileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

                Product product = new Product
                {
                    ProductName = model.ProductName,
                    Designation = model.Designation,
                    Qauntité=model.Qauntité,
                    Price=model.Price,
                    imageurl = model.File.FileName
                };

                _product.Entity.Insert(product);
                _product.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: ProdController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
