using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebTestEx.Models.Data;

namespace WebTestEx.Context
{
    public partial class dbCustomDbSampleContext : DbContext
    {
        public dbCustomDbSampleContext()
        {
        }

        public dbCustomDbSampleContext(DbContextOptions<dbCustomDbSampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CustomTableColumn> CustomTableColumns { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<MenuPermission> MenuPermissions { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Remind> Reminds { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<ToDoItem> ToDoItems { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");
            });

            modelBuilder.Entity<CustomTableColumn>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CustomTableColumn");

                entity.Property(e => e.Field).HasColumnName("field");

                entity.Property(e => e.MemberId)
                    .HasMaxLength(17)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasIndex(e => e.CourseId, "IX_Enrollments_CourseID");

                entity.HasIndex(e => e.StudentId, "IX_Enrollments_StudentID");

                entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Enrollments_Students_StudentID");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(16)
                    .IsFixedLength();

                entity.Property(e => e.MenuName).HasMaxLength(20);

                entity.Property(e => e.MenuType).HasComment("選單類型");
            });

            modelBuilder.Entity<MenuPermission>(entity =>
            {
                entity.HasKey(e => e.MenuPermissionsId)
                    .HasName("PK_Table_1");

                entity.Property(e => e.MenuPermissionsType).HasComment("權限類型(1:for Premissions,2:for UserId)");

                entity.Property(e => e.UserId)
                    .HasMaxLength(16)
                    .IsFixedLength();

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuPermissions)
                    .HasForeignKey(d => d.MenuId)
                    .HasConstraintName("FK_MenuPermissions_Munu");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.PermissionsId);

                entity.Property(e => e.PermissionsName).HasMaxLength(20);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.HasIndex(e => e.BlogId, "IX_Post_BlogId");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.BlogId);
            });

            modelBuilder.Entity<Remind>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Remind");

                entity.Property(e => e.RemindDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Remind_Date");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");
            });

            modelBuilder.Entity<ToDoItem>(entity =>
            {
                entity.ToTable("ToDoItem");

                entity.Property(e => e.AddDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Add_Date");

                entity.Property(e => e.AddMid)
                    .HasMaxLength(17)
                    .HasColumnName("Add_Mid")
                    .IsFixedLength();

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.PlanDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Plan_Date");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_Date");

                entity.Property(e => e.UpdateUid)
                    .HasMaxLength(17)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User");

                entity.Property(e => e.AddDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("add_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId)
                    .HasMaxLength(16)
                    .IsFixedLength();

                entity.Property(e => e.UserName).HasMaxLength(20);

                entity.HasOne(d => d.Permissions)
                    .WithMany()
                    .HasForeignKey(d => d.PermissionsId)
                    .HasConstraintName("FK_Member_Permissions");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
