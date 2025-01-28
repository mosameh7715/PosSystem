namespace Pos.Infrastructure.DbModelConfigurations;

public class ItemConfigurations : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.Property(i => i.Id).ValueGeneratedOnAdd();

        builder.Property(i => i.Name).HasMaxLength(50).IsRequired();

        builder.Property(i => i.Price).IsRequired();

        builder.HasMany(i => i.InvoiceItems)
            .WithOne(ii => ii.Item)
            .HasForeignKey(ii => ii.ItemId);
    }
}
