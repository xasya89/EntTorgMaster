using System.ComponentModel;
using System.Text.Json.Serialization;
using EntTorgMaster.Helpers;

namespace EntTorgMaster.Data
{
    public class Order
    {
        public int Id { get; set; }
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateOnly DateCreate { get; set; }
        public string Shet { get; set; } = "";
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateOnly? ShetDate { get; set; }
        public string CustomerName { get; set; } = "";
        public string CustomerPhone { get; set; } = "";
        public OrderStatus Status { get; set; }
        public string Note { get; set; } = "";
        public List<OrderDoor> OrderDoors { get; set; } = new();
    }

    public enum OrderStatus
    {
        [Description("Новый")]
        New,
        [Description("В работе")]
        Work,
        [Description("Выполнен")]
        Complite,
        [Description("Отгружен")]
        Shipment
    }

    public class OrderDoor
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        public int Position { get; set; }
        public int DoorTypeId { get; set; }
        public DoorType DoorType { get; set; }
        public int Count { get; set; }
        public int H { get; set; }
        public int W { get; set; }
        public int? S { get; set; }
        public bool SEqual { get; set; }
        public OpenType Open { get; set; } = OpenType.Left;
        public string Ral { get; set; } = "";
        public NalichnikType Nalichnik { get; set; } = NalichnikType.No;
        public DovodType Dovod { get; set; } = DovodType.No;
        public string Note { get; set; } = "";
        public string Marking { get; set; } = "";
        public string Shild { get; set; } = "";
        public int? NavesCount { get; set; }
        public int? NavesStvorkaCount { get; set; }
        public int? WindowCount { get; set; }
        public int? WindowStvorkaCount { get; set; }
        public bool Framuga { get; set; }
        public int? FramugaH { get; set; }

        public List<DoorSpecificationWriteof> DoorSpecificationsWriteof { get; set; } = new();
    }

    public enum OpenType
    {
        [Description("Лев")]
        Left,
        [Description("Прав")]
        Right
    }
    public enum NalichnikType
    {
        [Description("Да")]
        Yes,
        [Description("Да с 4х")]
        Yes4,
        [Description("Нет")]
        No
    }
    public enum DovodType
    {
        [Description("Да")]
        Yes,
        [Description("Нет")]
        No,
        [Description("Нет подг")]
        NoPrepare
    }

    public class DoorSpecificationWriteof
    {
        public int Id { get; set; }
        public int OrderDoorId { get; set; }
        [JsonIgnore]
        public OrderDoor OrderDoor { get; set; }
        public int? GoodId { get; set; } = null;
        public Good? Good { get; set; } = null;
        public GoodType GoodType { get; set; }
        public decimal Count { get; set; }
    }
}
