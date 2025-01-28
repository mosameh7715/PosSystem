namespace Pos.Infrastructure.DbModelConfigurations;

public class InvoiceItemsConfigurations : IEntityTypeConfiguration<InvoiceItems>
{
    public void Configure(EntityTypeBuilder<InvoiceItems> builder)
    {
        builder.Property(ii => ii.Id).ValueGeneratedOnAdd();

        builder.HasOne(ii => ii.Invoice)
            .WithMany(i => i.InvoiceItems)
            .HasForeignKey(ii => ii.InvoiceId);

        builder.HasOne(ii => ii.Item)
            .WithMany(i => i.InvoiceItems)
            .HasForeignKey(ii => ii.ItemId);
    }
}
