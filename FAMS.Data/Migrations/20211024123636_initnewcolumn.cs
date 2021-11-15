using Microsoft.EntityFrameworkCore.Migrations;

namespace FADMS.Data.Migrations
{
    public partial class initnewcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "liInfoId",
                table: "salesInvoiceMasters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "liInfoId",
                table: "salesInvoiceMasters");
        }
    }
}
