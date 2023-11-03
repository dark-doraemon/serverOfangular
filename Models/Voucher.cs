namespace webapi.Models
{
    public class Voucher
    {
        public string VoucherId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }    
        public float DiscountPrice { get; set; }    
    }
}
