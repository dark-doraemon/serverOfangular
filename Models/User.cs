namespace webapi.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public string Address { get; set; }

        //một khách hàng sẽ có nhiều bill
        public ICollection<Bill> Bills { get; set; }

        //mốt khách hàng sẽ có nhiều Product
        public ICollection<Product> products { get; set; }

        //một khách hàng sẽ có nhiều role
        public ICollection<Role> Roles { get; set; }


    }
}
