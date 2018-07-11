using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LittleJohnsHut.DBAccess
{
    public partial class LitteJohnsDBContext : DbContext
    {
        public LitteJohnsDBContext()
        {
        }

        public LitteJohnsDBContext(DbContextOptions<LitteJohnsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaToopingIngrediant> PizzaToopingIngrediant { get; set; }
        public virtual DbSet<ProcessOrder> ProcessOrder { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory", "PizzaPlace");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.NameOfProduct)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PriceOfInventory).HasColumnType("money");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<Inventory>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Pizza");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Location");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("Locations", "PizzaPlace");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdressLine1)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.AdressLine2).HasMaxLength(250);

                entity.Property(e => e.ZipCode).HasMaxLength(20);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("Orders", "PizzaPlace");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Location");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_User");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "PizzaPlace");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Crust)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.NameofPizza)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Sauce)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.SizeOfPizza).HasMaxLength(250);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<Pizza>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_Pizza");
            });

            modelBuilder.Entity<PizzaToopingIngrediant>(entity =>
            {
                entity.ToTable("Pizza_Tooping_Ingrediant", "PizzaPlace");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.PizzaToopingIngrediant)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_Pizza_Invnetory");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaToopingIngrediant)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK_Invnetory_Pizza");
            });

            modelBuilder.Entity<ProcessOrder>(entity =>
            {
                entity.ToTable("Process_Order", "PizzaPlace");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProcessOrder)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Order_Pizza");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.ProcessOrder)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Pizza_Order");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "PizzaPlace");

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__Users__C9F28456658E2BD1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Location");
            });
        }
    }
}
