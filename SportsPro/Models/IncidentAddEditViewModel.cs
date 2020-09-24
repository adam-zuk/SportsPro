using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class IncidentAddEditViewModel
    {
        public List<Customer> Customers { get; set; }

        public List<Product> Products { get; set; }

        public int TechnicianID { get; set; }
        public string Filter { get; set; }

        public Incident ActiveIncident { get; set; }
        public Technician ActiveTechnician { get; set; }

        public string Action { get; set; }

        private List<Incident> incidents { get; set; }

        public List<Incident> Incidents
        {
            get => incidents;
            set
            {
                incidents = value;
            }
        }

       
        private List<Technician> technicians { get; set; }
        public List<Technician> Technicians

        {
            get => technicians;
            set
            {
                technicians = value;
                //technicians.Insert(0, new Technician
                //{
                //    TechnicianID = 0,
                //    Name = "All"
                //});
            }
        }

        // methods to help view determine active link

        public string CheckActiveIncident(int i) => i == ActiveIncident.IncidentID ? "active" : "";
        public string CheckActiveTechnician(int t) => t == ActiveTechnician.TechnicianID ? "active" : "";
    }
}