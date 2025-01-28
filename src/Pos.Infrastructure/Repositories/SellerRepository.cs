namespace Pos.Infrastructure.Repositories;

public class SellerRepository : BaseRepository<Seller, int>, ISellerRepository
{
    public SellerRepository(PosDbContext context) : base(context)
    {
    }
}
