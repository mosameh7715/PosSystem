using MediatR;
using Pos.Application.Contracts;
using Pos.Application.DTOs;
using Pos.Application.Profiles.Invoices;
using System.Linq.Expressions;

namespace Pos.Application.Features.Invoices.Queries.GetAll;

internal sealed class GetAllInvoicesQueryHandler : IRequestHandler<GetAllInvoicesQuery, ResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllInvoicesQueryHandler( IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseDto> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
    {
        var (data, count) = await _unitOfWork.Invoices.GetAllInvoicesWithItemsAsync(pageIndex: request.PageIndex, pageSize: request.PageSize);

        var invoices = data.Select(x => x.MapToInvoiceDto());

        return ResponseDto.Success("Invoices retrieved successfully", new
        {
            Invoices = invoices,
            TotalCount = count
        });
    }
}