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
}
