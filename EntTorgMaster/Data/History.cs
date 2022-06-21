using System.ComponentModel.DataAnnotations.Schema;

namespace EntTorgMaster.Data
{
    public class History
    {
        public int Id { get; set; }
        public DateTime Create { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; }
        public HistoryEventType EventType { get; set; }
        public HistoryStatus Status { get; set; }
        public int DocumentId { get; set; }
        [Column(TypeName = "json")]
        public string Document { get; set; }
    }

    public enum HistoryStatus
    {
        Add,
        Edit,
        Delete
    }
    public enum HistoryEventType
    {
        Order,
        Specification,
        Arrival,
        DoorName,
        CalcSetting
    }
}
