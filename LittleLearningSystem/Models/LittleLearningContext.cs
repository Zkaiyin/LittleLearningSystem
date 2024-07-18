using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LittleLearningSystem.Models;

public partial class LittleLearningContext : DbContext
{
    public LittleLearningContext()
    {
    }

    public LittleLearningContext(DbContextOptions<LittleLearningContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enroll> Enrolls { get; set; }

    public virtual DbSet<Ha> Has { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=LittleLearning;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71A72310B94D");

            entity.Property(e => e.CourseId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CourseID");

            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.CourseWeek)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Enroll>(entity =>
        {
            entity.HasKey(e => e.EnrollId).HasName("PK__Enroll__405B562C4C58DEEE");

            entity.ToTable("Enroll");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Score).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrolls)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enroll_Course");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrolls)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enroll_Student");
        });

        modelBuilder.Entity<Ha>(entity =>
        {
            entity.HasKey(e => e.HasId).HasName("PK__Has__C8ABBCAD3C393339");

            entity.HasOne(d => d.Course).WithMany(p => p.Has)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_CourseMaterial");

            entity.HasOne(d => d.Material).WithMany(p => p.Has)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK_Material");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__Material__C50610F7CA45FD2A");

            entity.ToTable("Material");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.FileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            entity.Property(e => e.FileType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");

            
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99986BB5C6");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("StudentID");

            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Spassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SPassword");

            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
