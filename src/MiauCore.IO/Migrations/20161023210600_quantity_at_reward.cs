using Microsoft.EntityFrameworkCore.Migrations;

namespace MiauCore.IO.Migrations
{
    public partial class quantity_at_reward : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Rewards",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Rewards");
        }
    }
}
