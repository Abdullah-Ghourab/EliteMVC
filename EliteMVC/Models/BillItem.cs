namespace EliteMVC.Models
{
    public class BillItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int Quantity { get; set; } 
        public float UnitPrice { get; set; }
        public float Total { get; set; }
    }

}
