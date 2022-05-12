﻿using System.ComponentModel;

namespace EntTorgMaster.Data
{
    public class Order
    {
        public int Id { get; set; }
        public DateOnly DateCreate { get; set; }
        public string Shet { get; set; }
        public DateOnly? ShetDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public OrderStatus Status { get; set; }
        public string Note { get; set; }
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
        public int Position { get; set; }
        public string Name { get; set; } = "Дверь ДМ";
        public int? Count { get; set; }
        public int? H { get; set; }
        public int? W { get; set; }
        public int? S { get; set; }
        public bool SEqual { get; set; }
        public OpenType Open { get; set; }
        public string Ral { get; set; }
        public NalichnikType Nalichnik { get; set; }
        public DovodType Dovod { get; set; }
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
}
