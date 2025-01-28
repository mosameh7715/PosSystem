namespace Pos.Infrastructure.DbModelConfigurations;

public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(c => c.Name).HasMaxLength(50).IsRequired();

        builder.Property(c => c.Address).HasMaxLength(100).IsRequired();
        builder.HasMany(c => c.Invoices)
            .WithOne(i => i.Customer)
            .HasForeignKey(i => i.CustomerId);
    }
}
