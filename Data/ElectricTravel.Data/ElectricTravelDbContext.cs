namespace ElectricTravel.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using ElectricTravel.Data.Common.Models;
    using ElectricTravel.Data.Models;
    using ElectricTravel.Data.Models.Advertisement;
    using ElectricTravel.Data.Models.Car;
    using ElectricTravel.Data.Models.Charging;
    using ElectricTravel.Data.Models.Location;
    using ElectricTravel.Data.Models.Message;
    using ElectricTravel.Data.Models.Multimedia;
    using ElectricTravel.Data.Models.News;
    using ElectricTravel.Data.Models.User;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ElectricTravelDbContext : IdentityDbContext<ElectricTravelUser, Role, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ElectricTravelDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ElectricTravelDbContext(DbContextOptions<ElectricTravelDbContext> options)
            : base(options)
        {
        }

        public DbSet<CarAdvert> CarAdverts { get; set; }

        public DbSet<SharedTravelAdvert> SharedTravelAdverts { get; set; }

        public DbSet<ElectricCar> Cars { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<SharedTravelStatus> SharedTravelStatus { get; set; }

        public DbSet<CarAdvertStatus> CarAdvertStatus { get; set; }

        public DbSet<TypeTravel> TypeTravels { get; set; }

        public DbSet<StationCategory> StationCategories { get; set; }

        public DbSet<ImageType> ImageTypes { get; set; }

        public DbSet<Make> Makes { get; set; }

        public DbSet<CarTypeMake> CarTypeMakes { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<CarType> CarTypes { get; set; }

        public DbSet<ChargingStation> ChargingStations { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<StationPayment> StationPayments { get; set; }

        public DbSet<Socket> Sockets { get; set; }

        public DbSet<SocketPower> SocketPowers { get; set; }

        public DbSet<SocketType> SocketTypes { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Source> Sources { get; set; }

        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<UserRating> UserRatings { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<UserAddress>()
                .HasKey(ua => new { ua.UserId, ua.AddressId });

            builder.Entity<UserGroup>()
                .HasKey(ug => new { ug.UserId, ug.GroupId });

            builder.Entity<StationPayment>()
                .HasKey(sp => new { sp.PaymentId, sp.ChargingStationId });

            builder.Entity<CarTypeMake>()
               .HasKey(ctm => new { ctm.CarTypeId, ctm.MakeId });

            builder.Entity<StationCategory>()
                .HasKey(sc => new { sc.CategoryId, sc.StationId });
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
