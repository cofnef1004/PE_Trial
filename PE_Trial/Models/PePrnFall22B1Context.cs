using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PE_Trial.Models;

public partial class PePrnFall22B1Context : DbContext
{
    public PePrnFall22B1Context()
    {
    }

    public PePrnFall22B1Context(DbContextOptions<PePrnFall22B1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Star> Stars { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=LAPTOP-G54QJ7QB\\MSSQLSERVER01; database =PE_PRN_Fall22B1;uid=sa;pwd=123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK_Cour");

            entity.Property(e => e.CourseId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("CourseID");
            entity.Property(e => e.Name).HasMaxLength(35);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK_Dept");

            entity.Property(e => e.DeptId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("DeptID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Dob).HasColumnType("date");
            entity.Property(e => e.FullName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Nationality)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Img)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Language)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ReleaseDate).HasColumnType("date");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Director).WithMany(p => p.Movies)
                .HasForeignKey(d => d.DirectorId)
                .HasConstraintName("FK_Movies_Directors");

            entity.HasOne(d => d.Producer).WithMany(p => p.Movies)
                .HasForeignKey(d => d.ProducerId)
                .HasConstraintName("FK_Movies_Producers");

            entity.HasMany(d => d.Genres).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Movie_Genre_Genres"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Movie_Genre_Movies"),
                    j =>
                    {
                        j.HasKey("MovieId", "GenreId");
                        j.ToTable("Movie_Genre");
                    });

            entity.HasMany(d => d.Stars).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieStar",
                    r => r.HasOne<Star>().WithMany()
                        .HasForeignKey("StarId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Movie_Star_Stars"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Movie_Star_Movies"),
                    j =>
                    {
                        j.HasKey("MovieId", "StarId");
                        j.ToTable("Movie_Star");
                    });
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Productions");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CourseId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("CourseID");
            entity.Property(e => e.Grade)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.StudentId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("StudentID");
        });

        modelBuilder.Entity<Star>(entity =>
        {
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Dob).HasColumnType("date");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nationality)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_Stud");

            entity.Property(e => e.StudentId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.AverageScore).HasColumnType("numeric(4, 2)");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.DeptId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("DeptID");
            entity.Property(e => e.FirstName).HasMaxLength(10);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.PlaceOfBirth).HasMaxLength(30);
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.Students)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__Students__DeptID__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
