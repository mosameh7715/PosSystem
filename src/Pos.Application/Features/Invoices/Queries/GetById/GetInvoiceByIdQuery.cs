using MediatR;
using Pos.Application.DTOs;

namespace Pos.Application.Features.Invoices.Queries.GetById
{
    public class GetInvoiceByIdQuery : IRequest<ResponseDto>    
    {
        public int Id { get; }

        public GetInvoiceByIdQuery(int id)
        {
            Id = id;
        }
    }
}
