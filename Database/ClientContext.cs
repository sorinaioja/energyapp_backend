using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App.Models
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Device> Devices { get; set; }

        public DbSet<Sensor> Sensors { get; set; }

        public DbSet<Record> Records { get; set; }

        public DbSet<User> Users { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Device>()
                .HasOne(d => d.Client)
                .WithMany(c => c.Devices)
                .HasForeignKey(d => d.ClientId);

        }*/
    }
}
