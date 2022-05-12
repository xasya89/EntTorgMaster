using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntTorgMaster.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateOnly DateCreate { get; set; }
        public string Shet { get; set; }
        public DateOnly? ShetDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public OrderModelStatus Status { get; set; }
        public string Note { get; set; }
        public List<OrderModelDoor> OrderDoors { get; set; } = new();
    }

    public enum OrderModelStatus
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

    public class OrderModelDoor
    {
        public int Position { get; set; }
        public string Name { get; set; } = "Дверь ДМ";
        public int? Count { get; set; }
        public int? H { get; set; }
        public int? W { get; set; }
        public int? S { get; set; }
        public bool SEqual { get; set; }
        public OpenModelType Open { get; set; }
        public string Ral { get; set; }
        public NalichnikModelType Nalichnik { get; set; }
        public DovodModelType Dovod { get; set; }
        public string Note { get; set; }
        public string Marking { get; set; }
        public string Shild { get; set; }
        public int? NavesCount { get; set; }
        public int? NavesStvorkaCount { get; set; }
        public int? WindowCount { get; set; }
        public int? WindowStvorkaCount { get; set; }
        public bool Framuga { get; set; }
        public int? FramugaH { get; set; }
    }

    public enum OpenModelType
    {
        [Description("Лев")]
        Left,
        [Description("Прав")]
        Right,
        [Description("")]
        None
    }
    public enum NalichnikModelType
    {
        [Description("Да")]
        Yes,
        [Description("Да с 4х")]
        Yes4,
        [Description("Нет")]
        No,
        [Description("")]
        None
    }
    public enum DovodModelType
    {
        [Description("Да")]
        Yes,
        [Description("Нет")]
        No,
        [Description("Нет подг")]
        NoPrepare,
        [Description("")]
        None
    }
}
