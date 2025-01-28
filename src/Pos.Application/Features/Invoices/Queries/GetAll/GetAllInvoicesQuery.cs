using MediatR;
using Pos.Application.DTOs;

namespace Pos.Application.Features.Invoices.Queries.GetAll;

public class GetAllInvoicesQuery : IRequest<ResponseDto>
{
    public GetAllInvoicesQuery(int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
    }

    public int PageIndex { get; }
    public int PageSize { get; }
}
