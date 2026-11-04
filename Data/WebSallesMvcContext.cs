using Microsoft.EntityFrameworkCore;

public class WebSallesMvcContext(DbContextOptions<WebSallesMvcContext> options) : DbContext(options)
{
    public DbSet<WebSallesMvc.Models.Department> Department { get; set; } = default!;
}
