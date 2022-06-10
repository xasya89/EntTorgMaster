using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntTorgMaster.Data
{
    public class Arrival
    {
        public int Id { get; set; }
        [Required]
        public string Num { get; set; }
        [Required]
        public DateOnly DateArrival { get; set; }
        public int ContractorId { get; set; }
        public Contractor Contractor { get; set; }
        public decimal SumAll { get; set; } = 0;
        public List<ArrivalGood> ArrivalGoods { get; set; } = new();
    }

    public class ArrivalGood
    {
        public int Id { get; set; }
        public int ArrivalId { get; set; }
        public Arrival Arrival { get; set; }
        [Required]
        public int GoodId { get; set; }
        public Good Good { get; set; }
        [Required]
        public decimal Count { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Sum { get => Count * Price; }
    }
}
