namespace Pos.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int PosMachineId { get; }
        public int SellerId { get; }
        public int CustomerId { get; }
        public DateTime Date { get; }
        public decimal Total { get; private set; }
        public decimal Discount { get; private set; }
        public decimal Net { get; private set; }
        public decimal Tax { get; private set; }
        public virtual PosMachine PosMachine { get; private set; }
        public virtual Seller Seller { get; private set; }
        public virtual Customer Customer { get; private set; }
        public virtual List<InvoiceItems> InvoiceItems { get; private set; }

        private Invoice()
        {
            
        }

        public Invoice(int posMachineId,
                       int sellerId,
                       int customerId,
                       decimal discount,
                       decimal tax)
        {
            PosMachineId = posMachineId;
            SellerId = sellerId;
            CustomerId = customerId;
            Date = DateTime.UtcNow;
            Tax = Math.Abs(tax);
            Discount = Math.Abs(discount);

            InvoiceItems = new List<InvoiceItems>();

            CalculatePrices(Discount, Tax); 
        }

        public void SetPosMachine(PosMachine posMachine)
        {
            PosMachine = posMachine;
        }
        public void SetSeller(Seller seller)
        {
            Seller = seller;
        }
        public void SetCustomer(Customer customer)
        {
            Customer = customer;
        }
        public void AddItem(Item item)
        {
            InvoiceItems.Add(new InvoiceItems(this, item));
            CalculatePrices(Discount, Tax);
        }
        private void CalculatePrices(decimal discount,
                                     decimal tax)
        {
            Total = InvoiceItems?.Sum(x => x.Item.Price) ?? 0;
            Net = (Total + Tax) - Discount;
        }

        public void Update(PosMachine posMachine,
                           Customer customer,
                           Seller seller,
                           List<Item> items,
                           decimal discount,
                           decimal tax)
        {
            SetPosMachine(posMachine);
            SetCustomer(customer);
            SetSeller(seller);
            UpdateInvoiceItems(items); 
            Discount = Math.Abs(discount);
            Tax = Math.Abs(tax);
            CalculatePrices(Discount, Tax);
        }

        private void UpdateInvoiceItems(List<Item> items)
        {
            RemoveItems();

            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public void RemoveItems()
        {
            InvoiceItems.Clear();
            CalculatePrices(Discount, Tax);
        }
    }
}
