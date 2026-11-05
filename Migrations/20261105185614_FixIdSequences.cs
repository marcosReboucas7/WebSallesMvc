using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSallesMvc.Migrations
{
    /// <inheritdoc />
    public partial class FixIdSequences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (var table in new[] { "Department", "Seller", "SalesRecord" })
            {
                migrationBuilder.Sql($"""
                    SELECT setval(pg_get_serial_sequence('"{table}"', 'Id'), COALESCE(MAX("Id"), 1), MAX("Id") IS NOT NULL)
                    FROM "{table}";
                    """);
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
