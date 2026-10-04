using GM.DAL.Domin;
using GM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GM.DAL.Domin
{
    // علّم كل كيان أنه تابع لنادٍ
    public interface ITenantEntity { int? ClubId { get; set; } }

    public partial class Branch : ITenantEntity { }
    public partial class Invoice : ITenantEntity { }
    public partial class InvoiceItem : ITenantEntity { }
    public partial class Player : ITenantEntity { }
    public partial class Privatetrain : ITenantEntity { }
    public partial class Product : ITenantEntity { }
    public partial class Sub : ITenantEntity { }
    public partial class Trainer : ITenantEntity { }
    public partial class TrainersBranch : ITenantEntity { }
    public partial class Typesub : ITenantEntity { }
    public partial class User : ITenantEntity { }
}

namespace GM.DAL.Data
{
    public partial class AppDbContext
    {
        private readonly ITenantProvider? _tenant;

        // constructor ثانٍ يستقبل مزوّد النادي، والـ DI يختار الأطول
        public AppDbContext(DbContextOptions<AppDbContext> options, ITenantProvider tenant)
            : base(options) => _tenant = tenant;

        private int? CurrentClubId => _tenant?.ClubId;

        partial void OnModelCreatingPartial(ModelBuilder mb)
        {
            mb.Entity<Branch>().HasQueryFilter(e => CurrentClubId != null && e.ClubId == CurrentClubId);
            mb.Entity<Invoice>().HasQueryFilter(e => CurrentClubId != null && e.ClubId == CurrentClubId);
            mb.Entity<InvoiceItem>().HasQueryFilter(e => CurrentClubId != null && e.ClubId == CurrentClubId);
            mb.Entity<Player>().HasQueryFilter(e => CurrentClubId != null && e.ClubId == CurrentClubId);
            mb.Entity<Privatetrain>().HasQueryFilter(e => CurrentClubId != null && e.ClubId == CurrentClubId);
            mb.Entity<Product>().HasQueryFilter(e => CurrentClubId != null && e.ClubId == CurrentClubId);
            mb.Entity<Sub>().HasQueryFilter(e => CurrentClubId != null && e.ClubId == CurrentClubId);
            mb.Entity<Trainer>().HasQueryFilter(e => CurrentClubId != null && e.ClubId == CurrentClubId);
            mb.Entity<TrainersBranch>().HasQueryFilter(e => CurrentClubId != null && e.ClubId == CurrentClubId);
            mb.Entity<Typesub>().HasQueryFilter(e => CurrentClubId != null && e.ClubId == CurrentClubId);
            mb.Entity<User>().HasQueryFilter(e => CurrentClubId != null && e.ClubId == CurrentClubId);
        }

        private void StampClub()
        {
            if (CurrentClubId is not int club) return;
            foreach (var e in ChangeTracker.Entries<ITenantEntity>()
                                           .Where(x => x.State == EntityState.Added))
                e.Entity.ClubId = club;        // نكتب فوق أي قيمة جاءت من العميل
        }

        public override int SaveChanges()
        {
            StampClub();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            StampClub();
            return base.SaveChangesAsync(ct);
        }
    }
}