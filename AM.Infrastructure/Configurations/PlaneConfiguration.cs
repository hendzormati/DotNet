﻿using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    internal class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
           builder.HasKey(p => p.PlaneId);
           builder.ToTable("MyPlanes");
           builder.Property(p => p.Capacity).HasColumnName("PlaneCapacity");

        }
    }
}
