namespace Pos.Infrastructure;

public class PosDbContext : DbContext
{
    public PosDbContext(DbContextOptions<PosDbContext> options) : base(options)
    {
    }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PosMachine> PosMachines { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<InvoiceItems> InvoiceItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PosDbContext).Assembly);

        #region Seed-for-seller
        modelBuilder.Entity<Seller>().HasData(new Seller(1, "Seller 1", "S1"));
        modelBuilder.Entity<Seller>().HasData(new Seller(2, "Seller 2", "S2"));
        modelBuilder.Entity<Seller>().HasData(new Seller(3, "Seller 3", "S3"));
        #endregion

        #region Seed-for-customer
        modelBuilder.Entity<Customer>().HasData(new Customer(1,"Customer 1", "Cairo"));
        modelBuilder.Entity<Customer>().HasData(new Customer(2,"Customer 2", "Alex"));
        modelBuilder.Entity<Customer>().HasData(new Customer(3,"Customer 3", "Tanta"));
        #endregion

        #region Seed-for-pos
        modelBuilder.Entity<PosMachine>().HasData(new PosMachine(1,"Pos1"));
        modelBuilder.Entity<PosMachine>().HasData(new PosMachine(2,"Pos2"));
        modelBuilder.Entity<PosMachine>().HasData(new PosMachine(3,"Pos3"));
        #endregion

        #region Seed-for-items
        modelBuilder.Entity<Item>().HasData(new Item(1, "Item 1", 10));
        modelBuilder.Entity<Item>().HasData(new Item(2, "Item 2", 20));
        modelBuilder.Entity<Item>().HasData(new Item(3, "Item 3", 30));
        modelBuilder.Entity<Item>().HasData(new Item(4, "Item 4", 40));
        #endregion
    }
}
