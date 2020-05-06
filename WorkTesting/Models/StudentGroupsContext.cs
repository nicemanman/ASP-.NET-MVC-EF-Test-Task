namespace WorkTesting.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentGroupsContext : DbContext
    {
        public StudentGroupsContext()
            : base("name=DBTest")
        {
        }

        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<Organisation> Organisations { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentGroup> StudentGroups { get; set; }
        public virtual DbSet<StudentInGroup> StudentsInGroups { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discipline>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Organisation>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Organisation>()
                .Property(e => e.TIN)
                .IsFixedLength();

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Organisations)
                .HasForeignKey(e => e.OrganisationId);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.StudentsInGroups)
                .WithOptional(e => e.Organisations)
                .HasForeignKey(e => e.OrganisationId);

            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentGroupsStaff)
                .WithOptional(e => e.Staff)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<StudentGroup>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<StudentGroup>()
                .HasMany(e => e.StudentGroupsStaff)
                .WithOptional(e => e.StudentGroups)
                .HasForeignKey(e => e.StudentGroupId);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Organisations)
                .WithOptional(e => e.Teachers)
                .HasForeignKey(e => e.TeacherID);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.StudentGroups)
                .WithOptional(e => e.Teachers)
                .HasForeignKey(e => e.TeacherId);
        }
    }
}
