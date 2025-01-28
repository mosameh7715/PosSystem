namespace Pos.Application.Contracts;

public interface IUnitOfWork : IDisposable
{
    IInvoiceRepository Invoices { get; }
    IItemRepository Items { get; }
    IPosMachineRepository PosMachines { get; }
    ISellerRepository Sellers { get; }
    ICustomerRepository Customers { get; }
    IInvoiceItemsRepository InvoiceItems { get; }


    Task<int> CompleteAsync();
}