namespace Pos.Infrastructure.DbModelConfigurations;

public class InvoiceConfigurations : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.Property(i => i.Id).ValueGeneratedOnAdd();

        builder.Property(i => i.Date).IsRequired();
        builder.Property(i => i.Net).IsRequired();
        builder.Property(i => i.Total).IsRequired();

        builder.HasOne(i => i.PosMachine)
            .WithMany(p => p.Invoices)
            .HasForeignKey(i => i.PosMachineId);

        builder.HasOne(i => i.Seller)
            .WithMany(s => s.Invoices)
            .HasForeignKey(i => i.SellerId);

        builder.HasOne(i => i.Customer)
            .WithMany(c => c.Invoices)
            .HasForeignKey(i => i.CustomerId);

        builder.HasMany(i => i.InvoiceItems)
            .WithOne(ii => ii.Invoice)
            .HasForeignKey(ii => ii.InvoiceId);
    }
}
