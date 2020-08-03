using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class latestupdate_260420V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "EmploymentTypes");

            migrationBuilder.AddColumn<int>(
                name: "DurationFKID",
                table: "TalentRequests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationFKID",
                table: "TalentRequests");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "EmploymentTypes",
                type: "varchar(4000)",
                nullable: true);
        }
    }
}
