using IFSPStore.Domain.Base;

namespace IFSPStore.Domain.Entities
{
    public class Customer : BaseEntity<int>
    {
        public Customer()
        {
            
        }
        public Customer(int id, string name, string address, string district, string documentId, City city) : base(id)
        {
            Name = name;
            Address = address;
            District = district;
            DocumentId = documentId;
            City = city;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string DocumentId { get; set; }
        public City City { get; set; }
    }
        
}
