using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrafficVision.Domain.Entities;

namespace TrafficVision.Infrastructure.Data.Persistence;

public class ReportRegistrationMapperConfiguration : IEntityTypeConfiguration<ReportRegistration>
{
    public void Configure(EntityTypeBuilder<ReportRegistration> builder)
    {
        builder.ToTable("registro_relatorio");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("data_criacao")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("data_alteracao");

        builder.Property(x => x.UserId)
            .HasColumnName("usuario_id");

        builder.Property(x => x.VehicleId)
            .HasColumnName("veiculo_id");

        builder.HasOne(x => x.User)
       .WithMany()
       .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Vehicle)
       .WithMany()
       .HasForeignKey(x => x.VehicleId);
    }
}