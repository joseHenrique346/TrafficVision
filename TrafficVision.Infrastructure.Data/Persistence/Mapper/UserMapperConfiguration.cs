using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrafficVision.Domain.Entities;

namespace TrafficVision.Infrastructure.Data.Persistence;

public class UserMapperConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("usuarios");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("data_criacao")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("data_alteracao");

        builder.OwnsOne(u => u.UserEmail, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("email")
                .IsRequired();
        });

        builder.OwnsOne(u => u.UserPassword, password =>
        {
            password.Property(e => e.Value)
                .HasColumnName("senha")
                .IsRequired();
        });

        builder.Navigation(x => x.UserEmail).IsRequired();
        builder.Navigation(x => x.UserPassword).IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("nome")
            .HasMaxLength(110)
            .IsRequired();

        builder.Property(x => x.UserRole)
            .HasColumnName("cargo")
            .IsRequired();
    }
}
