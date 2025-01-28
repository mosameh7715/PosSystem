using Pos.Application.DTOs.Invoices;
using Pos.Application.DTOs.Item;

namespace Pos.Application.Profiles.Invoices;

public static class InvoiceMapper
{
    public static ReadInvoiceDto MapToInvoiceDto(this Invoice invoice)
    {
        return new ReadInvoiceDto
        {
            Id = invoice.Id,
            SellerName = invoice.Seller.Name,
            CustomerName = invoice.Customer.Name,
            CustomerAddress = invoice.Customer.Address,
            PosMachineCode = invoice.PosMachine.Code,
            Total = invoice.Total,
            Tax = invoice.Tax,
            Date = invoice.Date,
            Discount = invoice.Discount,
            Net = invoice.Net,
            Items = invoice.InvoiceItems.Select(x => new ItemDto
            {
                Id = x.Item.Id,
                Name = x.Item.Name,
                Price = x.Item.Price
            }).ToList(),
        };
    }
}
