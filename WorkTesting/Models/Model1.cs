namespace WorkTesting.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DBTest")
        {
        }

        public virtual DbSet<Disciplines> Disciplines { get; set; }
        public virtual DbSet<Organisations> Organisations { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<StudentGroups> StudentGroups { get; set; }
        public virtual DbSet<StudentGroupsStaff> StudentGroupsStaff { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disciplines>()
                .Property(e => e.Discipline)
                .IsFixedLength();

            modelBuilder.Entity<Organisations>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Organisations>()
                .Property(e => e.TIN)
                .IsFixedLength();

            modelBuilder.Entity<Organisations>()
                .HasMany(e => e.Staff)
                .WithOptional(e => e.Organisations)
                .HasForeignKey(e => e.OrganisationId);

            modelBuilder.Entity<Organisations>()
                .HasMany(e => e.StudentGroupStaff)
                .WithOptional(e => e.Organisations)
                .HasForeignKey(e => e.OrganisationId);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.StudentGroupsStaff)
                .WithOptional(e => e.Staff)
                .HasForeignKey(e => e.EmployeeId);

            modelBuilder.Entity<StudentGroups>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<StudentGroups>()
                .HasMany(e => e.StudentGroupsStaff)
                .WithOptional(e => e.StudentGroups)
                .HasForeignKey(e => e.StudentGroupId);

            modelBuilder.Entity<Teachers>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Teachers>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Teachers>()
                .HasMany(e => e.Organisations)
                .WithOptional(e => e.Teachers)
                .HasForeignKey(e => e.TeacherID);

            modelBuilder.Entity<Teachers>()
                .HasMany(e => e.StudentGroups)
                .WithOptional(e => e.Teachers)
                .HasForeignKey(e => e.TeacherId);
        }
    }
}
