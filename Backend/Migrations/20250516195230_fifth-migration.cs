using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class fifthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cars_CarNumber",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cars_CarNumber",
                table: "Orders",
                column: "CarNumber",
                principalTable: "Cars",
                principalColumn: "CarNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cars_CarNumber",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cars_CarNumber",
                table: "Orders",
                column: "CarNumber",
                principalTable: "Cars",
                principalColumn: "CarNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
