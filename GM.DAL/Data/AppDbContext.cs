using System;
using System.Collections.Generic;
using GM.DAL.Domain;
using Microsoft.EntityFrameworkCore;

namespace GM.DAL.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Privatetrain> Privatetrains { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Statusofsub> Statusofsubs { get; set; }

    public virtual DbSet<Sub> Subs { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<TrainersBranch> TrainersBranches { get; set; }

    public virtual DbSet<Typesub> Typesubs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Gym_mangementDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchesId).HasName("PK__BRANCHES__9486489A26CBF85B");

            entity.ToTable("BRANCHES");

            entity.Property(e => e.BranchesId).HasColumnName("branches_id");
            entity.Property(e => e.BranchAddres)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("branch_addres");
            entity.Property(e => e.BranchManger)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("branch_manger_");
            entity.Property(e => e.BranchName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("branch_name_");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoicesId).HasName("PK__INVOICES__3F916312163296FF");

            entity.ToTable("INVOICES");

            entity.Property(e => e.InvoicesId).HasColumnName("Invoices_id");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Payment_Method_");
            entity.Property(e => e.SaleDate)
                .HasColumnType("datetime")
                .HasColumnName("Sale_Date_");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_Price");
        });

        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.HasKey(e => e.InvoiceItemsId).HasName("PK__INVOICE___DA71BA2677A2B922");

            entity.ToTable("INVOICE_ITEMS");

            entity.Property(e => e.InvoiceItemsId).HasColumnName("Invoice_Items_id");
            entity.Property(e => e.InvoicesId).HasColumnName("Invoices_id");
            entity.Property(e => e.ProductId).HasColumnName("product__id");
            entity.Property(e => e.Quantity).HasColumnName("Quantity_");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Unit_Price_");

            entity.HasOne(d => d.Invoices).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.InvoicesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INVOICE_I__Invoi__5812160E");

            entity.HasOne(d => d.Product).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INVOICE_I__produ__59063A47");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__PLAYERS__44DA120C1E69441F");

            entity.ToTable("PLAYERS");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("create_by_");
            entity.Property(e => e.DateJoin).HasColumnName("date_join");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("_last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.PrivateTrainId).HasColumnName("private_train__id");
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.PrivateTrain).WithMany(p => p.Players)
                .HasForeignKey(d => d.PrivateTrainId)
                .HasConstraintName("FK__PLAYERS__private__403A8C7D");
        });

        modelBuilder.Entity<Privatetrain>(entity =>
        {
            entity.HasKey(e => e.PrivateTrainId).HasName("PK__PRIVATET__8F9A2078B947455A");

            entity.ToTable("PRIVATETRAIN");

            entity.Property(e => e.PrivateTrainId).HasColumnName("private_train__id");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.PricePerMonth)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price_per_month");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TheClubsShare)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("The_clubs_share");
            entity.Property(e => e.TrainersId).HasColumnName("trainers_id");

            entity.HasOne(d => d.Trainers).WithMany(p => p.Privatetrains)
                .HasForeignKey(d => d.TrainersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRIVATETR__train__3D5E1FD2");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__PRODUCTS__4562475D15F83676");

            entity.ToTable("PRODUCTS");

            entity.Property(e => e.ProductId).HasColumnName("product__id");
            entity.Property(e => e.CostPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cost_price");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("product_name_");
        });

        modelBuilder.Entity<Statusofsub>(entity =>
        {
            entity.HasKey(e => e.StatusOfSub1).HasName("PK__STATUSOF__24B137EBF3499FD7");

            entity.ToTable("STATUSOFSUB");

            entity.Property(e => e.StatusOfSub1).HasColumnName("status_of_sub");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Sub>(entity =>
        {
            entity.HasKey(e => e.SunId).HasName("PK__SUB__14CA77B3667C5A73");

            entity.ToTable("SUB");

            entity.Property(e => e.SunId).HasColumnName("sun_id");
            entity.Property(e => e.Price)
    .HasColumnName("Price")
    .HasColumnType("decimal(10,2)");

            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.BranchesId).HasColumnName("branches_id");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("create_by_");
            entity.Property(e => e.DateEnd).HasColumnName("date_end_");
            entity.Property(e => e.DateSub).HasColumnName("date_sub");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("payment_method");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.StatusOfSub).HasColumnName("status_of_sub");
            entity.Property(e => e.TypeSubId).HasColumnName("type_sub_id");

            entity.HasOne(d => d.Branches).WithMany(p => p.Subs)
                .HasForeignKey(d => d.BranchesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SUB__branches_id__5070F446");

            entity.HasOne(d => d.Player).WithMany(p => p.Subs)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SUB__player_id__4E88ABD4");

            entity.HasOne(d => d.StatusOfSubNavigation).WithMany(p => p.Subs)
                .HasForeignKey(d => d.StatusOfSub)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SUB__status_of_s__5165187F");

            entity.HasOne(d => d.TypeSub).WithMany(p => p.Subs)
                .HasForeignKey(d => d.TypeSubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SUB__type_sub_id__4F7CD00D");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainersId).HasName("PK__TRAINERS__480ABF9A707F0987");

            entity.ToTable("TRAINERS");

            entity.Property(e => e.TrainersId).HasColumnName("trainers_id");
            entity.Property(e => e.CreateBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("create_by_");
            entity.Property(e => e.DateWork).HasColumnName("date_work");
            entity.Property(e => e.IsActive)
                .HasDefaultValue((byte)1)
                .HasColumnName("is_active");
            entity.Property(e => e.PricePerMonthPrivateTrain)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price_per_month_private_train");
            entity.Property(e => e.SalaryPerMonth)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salary_per_month");
            entity.Property(e => e.Specialization)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TrainersBranch>(entity =>
        {
            entity.HasKey(e => e.TrainersBranchesId).HasName("PK__TRAINERS__53548FC702DD0EED");

            entity.ToTable("TRAINERS_BRANCHES");

            entity.Property(e => e.TrainersBranchesId).HasColumnName("trainers_branches_id");
            entity.Property(e => e.BranchesId).HasColumnName("branches_id");
            entity.Property(e => e.TrainersId).HasColumnName("trainers_id");

            entity.HasOne(d => d.Branches).WithMany(p => p.TrainersBranches)
                .HasForeignKey(d => d.BranchesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TRAINERS___branc__5BE2A6F2");

            entity.HasOne(d => d.Trainers).WithMany(p => p.TrainersBranches)
                .HasForeignKey(d => d.TrainersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TRAINERS___train__5CD6CB2B");
        });

        modelBuilder.Entity<Typesub>(entity =>
        {
            entity.HasKey(e => e.TypeSubId).HasName("PK__TYPESUB__E3DD0B1BD6BC1383");

            entity.ToTable("TYPESUB");

            entity.Property(e => e.TypeSubId).HasColumnName("type_sub_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.TimeSpan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("time_span");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__USERS__B9BE370FD36E55E5");

            entity.ToTable("USERS");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("adress");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue((byte)1)
                .HasColumnName("is_active");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumaer)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_numaer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
