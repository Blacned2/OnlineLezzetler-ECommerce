using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineLezzetler.Data.Migrations
{
    public partial class ten : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_EmployeeID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_EmployeeID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeID",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_EmployeeID",
                table: "Orders",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
