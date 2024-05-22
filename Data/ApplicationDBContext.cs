using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controller;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<EHealthRecord> EHealthRecords { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EHealthRecord>()
            .Property(e => e.PatientId)
            .ValueGeneratedOnAdd();
    }
    }
}