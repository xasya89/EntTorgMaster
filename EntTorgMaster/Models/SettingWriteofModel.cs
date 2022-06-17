using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EntTorgMaster.Data;

namespace EntTorgMaster.Models
{
    public class SettingWriteofModel
    {
        public GoodType GoodType { get; set; }
        public SettingWriteofTypeCalc TypeCalc { get; set; }
        public SettingWriteofDoorSizesModel CalcSize { get; set; }
        public SettingWriteofSquareModel CalcSquare { get; set; }
        public SettingWriteofAroundModel CalcAround { get; set; }
        public SettingWriteofUnitModel CalcUnit { get; set; }
        public Good? Good { get; set; }
    }

    public enum SettingWriteofTypeCalc
    {
        [Description("Размеры")]
        DoorSize,
        [Description("Площадь")]
        Square,
        [Description("Периметр")]
        Around,
        [Description("Ед. изделия")]
        Counter
    }

    // Размеры
    public class SettingWriteofDoorSizesModel
    {
        public List<SettingWriteofDoorSizeModel> DoorSizes { get; set; } = new();
    }
    public class SettingWriteofDoorSizeModel
    {
        public int? HWith { get; set; }
        public int? HBy { get; set; }
        public int? WWith { get; set; }
        public int? WBy { get; set; }
        public bool SEqual { get; set; }
        public string SEqualStr
        {
            get => SEqual ? "Двух. ств." : "Одн. ств.";
            set => SEqual = value == "Двух. ств." ? true : false;
        }
        public bool Framug { get; set; }
        public decimal Count { get; set; }
    }

    // Площадь
    public class SettingWriteofSquareModel
    {
        public bool DoubleCount { get; set; }
        public decimal Count { get; set; }
    }

    //Периметр
    public class SettingWriteofAroundModel
    {
        public bool DoubleCount { get; set; }
    }

    //Изделие
    public class SettingWriteofUnitModel
    {
        public decimal Count { get; set; }
    }
}
