using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineLezzetler.Data.Migrations
{
    public partial class seventeenth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShipperType",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipperType",
                table: "Orders");
        }
    }
}
