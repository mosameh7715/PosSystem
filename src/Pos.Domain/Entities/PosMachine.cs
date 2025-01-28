namespace Pos.Domain.Entities
{
    public class PosMachine
    {
        public int Id { get; }
        public string Code { get; private set; }
        public virtual List<Invoice> Invoices { get; }

        private PosMachine()
        {
            
        }

        public PosMachine(int id, string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Code is required", nameof(code));
            }
            Id = id;
            Code = code;
        }

        public void Update(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Code is required", nameof(code));
            }
            Code = code;
        }
    }
}
