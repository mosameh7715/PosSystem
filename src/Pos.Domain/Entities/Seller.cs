namespace Pos.Domain.Entities
{
    public class Seller
    {
        public int Id { get; }
        public string Name { get; private set; }
        public string Code { get; private set; }
        public virtual List<Invoice> Invoices { get; }


        private Seller()
        {
        }

        public Seller(int id, string name, string code)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Code is required", nameof(code));
            }
            Id = id;
            Name = name;
            Code = code;
        }

        public void Update(string name, string code)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is required", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Code is required", nameof(code));
            }
            Name = name;
            Code = code;
        }
    }
}
