using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntTorgMaster.Data
{
    public class Contractor
    {
        public int Id { get; set; }
        [Required]
        public string OrgName { get; set; }
        public string? Inn { get; set; }
        public string? Kpp { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }
        public string? Note { get; set; }

        public List<Arrival> Arrivals { get; set; } = new();
    }
}
