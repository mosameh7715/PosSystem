using MediatR;
using Pos.Application.Contracts;
using Pos.Application.DTOs;
using Pos.Application.Profiles.Invoices;

namespace Pos.Application.Features.Invoices.Commands.Update;

internal sealed class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, ResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateInvoiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseDto> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await _unitOfWork.Invoices.GetInvoiceByIdAsync(request.InvoiceId);

        if (invoice == null)
            return ResponseDto.Failure("Invoice not found");

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

        if (items.Count == 0|| items.Count != request.Invoice.ItemIds.Count)
            return ResponseDto.Failure("One or more items not found");


        invoice.Update(posMachine,customer,seller, items, request.Invoice.Discount, request.Invoice.Tax);

        _unitOfWork.Invoices.Update(invoice);

        var invoiceDto = invoice.MapToInvoiceDto();


        var changes = await _unitOfWork.CompleteAsync();

        return changes > 0
            ? ResponseDto.Success("Invoice updated successfully", invoiceDto)
            : ResponseDto.Failure("Failed to update invoice");
    }
}