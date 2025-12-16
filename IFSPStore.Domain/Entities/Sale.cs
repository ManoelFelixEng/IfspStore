using IFSPStore.Domain.Base;

namespace IFSPStore.Domain.Entities
{
    public class Sale : BaseEntity<int>
    {
        public Sale()
        {
            
        }
        public Sale(int id, DateTime date, decimal totalAmount, User salesman, Customer custumer) : base(id)
        {
            Date = date;
            TotalAmount = totalAmount;
            Salesman = salesman;
            Customer = custumer;
            SaleItens = new List<SaleItem>();
        }

        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public User Salesman { get; set; }
        public Customer Customer { get; set; }
        public List<SaleItem> SaleItens { get; set; } 

    }
     public class SaleItem : BaseEntity<int>
    {
        public SaleItem()
        {
            
        }
        public SaleItem(int id, decimal quantity, decimal unitPrice, decimal totalPrice, Sale sale, Product product) : base(id)
        {
            Quatity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
            Sale = sale;
            Product = product;

        }
        public decimal Quatity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public Sale Sale { get; set; }
        public Product Product { get; set; }

     }
}
