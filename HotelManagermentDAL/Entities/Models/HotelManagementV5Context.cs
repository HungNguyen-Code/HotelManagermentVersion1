using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace HotelManagermentDAL.Models;

public partial class HotelManagementV5Context : DbContext
{
    public HotelManagementV5Context()
    {
    }

    public HotelManagementV5Context(DbContextOptions<HotelManagementV5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("DB"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__customer__D837D05FE5714179");

            entity.ToTable("customer");

            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Address)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Checkin)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("checkin");
            entity.Property(e => e.Checkout)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("checkout");
            entity.Property(e => e.Checkoutstatus)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValue("NO")
                .HasColumnName("checkoutstatus");
            entity.Property(e => e.Cname)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cname");
            entity.Property(e => e.Dob)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("dob");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Idproof)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("idproof");
            entity.Property(e => e.Mobile).HasColumnName("mobile");
            entity.Property(e => e.Nationality)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nationality");
            entity.Property(e => e.Roomid).HasColumnName("roomid");

            entity.HasOne(d => d.Room).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Roomid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__customer__roomid__3B75D760");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__employee__D9509F6DCA209744");

            entity.ToTable("employee");

            entity.Property(e => e.Eid).HasColumnName("eid");
            entity.Property(e => e.Emailid)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("emailid");
            entity.Property(e => e.Ename)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ename");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Mobile).HasColumnName("mobile");
            entity.Property(e => e.Pass)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("pass");
            entity.Property(e => e.Username)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Roomid).HasName("PK__rooms__6CC4099632DD2DB4");

            entity.ToTable("rooms");

            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Bed)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("bed");
            entity.Property(e => e.Booked)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("NO")
                .HasColumnName("booked");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.RoomNo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("roomNo");
            entity.Property(e => e.RoomType)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("roomType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
