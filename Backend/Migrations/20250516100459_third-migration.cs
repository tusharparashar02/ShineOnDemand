using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class thirdmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ServicePackages_PackageId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_WashRequests_Cars_CarId",
                table: "WashRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WashRequests_PromoCodes_PromoCodeId",
                table: "WashRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WashRequests_ServicePackages_PackageId",
                table: "WashRequests");

            migrationBuilder.DropIndex(
                name: "IX_WashRequests_CarId",
                table: "WashRequests");

            migrationBuilder.DropIndex(
                name: "IX_WashRequests_PromoCodeId",
                table: "WashRequests");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CarId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PackageId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "WashRequests");

            migrationBuilder.DropColumn(
                name: "PromoCodeId",
                table: "WashRequests");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "WashRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CarNumber",
                table: "WashRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarNumber",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CarNumber",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "CarNumber");

            migrationBuilder.CreateIndex(
                name: "IX_WashRequests_CarNumber",
                table: "WashRequests",
                column: "CarNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarNumber",
                table: "Orders",
                column: "CarNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cars_CarNumber",
                table: "Orders",
                column: "CarNumber",
                principalTable: "Cars",
                principalColumn: "CarNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WashRequests_Cars_CarNumber",
                table: "WashRequests",
                column: "CarNumber",
                principalTable: "Cars",
                principalColumn: "CarNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WashRequests_ServicePackages_PackageId",
                table: "WashRequests",
                column: "PackageId",
                principalTable: "ServicePackages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cars_CarNumber",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_WashRequests_Cars_CarNumber",
                table: "WashRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WashRequests_ServicePackages_PackageId",
                table: "WashRequests");

            migrationBuilder.DropIndex(
                name: "IX_WashRequests_CarNumber",
                table: "WashRequests");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CarNumber",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarNumber",
                table: "WashRequests");

            migrationBuilder.DropColumn(
                name: "CarNumber",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "WashRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "WashRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PromoCodeId",
                table: "WashRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CarNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WashRequests_CarId",
                table: "WashRequests",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_WashRequests_PromoCodeId",
                table: "WashRequests",
                column: "PromoCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                table: "Orders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PackageId",
                table: "Orders",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ServicePackages_PackageId",
                table: "Orders",
                column: "PackageId",
                principalTable: "ServicePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WashRequests_Cars_CarId",
                table: "WashRequests",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WashRequests_PromoCodes_PromoCodeId",
                table: "WashRequests",
                column: "PromoCodeId",
                principalTable: "PromoCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WashRequests_ServicePackages_PackageId",
                table: "WashRequests",
                column: "PackageId",
                principalTable: "ServicePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
