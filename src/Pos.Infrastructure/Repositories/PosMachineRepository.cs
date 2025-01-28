namespace Pos.Infrastructure.Repositories;

public class PosMachineRepository : BaseRepository<PosMachine, int>,  IPosMachineRepository
{
    public PosMachineRepository(PosDbContext context) : base(context)
    {
    }
}
