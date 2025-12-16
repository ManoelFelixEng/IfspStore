

using IFSPStore.Domain.Base;

namespace IFSPStore.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        
        public Product()
        {
            
        }
        public Product(int id, string name, decimal price, decimal quantity, DateTime dateShop, string salesUnit, Category category) : base(id)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            DateShop = dateShop;
            SalesUnit = salesUnit;
            Category = category;
        }
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public DateTime DateShop { get; set; }
        public string SalesUnit { get; set; }
        public Category Category { get; set; }
    }
}
