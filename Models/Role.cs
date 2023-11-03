namespace webapi.Models
{
    public class Role
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        //một role sẽ có nhiều người 
        public ICollection<User> Users { get; set; }
    }
}
