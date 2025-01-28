namespace Pos.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly PosDbContext _context;
    private IInvoiceRepository _invoiceRepository;
    private IItemRepository _itemRepository;
    private IPosMachineRepository _posMachineRepository;
    private ISellerRepository _sellerRepository;
    private ICustomerRepository _customerRepository;
    private InvoiceItemsRepository _invoiceItemsRepository;

    public UnitOfWork(PosDbContext context)
    {
        _context = context;
    }

    public IInvoiceRepository Invoices => _invoiceRepository ??= new InvoiceRepository(_context);
    public IItemRepository Items => _itemRepository ??= new ItemRepository(_context);
    public IPosMachineRepository PosMachines => _posMachineRepository ??= new PosMachineRepository(_context);
    public ISellerRepository Sellers => _sellerRepository ??= new SellerRepository(_context);
    public ICustomerRepository Customers => _customerRepository ??= new CustomerRepository(_context);
    public IInvoiceItemsRepository InvoiceItems => _invoiceItemsRepository ??= new InvoiceItemsRepository(_context);

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
