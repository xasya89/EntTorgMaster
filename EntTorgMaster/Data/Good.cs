using System.ComponentModel;
using EntTorgMaster.Helpers;

namespace EntTorgMaster.Data
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; } = Unit.M;
        public string UnitStr { get => Unit.GetEnumDescription() ?? ""; }
        public GoodType Type { get; set; } = GoodType.Metal15;
        public string TypeStr { get=> Type.GetEnumDescription() ?? ""; }
        public decimal? Volume { get; set; }
        public bool isEnable { get; set; } = true;

        public List<ArrivalGood> ArrivalGoods { get; set; } = new List<ArrivalGood>();
    }

    public enum Unit
    {
        [Description("кг")]
        Kg=166,
        [Description("шт")]
        Ct=796,
        [Description("л")]
        L=112,
        [Description("м")]
        M=006,
        [Description("м кв")]
        M2=055,
        [Description("м пог")]
        Mlen=018
    }
    public enum GoodType
    {
        [Description("Лист 2")]
        Metal20,
        [Description("Лист 1.5")]
        Metal15,
        [Description("Краска")]
        Color,
        [Description("Навесы гаражные")]
        NavesGarage,
        [Description("Навесы дверные")]
        NavesDoor,
        [Description("Ручки")]
        DoorHandle,
        [Description("Замки")]
        DoorLock,
        [Description("Цилиндры")]
        Cilindr,
        [Description("Минераловата")]
        MineralVata,
        [Description("Труба 60x30x1.5")]
        Truba60_30,
        [Description("Труба 50x25x1.5")]
        Truba50_25,
        [Description("Шпингалеты дверные")]
        DoorShpingalet,
        [Description("Другое")]
        Other,
    }
}
