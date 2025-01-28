
using Microsoft.EntityFrameworkCore;
using Pos.Application.Contracts;

namespace Pos.Infrastructure.Repositories;

public class InvoiceRepository : BaseRepository<Invoice, int>, IInvoiceRepository
{
    public InvoiceRepository(PosDbContext context) : base(context)
    {
    }

    public async Task<(IEnumerable<Invoice> data, int count)> GetAllInvoicesWithItemsAsync(int pageIndex, int pageSize)
    {
        var data = await _context.Invoices
            .Include(i => i.Seller)
            .Include(i => i.Customer)
            .Include(i => i.PosMachine)
            .Include(i => i.InvoiceItems)
                .ThenInclude(ii => ii.Item)
            .Skip((pageIndex - 1) * pageSize)  
            .Take(pageSize)  
            .ToListAsync();

        var count = await _context.Invoices.CountAsync();

        return (data, count);
    }



    public async Task<Invoice> GetInvoiceByIdAsync(int id)
    {
        var invoice = await _context.Invoices
            .Include(i => i.Seller)
            .Include(i => i.Customer)
            .Include(i => i.PosMachine)
            .Include(i => i.InvoiceItems)
                .ThenInclude(ii => ii.Item)
            .FirstOrDefaultAsync(i => i.Id == id);

        return invoice;
    }

}
