using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730ebu20211a046.API.Inventory.Domain.Model.Aggregates;
using si730ebu20211a046.API.Inventory.Domain.Model.ValueObjects;
using si730ebu20211a046.API.Observability.Domain.Model.Aggregates;
using si730ebu20211a046.API.Shared.Infrastructure.Persistance.EFC.Configuration.Extensions;

namespace si730ebu20211a046.API.Shared.Infrastructure.Persistance.EFC.Configuration;


public class AppDbContext : DbContext
{
    public DbSet<ThingState> ThingStates { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    /// <summary>
    /// DbConext configuration for the entities
    /// - Apply SnakeCase Naming Convention
    /// - Apply Pluralized Table Naming Convention
    /// </summary>
    /// <param name="builder"></param>
    /// <author>Samira Alvarez Araguache (u20211a046) </author>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        base.OnModelCreating(builder);
            
        // // // Place here your entities configuration
        builder.Entity<Thing>().ToTable("things");
        builder.Entity<Thing>().HasKey(e => e.Id);
        builder.Entity<Thing>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Thing>().Property(e=> e.Model).IsRequired();
        builder.Entity<Thing>().OwnsOne<SerialNumber>(serial => serial.SerialNumberValObj, ex =>
        {
            ex.WithOwner().HasForeignKey("Id");
            ex.Property(serial => serial.Value).HasColumnName("SerialNumber");
        });
        builder.Entity<Thing>().Property(e=> e.OperationModeEnum).IsRequired();
        builder.Entity<Thing>().Property(e=> e.MaximumTemperatureThreshold).IsRequired();
        builder.Entity<Thing>().Property(e=> e.MinimumTemperatureThreshold).IsRequired();
        
        
        //
        builder.Entity<ThingState>().ToTable("thing_states");
        builder.Entity<ThingState>().HasKey(e => e.Id);
        builder.Entity<ThingState>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ThingState>().OwnsOne<SerialNumber>(serial => serial.ThingSerialNumber, ex =>
        {
            ex.WithOwner().HasForeignKey("Id");
            ex.Property(serial => serial.Value).HasColumnName("SerialNumber");
        });
        builder.Entity<ThingState>().Property(e => e.CurrentOperationMode).IsRequired();
        builder.Entity<ThingState>().Property(e => e.CurrentTemperature).IsRequired();
        builder.Entity<ThingState>().Property(e => e.CurrentHumidity).IsRequired();
        builder.Entity<ThingState>().Property(e => e.CollectedAt).IsRequired();
        
        
        
        // // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}