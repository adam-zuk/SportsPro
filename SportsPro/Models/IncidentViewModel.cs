using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class IncidentViewModel
    {
        public List<Customer> Customers { get; set; }
		public int TechnicianID { get; set; }
		public string FilterString { get; set; }
		public Incident ActiveIncident { get; set; }
		public Technician ActiveTechnician { get; set; }
		public String Action { get; set; }
		public List<Product> Products { get; set; }

		private List<Incident> incidents;
		public List<Incident> Incidents
		{
			get => incidents;
			set
			{
				incidents = value;
				//incidents.Insert(0, new Incident { IncidentID = 0, Title = "All" });
			}
		}


		private List<Technician> technicians;
		public List<Technician> Technicians
		{
			get => technicians;
			set
			{
				technicians = value;
				//technicians.Insert(0, new Technician { TechnicianID = 0, Name = "All" });
			}
		}

		public string CheckActiveIncident(int i) => i == ActiveIncident.IncidentID ? "active" : "";
		public string CheckActiveTechnician(int t) => t == ActiveTechnician.TechnicianID ? "active" : "";

	}
}