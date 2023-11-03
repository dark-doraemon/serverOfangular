namespace webapi.Models
{
    public class Bill
    {
        public string BillId { get; set; }
        public string BillName { get; set; }
        public string BillPrice { get; set; }
        public DateTime BillDate { get; set; }

        //một bill chỉ thuộc về 1 khách hàng nên User sẽ làm khóa ngoại
        public User BillUser { get; set; }

    }
}
