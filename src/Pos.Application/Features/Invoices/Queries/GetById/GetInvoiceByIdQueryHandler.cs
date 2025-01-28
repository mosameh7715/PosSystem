using MediatR;
using Pos.Application.Contracts;
using Pos.Application.DTOs;
using Pos.Application.Profiles.Invoices;

namespace Pos.Application.Features.Invoices.Queries.GetById;

internal sealed class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, ResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetInvoiceByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseDto> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _unitOfWork.Invoices.GetInvoiceByIdAsync(request.Id); 

        if (invoice == null)
            return ResponseDto.Failure("Invoice not found");


        var invoiceDto = invoice.MapToInvoiceDto();

        return ResponseDto.Success("Invoice retrieved successfully", invoiceDto);
    }
}