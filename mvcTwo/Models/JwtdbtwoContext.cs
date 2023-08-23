using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mvcTwo.Models;

public partial class JwtdbtwoContext : DbContext
{
    public JwtdbtwoContext()
    {
    }

    public JwtdbtwoContext(DbContextOptions<JwtdbtwoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=NITRO-5-FROM-RK\\SQLEXPRESS;Database=jwtdbtwo;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DptId).HasName("PK__departme__ED35D9F7B09AB18D");

            entity.ToTable("department");

            entity.Property(e => e.DptId).HasColumnName("dptId");
            entity.Property(e => e.DptName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dptName");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__CB9A1CFF2DA59130");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "UQ__user__AB6E6164EA69C045").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Contact).HasColumnName("contact");
            entity.Property(e => e.DptId).HasColumnName("dptId");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('user')")
                .HasColumnName("role");

            entity.HasOne(d => d.Dpt).WithMany(p => p.Users)
                .HasForeignKey(d => d.DptId)
                .HasConstraintName("FK__user__dptId__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
