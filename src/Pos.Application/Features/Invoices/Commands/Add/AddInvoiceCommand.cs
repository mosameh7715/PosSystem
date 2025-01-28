using MediatR;
using Pos.Application.DTOs;
using Pos.Application.DTOs.Invoices;

namespace Pos.Application.Features.Invoices.Commands.Add;

public class AddInvoiceCommand : IRequest<ResponseDto>
{
    public WriteInvoiceDto Invoice { get; }

    public AddInvoiceCommand(WriteInvoiceDto invoice)
    {
        Invoice = invoice;
    }
}
