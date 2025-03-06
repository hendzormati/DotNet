using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            // config relation many to many  flights and passengers
            builder.HasMany(f => f.Passengers).WithMany(p => p.Flights).UsingEntity(j => j.ToTable("FlightPassenger"));
            // config one to many relation between plane and flight
            builder.HasOne(f => f.Plane).WithMany(p => p.Flights).HasForeignKey(f => f.PlaneId).OnDelete(DeleteBehavior.Cascade);
            // config exemple of one to one relation
            // builder.HasOne(f => f.Plane).WithOne(p => p.Flight).HasForeignKey<Plane>(p => p.FlightId);

        }
    }
}
