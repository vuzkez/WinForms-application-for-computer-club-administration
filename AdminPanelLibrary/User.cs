using System.Data.Linq.Mapping;

namespace AdminPanelLibrary
{

    [Table(Name = "Users")]
    public class User
    {
        [Column(Name = "UserId", IsPrimaryKey = true, IsDbGenerated = true)]
        public int UserId { get; set; }

        [Column(Name = "Login")]
        public string Login { get; set; }

        [Column(Name = "Password")]
        public string Password { get; set; }

        [Column(Name = "UserRole")]
        public string UserRoleValue { get; set; }
        public UserRole UserRole
        {
            get => Enum.Parse<UserRole>(UserRoleValue);
            set => UserRoleValue = value.ToString();
        }

        [Column(Name = "FullName")]
        public string FullName { get; set; }

        [Column(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
