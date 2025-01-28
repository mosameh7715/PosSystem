using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pos.Application.DTOs.Invoices;
using Pos.Application.Features.Invoices.Commands.Add;
using Pos.Application.Features.Invoices.Commands.Delete;
using Pos.Application.Features.Invoices.Commands.Update;
using Pos.Application.Features.Invoices.Queries.GetAll;
using Pos.Application.Features.Invoices.Queries.GetById;
using Pos.Domain.Entities;

namespace PosApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public InvoicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAllInvoices")]
    public async Task<ActionResult> GetAllInvoices(int pageIndex, int pageSize)
    {
        return Ok(await _mediator.Send(new GetAllInvoicesQuery(pageIndex, pageSize)));
    }

    [HttpGet("GetInvoiceById/{id}")]
    public async Task<ActionResult<Invoice>> GetInvoiceById(int id)
    {
        var result = await _mediator.Send(new GetInvoiceByIdQuery(id));
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut("UpdateInvoice/{id}")]
    public async Task<IActionResult> UpdateInvoice(int id, [FromBody] WriteInvoiceDto invoice)
    {
        var result = await _mediator.Send(new UpdateInvoiceCommand(id, invoice));
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost("AddInvoice")]
    public async Task<IActionResult> AddInvoice([FromBody] WriteInvoiceDto invoice)
    {
        var result = await _mediator.Send(new AddInvoiceCommand(invoice));
        return result.IsSuccess ? Ok(result) : BadRequest(result); 
    }

    [HttpDelete("DeleteInvoice/{id}")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        var result = await _mediator.Send(new DeleteInvoiceCommand(id));
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
