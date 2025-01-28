namespace Pos.Domain.Entities
{
    public class Customer
    {
        public int Id { get; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public virtual List<Invoice> Invoices { get; }


        private Customer()
        {
        }

        public Customer(int id, string name, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Address is required", nameof(address));
            }
            Id = id;
            Name = name;
            Address = address;
        }

        public void Update(string name, string address)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Address is required", nameof(address));
            }
            Name = name;
            Address = address;
        }
    }
}
