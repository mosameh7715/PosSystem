using MediatR;
using Pos.Application.DTOs;

namespace Pos.Application.Features.Invoices.Commands.Delete;

public class DeleteInvoiceCommand : IRequest<ResponseDto>
{
    public int Id { get; }

    public DeleteInvoiceCommand(int id)
    {
        Id = id;
    }
}
