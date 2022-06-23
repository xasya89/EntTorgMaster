using System.Text.Json.Serialization;

namespace EntTorgMaster.Data
{
    public class GoodBalance
    {
        public int Id { get; set; }
        public int GoodId { get; set; }
        public Good Good { get; set; }
        public decimal Count { get; set; } = 0;
        public decimal Price { get; set; } = 0;
    }
}
