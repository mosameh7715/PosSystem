using MediatR;
using Pos.Application.Contracts;
using Pos.Application.DTOs;

namespace Pos.Application.Features.Invoices.Commands.Delete;

internal sealed class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, ResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteInvoiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseDto> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await _unitOfWork.Invoices.GetInvoiceByIdAsync(request.Id);
        if (invoice == null)
                return ResponseDto.Failure("Invoice not found");

            invoice.RemoveItems(); 

        _unitOfWork.Invoices.Remove(invoice);

       var changes = await _unitOfWork.CompleteAsync();

        return changes > 0
            ? ResponseDto.Success("Invoice deleted successfully")
            : ResponseDto.Failure("Failed to delete invoice");
    }
}
