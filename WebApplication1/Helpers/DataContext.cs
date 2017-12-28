using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;


namespace WebApplication1.Helpers
{
    public class DataContext : DbContext

    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Person> Person { get; set; }

        public DbSet<Enrollment> Enrollment { get; set; }

        public DbSet<Course> Course { get; set; }


        //Fluent API definicion have falta ??
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //modelBuilder.Entity<Student>()
            //    .HasMany(c => c.Enrollment)
            //    .WithOne(e => e.Student);

            modelBuilder.Entity<Enrollment>()
            .HasOne(s => s.Student)
            .WithMany(e => e.Enrollment);

            modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany( c => c.Enrollments);


        }







    }

    

}
