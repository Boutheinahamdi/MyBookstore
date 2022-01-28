using Bookstore.ViewModels;
using Core;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IUnitOfWork<Categorie> _cat;
      

        public HomeController( IUnitOfWork<Categorie> cat)
        {
            
            _cat = cat;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                
                cats = _cat.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
           
        }
        public IActionResult Contact()
        {
            return View();

        }

    }
}
