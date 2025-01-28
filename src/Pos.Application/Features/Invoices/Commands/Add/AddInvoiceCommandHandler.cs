using MediatR;
using Pos.Application.Contracts;
using Pos.Application.DTOs;
using Pos.Application.Profiles.Invoices;

namespace Pos.Application.Features.Invoices.Commands.Add;

internal sealed class AddInvoicecommandHandler : IRequestHandler<AddInvoiceCommand, ResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddInvoicecommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseDto> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
    {
        if (request.Invoice == null || request.Invoice.ItemIds == null || !request.Invoice.ItemIds.Any())
            return ResponseDto.Failure("Invalid invoice data or no items provided");

        var seller = await _unitOfWork.Sellers.GetByIdAsync(request.Invoice.SellerId);
        var customer = await _unitOfWork.Customers.GetByIdAsync(request.Invoice.CustomerId);
        var posMachine = await _unitOfWork.PosMachines.GetByIdAsync(request.Invoice.PosMachineId);
        var items = (await _unitOfWork.Items.FindAsync(item => request.Invoice.ItemIds.Contains(item.Id))).ToList();

        if (seller == null)
            return ResponseDto.Failure("Seller not found");

        if (customer == null)
            return ResponseDto.Failure("Customer not found");

        if (posMachine == null)
            return ResponseDto.Failure("PosMachine not found");

        if (items.Count == 0 || items.Count != request.Invoice.ItemIds.Count)
                return ResponseDto.Failure("One or more items not found");

        Invoice newInvoice = new(request.Invoice.PosMachineId,
                          request.Invoice.SellerId,
                          request.Invoice.CustomerId,
                          request.Invoice.Discount,
                          request.Invoice.Tax);

        foreach (var item in items)
        {
            newInvoice.AddItem(item);
        }

        newInvoice.SetSeller(seller);
        newInvoice.SetCustomer(customer);
        newInvoice.SetPosMachine(posMachine);

        await _unitOfWork.Invoices.AddAsync(newInvoice);

        var changes = await _unitOfWork.CompleteAsync();

        var invoiceDto = newInvoice.MapToInvoiceDto();

        return changes > 0
            ? ResponseDto.Success("Invoice added successfully", invoiceDto)
            : ResponseDto.Failure("Failed to add invoice");
    }
}
