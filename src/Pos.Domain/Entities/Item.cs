namespace Pos.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public List<InvoiceItems> InvoiceItems { get; }

        private Item()
        {
        }

        public Item(int id, string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required", nameof(name));
            }

            if (price <= 0)
            {
                throw new ArgumentException("Price must be greater than zero", nameof(price));
            }

            Name = name;
            Price = price;
            Id = id;
        }

        public void Update(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required", nameof(name));
            }
            if (price <= 0)
            {
                throw new ArgumentException("Price must be greater than zero", nameof(price));
            }
            Name = name;
            Price = price;
        }
    }
}
