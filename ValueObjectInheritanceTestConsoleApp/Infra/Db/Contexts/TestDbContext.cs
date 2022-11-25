using Haskap.DddBase.Domain.AuditHistoryLogAggregate;
using Haskap.DddBase.Domain.Providers;
using Haskap.DddBase.Infra.Db.Contexts.NpgsqlDbContext;
using Microsoft.EntityFrameworkCore;
using ValueObjectInheritanceTestConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObjectInheritanceTestConsoleApp.Domain;

namespace ValueObjectInheritanceTestConsoleApp.Infra.Db.Contexts;
internal class TestDbContext : DbContext
{
    public TestDbContext()
        : base()
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(TestDbContext).Assembly);

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Database=ValuebjectInheritanceTestDb;User Id=haskap;Password=haskap;Port=5432");
        //optionsBuilder.AddInterceptors(new AuditSaveChangesInterceptor<Guid?>(null));
        //optionsBuilder.AddInterceptors(new AuditHistoryLogSaveChangesInterceptor<Guid?>(null, null));
        optionsBuilder.UseSnakeCaseNamingConvention();
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Customer> Customer { get; set; }
}
