namespace IFSPStore.App.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public DateTime DateShop { get; set; }
        public string SalesUnit { get; set; }
        public int IdCategory { get; set; }
    }
}
