using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Car.Migrations
{
    public partial class AddShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartID",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ShoppingCartID",
                table: "Users",
                column: "ShoppingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ShoppingCartID",
                table: "Cars",
                column: "ShoppingCartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_ShoppingCart_ShoppingCartID",
                table: "Cars",
                column: "ShoppingCartID",
                principalTable: "ShoppingCart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ShoppingCart_ShoppingCartID",
                table: "Users",
                column: "ShoppingCartID",
                principalTable: "ShoppingCart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_ShoppingCart_ShoppingCartID",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_ShoppingCart_ShoppingCartID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropIndex(
                name: "IX_Users_ShoppingCartID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ShoppingCartID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShoppingCartID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShoppingCartID",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
