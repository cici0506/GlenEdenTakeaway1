using GlenEdenTakeaway.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GlenEdenTakeaway.Models;

namespace GlenEdenTakeaway.Areas.Identity.Data;

public class IdentityContext : IdentityDbContext<GlenEdenTakeawayUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserrEntityConfiguration());
    }
    
    public class ApplicationUserrEntityConfiguration : IEntityTypeConfiguration<GlenEdenTakeawayUser>
    {
        public void Configure(EntityTypeBuilder<GlenEdenTakeawayUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);

            builder.Property(u => u.LastName).HasMaxLength(255);
        }
            

    }
    
    public DbSet<GlenEdenTakeaway.Models.Customer> Customer { get; set; } = default!;
    
    public DbSet<GlenEdenTakeaway.Models.Employee> Employee { get; set; } = default!;
    
    public DbSet<GlenEdenTakeaway.Models.Menu> Menu { get; set; } = default!;
    
    public DbSet<GlenEdenTakeaway.Models.Order> Order { get; set; } = default!;
    
    public DbSet<GlenEdenTakeaway.Models.Payment> Payment { get; set; } = default!;
    
    public DbSet<GlenEdenTakeaway.Models.PaymentType> PaymentType { get; set; } = default!;
}
