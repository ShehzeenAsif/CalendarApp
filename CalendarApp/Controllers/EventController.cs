using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CalendarApp.Data;
using CalendarApp.Models;
using CalendarApp.Models.ViewModels;

namespace CalendarApp.Controllers
{
    public class EventController : Controller
    {
        private readonly IDAL _dal;

        public EventController(IDAL dal)
        {
            _dal = dal;
        }

        // GET: Event
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_dal.GetEvents());
        }

        // GET: Event/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            return View(new EventViewModel(_dal.GetLocations()));
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel vm, IFormCollection form)
        {
            try
            {
                _dal.CreateEvent(form);
                TempData["Alert"] = "Success! event created" + form["Name"];
                return RedirectToAction("Index");
            } catch(Exception ex)
            {
                ViewData["Alert"] = "Error occured" + ex.Message;
                return View(vm);
            }

        }

        // GET: Event/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EventViewModel vm, IFormCollection form)
        {
            if (id != vm.Event.id)
            {
                return NotFound();
            }
                try
                {
                    _dal.UpdateEvent(form);
                    TempData["Alert"] = "You midified an event for " + vm.Event.Name;
                    return RedirectToAction(nameof(Index));
                }
                
                catch (Exception ex)
                {
                    ViewData["Alert"] = "Error occured " + ex.Message;
                    return View(vm);

                }        
        }

        // GET: Event/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var @event = _dal.GetEvent(id);
            if (@event != null)
            {
                _dal.DeleteEvent(id);
                TempData["Alert"] = "You deleted an event";
            }

            return RedirectToAction(nameof(Index));
        }

        
    }
}
