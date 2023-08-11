using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EveryPennyCounts.Migrations
{
    /// <inheritdoc />
    public partial class WithFamilyMember : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionID",
                table: "Transactions",
                newName: "TransactionId");

            migrationBuilder.RenameColumn(
                name: "Titile",
                table: "Categories",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "FamilyMemberId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FamilyMembers",
                columns: table => new
                {
                    FamilyMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMembers", x => x.FamilyMemberId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FamilyMemberId",
                table: "Transactions",
                column: "FamilyMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_FamilyMembers_FamilyMemberId",
                table: "Transactions",
                column: "FamilyMemberId",
                principalTable: "FamilyMembers",
                principalColumn: "FamilyMemberId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_FamilyMembers_FamilyMemberId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "FamilyMembers");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_FamilyMemberId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FamilyMemberId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Transactions",
                newName: "TransactionID");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Categories",
                newName: "Titile");
        }
    }
}
