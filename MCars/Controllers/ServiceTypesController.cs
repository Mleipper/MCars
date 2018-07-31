using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCars.Data;
using MCars.Models;
using Microsoft.AspNetCore.Mvc;

namespace MCars.Controllers
{
    public class ServiceTypesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ServiceTypesController(ApplicationDbContext db)
        {
            _db = db;
        }
        //Get: serviceTypes
        public IActionResult Index()
        {
            return View(_db.serviceTypes.ToList());
        }

        //Get: servicesTypes/create
        public IActionResult Create()
        {
            return View();
        }

        //Post servicesTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            if(ModelState.IsValid)
            {
                _db.Add(serviceType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);

        }


        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _db.Dispose();
            }
        }
    }
}