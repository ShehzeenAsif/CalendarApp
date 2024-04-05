using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CalendarApp.Data;
using CalendarApp.Models;

namespace CalendarApp.Controllers
{
    public class LocationsController : Controller
    {
        private readonly IDAL _dal;

        public LocationsController( IDAL dal)
        {
            _dal = dal;
        }

        // GET: Locations
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_dal.GetLocations());
        }

        // GET: Locations/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = _dal.GetLocation((int)id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name")] Location location)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dal.CreateLocation(location);
                    TempData["Alert"] = "Successfully created a loc for " + location.Name;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewData["Alert"] = "Error occured" + ex.Message;
                    return View(location);
                }
            }
            return View(location);
        }

        
    }
}
