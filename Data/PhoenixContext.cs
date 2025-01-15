using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Phoenix.Data.Models;

namespace Phoenix.Data;

public partial class PhoenixContext : DbContext
{
    public PhoenixContext()
    {
    }

    public PhoenixContext(DbContextOptions<PhoenixContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<MasterMethod> MasterMethods { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomInventory> RoomInventories { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-9P7OECVU\\SQLEXPRESS;Database=phoenix;User Id=nobidev;Password=Nofriyobi19.;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("pk_account");

            entity.ToTable("accounts");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.IsAdministrator).HasColumnName("is_administrator");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GuestId).HasName("pk_guest");

            entity.ToTable("guests");

            entity.HasIndex(e => e.IdNumber, "uc_guest").IsUnique();

            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Citizenship)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("citizenship");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_number");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("middle_name");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.Guests)
                .HasForeignKey(d => d.Username)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_guest_account");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("pk_inventory");

            entity.ToTable("inventories");

            entity.HasIndex(e => e.Name, "uc_inventory").IsUnique();

            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Uom)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("uom");
        });

        modelBuilder.Entity<MasterMethod>(entity =>
        {
            entity.HasKey(e => e.MethodId).HasName("pk_reservation_method");

            entity.ToTable("master_methods");

            entity.Property(e => e.MethodId).HasColumnName("method_id");
            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("pk_reservation");

            entity.ToTable("reservations");

            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.BookDate)
                .HasColumnType("datetime")
                .HasColumnName("book_date");
            entity.Property(e => e.CheckIn)
                .HasColumnType("datetime")
                .HasColumnName("check_in");
            entity.Property(e => e.CheckOut)
                .HasColumnType("datetime")
                .HasColumnName("check_out");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.Remark)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("remark");
            entity.Property(e => e.ReservationCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reservation_code");
            entity.Property(e => e.ReservationMethodId).HasColumnName("reservation_method_id");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.ReservationPaymentMethods)
                .HasForeignKey(d => d.PaymentMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_payment_method");

            entity.HasOne(d => d.ReservationMethod).WithMany(p => p.ReservationReservationMethods)
                .HasForeignKey(d => d.ReservationMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reservation_method");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomNumber).HasName("pk_room");

            entity.ToTable("rooms");

            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("room_number");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_room_type");
        });

        modelBuilder.Entity<RoomInventory>(entity =>
        {
            entity.HasKey(e => e.RoomInventoryId).HasName("pk_room_inventory");

            entity.ToTable("room_inventories");

            entity.Property(e => e.RoomInventoryId).HasColumnName("room_inventory_id");
            entity.Property(e => e.InventoryId).HasColumnName("inventory_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("room_number");
            entity.Property(e => e.Uom)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("uom");

            entity.HasOne(d => d.Inventory).WithMany(p => p.RoomInventories)
                .HasForeignKey(d => d.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_room_inventory_inventory");

            entity.HasOne(d => d.RoomNumberNavigation).WithMany(p => p.RoomInventories)
                .HasForeignKey(d => d.RoomNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_room_inventory_room");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.RoomTypeId).HasName("pk_room_type");

            entity.ToTable("room_types");

            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.GuestLimit).HasColumnName("guest_limit");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
