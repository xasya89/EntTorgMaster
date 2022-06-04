using System.ComponentModel;

namespace EntTorgMaster.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        [Description("Администратор")]
        Administrator,
        [Description("Менеджер")]
        Manager,
        [Description("Кладовщик")]
        Stocker
    }
}
