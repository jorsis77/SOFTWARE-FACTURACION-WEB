using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MULTI.Data;

public class MULTIContext : IdentityDbContext<IdentityUser>
{
    public MULTIContext(DbContextOptions<MULTIContext> options,
        IConfiguration config
         //ITenantService service
        )
        : base(options)
    {
        //_CONFIG
      /*  if (service.Tenant != NULL)
        {
            _tenant = service.Tenant!;
        }*/
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //
       /* if (_tenant != null)
        {
            builder.Entity<MULTIContext>()
            .HasQueryFilter(mt => mt.Tenant == _tenant);
        }*/
       
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var tenant = _tenantService.Tenant;
        var connectionStr = _configuration.GetConnectionString(tenant);
        optionsBuilder.UseSqlite(connectionStr);
    }
}
