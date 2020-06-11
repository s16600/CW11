using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW11a.Models
{
    public class PrescriptionDbContext : DbContext
    {
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }
        public PrescriptionDbContext() { }

        public PrescriptionDbContext(DbContextOptions<PrescriptionDbContext> options)
        :base(options){

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription_Medicament>().HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

            modelBuilder.Entity<Doctor>().HasData(new Doctor { IdDoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email = "jkowalski@wp.pl" });
            modelBuilder.Entity<Doctor>().HasData(new Doctor { IdDoctor = 2, FirstName = "Jan", LastName = "Winnicki", Email = "jwinnicki@wp.pl" });
            modelBuilder.Entity<Medicament>().HasData(new Medicament { IdMedicament = 1,  Name = "Aspiryna", Description = "Pomocniczo w leczeniu grypy", Type = "Niesteroidowy lek przeciwzapalny"});
            modelBuilder.Entity<Patient>().HasData(new Patient { IdPatient = 1, FirstName = "Piotr", LastName = "Nowak", Email = "pnowak@wp.pl" });
            modelBuilder.Entity<Prescription>().HasData(new Prescription { IdPrescription = 1, Date = DateTime.Now, DueDate=(DateTime.Now.AddDays(365)), IdPatient = 1, IdDoctor = 1 });
            modelBuilder.Entity<Prescription_Medicament>().HasData(new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 50, Details = "Bez refundacji" });
        }



    }
}
