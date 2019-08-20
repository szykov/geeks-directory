using Microsoft.EntityFrameworkCore.Migrations;

namespace GeeksDirectory.Data.Migrations
{
    public partial class AddedScoreToSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Profiles_ProfileId",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Skills",
                newName: "GeekProfileProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_ProfileId",
                table: "Skills",
                newName: "IX_Skills_GeekProfileProfileId");

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Profiles_GeekProfileProfileId",
                table: "Skills",
                column: "GeekProfileProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Profiles_GeekProfileProfileId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "GeekProfileProfileId",
                table: "Skills",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_GeekProfileProfileId",
                table: "Skills",
                newName: "IX_Skills_ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Profiles_ProfileId",
                table: "Skills",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
