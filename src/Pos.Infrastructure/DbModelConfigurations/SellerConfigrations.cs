namespace Pos.Infrastructure.DbModelConfigurations;

public class SellerConfigrations : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.Property(s => s.Id).ValueGeneratedOnAdd();

        builder.Property(s => s.Name).HasMaxLength(50).IsRequired();

        builder.HasMany(s => s.Invoices)
            .WithOne(i => i.Seller)
            .HasForeignKey(i => i.SellerId);
    }
}
