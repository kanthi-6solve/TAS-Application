using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class tas_columnaddition_20200502 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnhold",
                table: "Tasks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NextApproverLevel",
                table: "TalentRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnhold",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "NextApproverLevel",
                table: "TalentRequests");
        }
    }
}
