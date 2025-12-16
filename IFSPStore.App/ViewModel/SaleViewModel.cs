namespace IFSPStore.App.ViewModel
{
    public class SaleViewModel
    {
        public SaleViewModel()
        {
            SaleItems = new List<SaleItemModel>();
        }

        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public int  IdSalesman { get; set; }
        public int IdCustomer { get; set; }
        public List<SaleItemModel> SaleItems { get; set; }

    }

    public class SaleItemModel()
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }

        public decimal TotalPrice { get; set; }
        public int IdSale { get; set; }
        public int IdProduct { get; set; }
    }
}
