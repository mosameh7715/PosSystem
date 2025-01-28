namespace Pos.Infrastructure.Repositories;

public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
{
    public CustomerRepository(PosDbContext context) : base(context)
    {
    }
}
