namespace webapi.Models
{
    public class Category
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }


        //mốt category sẽ nhiều product
        //public ICollection<Product> Products { get; set; }
    }
}
