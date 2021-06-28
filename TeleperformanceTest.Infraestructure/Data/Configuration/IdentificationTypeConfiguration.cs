﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeleperformanceTest.Core.Entities;

namespace TeleperformanceTest.Infraestructure.Data.Configuration
{
    public class IdentificationTypeConfiguration : IEntityTypeConfiguration<IdentificationType>
    {
        public void Configure(EntityTypeBuilder<IdentificationType> builder)
        {
            builder.ToTable("TipoIdentificaciones");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("Id");

            builder.Property(i => i.Name)
                .HasColumnName("Nombre")
                .HasMaxLength(30)
                .IsUnicode(false);
        }
    }
}
