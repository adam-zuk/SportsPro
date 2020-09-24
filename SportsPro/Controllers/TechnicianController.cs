using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class TechnicianController : Controller
    {
        private SportsProContext context { get; set; }

        public TechnicianController(SportsProContext ctx)
        {
            context = ctx;
        }
        [Route("Technicians")]

        public IActionResult List()
        {
            var technicians = context.Technicians.ToList();
            return View(technicians);
        }

        //public ViewResult List(string activeTechnician = "All", string activeIncident = "All")
        //{
        //    var model = new IncidentViewModel
        //    {
        //        ActiveIncident = activeIncident,
        //        ActiveTechnician = activeTechnician,
        //        Technicians = context.Technicians.ToList(),
        //        Incidents = context.Incidents.ToList()
        //    };

        //    IQueryable<Incident> query = context.Incidents;

        //    if (activeIncident!= "all")
        //        query = query.Where(i => i.IncidentID.ToString() == activeIncident);

        //    if (activeTechnician!= "all")
        //        query = query.Where(t => t.Technician.TechnicianID.ToString() == activeTechnician);

        //    model.Incidents = query.ToList();
        //    return View(model);
        //}


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddEdit", new Technician());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            // ViewBag.Genres = context.Genres.OrderBy(g => g.Name).ToList();
            var technician = context.Technicians.Find(id);
            return View("AddEdit", technician);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (ModelState.IsValid)
            {
                if (technician.TechnicianID == 0)
                    context.Technicians.Add(technician);
                else
                    context.Technicians.Update(technician);
                context.SaveChanges();
                return RedirectToAction("List", "Technician");
            }
            else
            {
                ViewBag.Action = (technician.TechnicianID == 0) ? "Add" : "Edit";
                //ViewBag.Technician = context.Technicians.OrderBy(g => g.Name).ToList(); 
                return View("AddEdit", technician);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)                 // on the integer. Loads the info to the delete function 
        {
            var technician = context.Technicians.Find(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult Delete(Technician technician)            // on the technician
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("List", "Technician");
        }
    }
}
