using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
   public class SchoolContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<ClassRoomTeacher> ClassRoomTeachers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer("Server = .; Database = School; User Id = sa; Password = 123456");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
            //Property Configurations
            modelBuilder.Entity<Student>()
            .HasOne<ClassRoom>(s => s.ClassRomm)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.ClassRoom_Id);


            modelBuilder.Entity<Teacher>()
                .Property(s => s.Name)  
                .HasDefaultValue(0)
                .IsRequired();

            modelBuilder.Entity<ClassRoom>()
                .Property(s => s.Name)
                .HasDefaultValue(0)
                .IsRequired();

            modelBuilder.Entity<ClassRoomTeacher>().HasKey(sc => new { sc.ClassRoomId, sc.TeacherId });
            modelBuilder.Entity<ClassRoomTeacher>()
                .HasOne<Teacher>(sc => sc.Teacher)
                .WithMany(s => s.ClassRommTeachers)
                .HasForeignKey(sc => sc.TeacherId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ClassRoomTeacher>()
                .HasOne<ClassRoom>(sc => sc.ClassRoom)
                .WithMany(s => s.ClassRoomTeachers)
                .HasForeignKey(sc => sc.ClassRoomId).OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
