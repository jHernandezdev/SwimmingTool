using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwimmingTool.Domain;

namespace SwimmingTool.Infrastructure.DataAccess.Config;

public class SwimmerConfig : IEntityTypeConfiguration<Swimmer>
{
    public void Configure(EntityTypeBuilder<Swimmer> builder)
    {
        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasKey(s => s.Id);
    }
}
