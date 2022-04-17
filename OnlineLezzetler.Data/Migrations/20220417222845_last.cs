using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineLezzetler.Data.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "OrderDetails",
                newName: "OrderPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderPrice",
                table: "OrderDetails",
                newName: "UnitPrice");
        }
    }
}
