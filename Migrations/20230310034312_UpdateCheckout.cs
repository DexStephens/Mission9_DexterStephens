using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission9_DexterStephens.Migrations
{
    public partial class UpdateCheckout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Checkouts",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Checkouts");
        }
    }
}
