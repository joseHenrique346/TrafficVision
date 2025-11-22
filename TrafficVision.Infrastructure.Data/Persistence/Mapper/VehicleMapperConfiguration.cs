using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrafficVision.Domain.Entities;

namespace TrafficVision.Infrastructure.Data.Persistence;

public class VehicleMapperConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("veiculo");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Model)
            .HasColumnName("modelo")
            .IsRequired();

        builder.Property(x => x.Year)
            .HasColumnName("ano")
            .IsRequired();

        builder.Property(x => x.Brand)
            .HasColumnName("marca")
            .IsRequired();

        builder.Property(x => x.Color)
            .HasColumnName("cor")
            .IsRequired();

        builder.OwnsOne(v => v.VehicleSpec, spec =>
        {
            spec.Property(s => s.Plate).HasColumnName("placa").IsRequired();
            spec.Property(s => s.Renavam).HasColumnName("renavam").IsRequired();
            spec.Property(s => s.Chassis).HasColumnName("chassis").IsRequired();
            spec.Property(s => s.Municipality).HasColumnName("municipio").IsRequired();
            spec.Property(s => s.State).HasColumnName("estado").IsRequired();
            spec.Property(s => s.DataVehicleCondition).HasColumnName("condicao_dados_veiculo").IsRequired();
            spec.Property(s => s.EnumTypeFuelVehicle).HasColumnName("tipo_combustivel").IsRequired();

            // VALUE OBJECT VehicleOwner
            spec.OwnsOne(s => s.Owner, owner =>
            {
                owner.Property(o => o.Name).HasColumnName("nome_dono");
                owner.Property(o => o.CpfCnpj).HasColumnName("cpf_cnpj_dono");
                owner.Property(o => o.Cnh).HasColumnName("cnh_dono");
            });

            // VALUE OBJECT VehicleRestriction
            spec.OwnsOne(s => s.VehicleRestriction, restriction =>
            {
                restriction.Property(r => r.TheftVehicleCondition).HasColumnName("condicao_crime");
                restriction.Property(r => r.Wrecked).HasColumnName("sinistrado");
                restriction.Property(r => r.JudicialRestriction).HasColumnName("restricao_judicial");
                restriction.Property(r => r.Auction).HasColumnName("leiloado");
            });
        });
    }
}