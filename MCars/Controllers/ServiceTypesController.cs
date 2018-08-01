using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MCars.Data;
using MCars.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        
        //Details : ServiceTypes/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var serviceType = await _db.serviceTypes.SingleOrDefaultAsync(m=>m.Id==id);
            if(serviceType==null)
            {
                return NotFound();
            
            }
            return View(serviceType);
        }

        //Edit : ServiceTypes/Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serviceType = await _db.serviceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
            {
                return NotFound();

            }
            return View(serviceType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,ServiceType serviceType)
        {
            if(id!=serviceType.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _db.Update(serviceType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);
        }

            //Delete : ServiceTypes/Delete/1
            public async Task<IActionResult> Delete(int? id)
            {
            if (id == null)
            {
                return NotFound();
            }
            var serviceType = await _db.serviceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null)
            {
                return NotFound();

            }
            return View(serviceType);
            }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveServiceType(int id)
        {
            var serviceType = await _db.serviceTypes.SingleOrDefaultAsync(m => m.Id == id);
            _db.serviceTypes.Remove(serviceType);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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