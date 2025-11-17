using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.VidApp.Migrations
{
    /// <inheritdoc />
    public partial class AddGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genre VALUES (1, 'Horror')");
            migrationBuilder.Sql("INSERT INTO Genre VALUES (2, 'Romance')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
