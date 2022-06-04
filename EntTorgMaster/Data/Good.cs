using System.ComponentModel;
using EntTorgMaster.Helpers;

namespace EntTorgMaster.Data
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public string UnitStr { get => Unit.GetEnumDescription() ?? ""; }
        public GoodType Type { get; set; }
        public string TypeStr { get=> Type.GetEnumDescription() ?? ""; }
        public decimal? Volume { get; set; }
        public bool isEnable { get; set; } = true;
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
        [Description("Металл")]
        Metal,
        [Description("Краска")]
        Color,
        [Description("Другое")]
        Other
    }
}
