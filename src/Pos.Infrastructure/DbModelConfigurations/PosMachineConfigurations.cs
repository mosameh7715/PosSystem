namespace Pos.Infrastructure.DbModelConfigurations;

public class PosMachineConfigurations : IEntityTypeConfiguration<PosMachine>
{
    public void Configure(EntityTypeBuilder<PosMachine> builder)
    {
        builder.Property(p => p.Id).ValueGeneratedOnAdd();

        builder.Property(p => p.Code).HasMaxLength(50).IsRequired();

        builder.HasMany(p => p.Invoices)
            .WithOne(i => i.PosMachine)
            .HasForeignKey(i => i.PosMachineId);
    }
}
