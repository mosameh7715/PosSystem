namespace Pos.Domain.Entities
{
    public class InvoiceItems
    {
        public int Id { get; }
        public int InvoiceId { get; }
        public int ItemId { get; }
        public Invoice Invoice { get; }
        public Item Item { get; }


        private InvoiceItems()
        {
                
        }

        public InvoiceItems(Invoice invoice, Item item)
        {
            Invoice = invoice;
            Item = item;
        }
    }
}
