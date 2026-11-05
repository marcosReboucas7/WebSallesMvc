using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebSallesMvc.Models;

public class WebSallesMvcContext(
    DbContextOptions<WebSallesMvcContext> options) 
    : DbContext(options)
{
    public DbSet<Department> Department { get; set; } = default!;
    public DbSet<Seller> Seller { get; set; }
    public DbSet<SalesRecord> SalesRecord { get; set; }

    // Datas do sistema (nascimento, venda) não têm fuso: usa timestamp without time zone,
    // que aceita DateTime de qualquer Kind (incluindo Unspecified vindo de formulários).
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>()
            .HaveColumnType("timestamp without time zone");
    }
}
