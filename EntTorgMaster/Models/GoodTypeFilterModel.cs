using System.ComponentModel;

namespace EntTorgMaster.Models
{
    public enum GoodTypeFilterModel
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
        [Description("")]
        None,
    }
}
