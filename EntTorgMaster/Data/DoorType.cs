using System.Text.Json.Serialization;

namespace EntTorgMaster.Data
{
    public class DoorType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enable { get; set; } = true;

        [JsonIgnore]
        public List<OrderDoor> OrderDoors { get; set; } = new();
    }
}
