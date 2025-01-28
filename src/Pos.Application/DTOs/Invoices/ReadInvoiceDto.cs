using Pos.Application.DTOs.Item;

namespace Pos.Application.DTOs.Invoices
{
    public class ReadInvoiceDto
    {
        public int Id { get; set; }
        public string PosMachineCode { get; set; }
        public string SellerName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get;  set; }
        public decimal Discount { get;  set; }
        public decimal Net { get;  set; }
        public decimal Tax { get;  set; }
        public virtual List<ItemDto> Items { get; set; }
    }
}
