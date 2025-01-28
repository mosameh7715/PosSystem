namespace Pos.Application.DTOs.Invoices;

public record WriteInvoiceDto(int PosMachineId,
                         int SellerId,
                         int CustomerId,
                         List<int> ItemIds,
                         decimal Discount,
                         decimal Tax); 
