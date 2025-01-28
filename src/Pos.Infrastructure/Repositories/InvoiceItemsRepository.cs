namespace Pos.Infrastructure.Repositories;

public class InvoiceItemsRepository : BaseRepository<InvoiceItems, int>, IInvoiceItemsRepository
{
    public InvoiceItemsRepository(PosDbContext context) : base(context)
    {
    }
}