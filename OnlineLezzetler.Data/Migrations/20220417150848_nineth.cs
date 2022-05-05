using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineLezzetler.Data.Migrations
{
    public partial class nineth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "DetailID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailDetailID",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDetailDetailID",
                table: "Orders",
                column: "OrderDetailDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderDetails_OrderDetailDetailID",
                table: "Orders",
                column: "OrderDetailDetailID",
                principalTable: "OrderDetails",
                principalColumn: "DetailID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderDetails_OrderDetailDetailID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderDetailDetailID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DetailID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDetailDetailID",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
