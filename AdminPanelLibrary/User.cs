namespace AdminPanelLibrary
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
    }
}
