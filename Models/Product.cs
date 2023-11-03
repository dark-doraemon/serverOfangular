namespace webapi.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public string img { get;set; }

        //một Product chỉ thuộc về 1 category nên category sẽ là khóa ngoại
        public Category Category { get; set; }

        //mốt product sẽ có nhiều người dùng đặt
        public ICollection<User> Users { get; set; }
    }
}
