using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class ProjectItemViewModel
    {
        public ProjectItemViewModel(int id, string title,
      string clientName, string freelancerName, decimal totalCost)
        {
            this.Id = id;
            Title = title;

            ClientName = clientName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string ClientName { get; private set; }
        public string FreelancerName { get; set; }
        public decimal TotalCost { get; private set; }

        public static ProjectItemViewModel FromEntity(Project project)
            => new(project.Id, project.Title, project.Client.FullName, project.Freelancer.FullName, project.TotalCost);


    }
}