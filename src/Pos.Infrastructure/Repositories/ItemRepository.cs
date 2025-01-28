namespace Pos.Infrastructure.Repositories;

public class ItemRepository : BaseRepository<Item, int>,  IItemRepository
{
    public ItemRepository(PosDbContext context) : base(context)
    {
    }
}
