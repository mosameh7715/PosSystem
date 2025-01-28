using MediatR;
using Pos.Application.DTOs;
using Pos.Application.DTOs.Invoices;

namespace Pos.Application.Features.Invoices.Commands.Update
{
    public class UpdateInvoiceCommand : IRequest<ResponseDto>
    {
        public int InvoiceId { get; }
        public WriteInvoiceDto Invoice { get; }

        public UpdateInvoiceCommand(int invoiceId, WriteInvoiceDto invoice)
        {
            Invoice = invoice;
            InvoiceId = invoiceId;
        }
    }
}
