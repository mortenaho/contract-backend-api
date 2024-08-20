using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contract.Repository.Migrations
{
    /// <inheritdoc />
    public partial class hkb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContractNumber",
                table: "Contract",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ContractNumber",
                table: "Contract",
                column: "ContractNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contract_ContractNumber",
                table: "Contract");

            migrationBuilder.AlterColumn<string>(
                name: "ContractNumber",
                table: "Contract",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
