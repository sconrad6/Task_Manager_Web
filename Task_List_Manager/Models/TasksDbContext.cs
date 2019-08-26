using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Task_List_Manager.Models
{
    public partial class TasksDbContext : DbContext
    {
        public TasksDbContext()
        {
        }

        public TasksDbContext(DbContextOptions<TasksDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<UserInformation> UserInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TasksDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.Property(e => e.TaskDescription).HasMaxLength(256);
            });

            modelBuilder.Entity<UserInformation>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });
        }
    }
}
