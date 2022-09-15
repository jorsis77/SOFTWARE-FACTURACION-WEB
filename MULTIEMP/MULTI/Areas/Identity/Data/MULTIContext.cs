using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MULTI.Areas.Identity.Data;
using MULTI.Services;


namespace MULTI.Areas.Identity.Data;

public class MULTIContext : IdentityDbContext<ApplicationUser>    //<IdentityUser>
{
    private  string ?ConnectionString;
    public MULTIContext(DbContextOptions<MULTIContext> options,
        TenantService tenantService
        )
        : base(options)
    {
        ConnectionString = tenantService?.GetConnectionString();
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
      //  if (!optionsBuilder.IsConfigured)
        {
            if (ConnectionString != null)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}
