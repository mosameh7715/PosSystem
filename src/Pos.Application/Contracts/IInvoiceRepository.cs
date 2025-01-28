namespace Pos.Application.Contracts;

public interface IInvoiceRepository : IBaseRepository<Invoice, int>
{
    Task<(IEnumerable<Invoice> data,int count )> GetAllInvoicesWithItemsAsync(int pageIndex, int pageSize);
    Task<Invoice> GetInvoiceByIdAsync(int id);
}
