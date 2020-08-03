using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TAS_AngularCoreProj.Migrations
{
    public partial class tasmigration_010420 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityPKID);
                });

            migrationBuilder.CreateTable(
                name: "EmailNotifications",
                columns: table => new
                {
                    EmailPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MailingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SenderEmail = table.Column<string>(type: "varchar(4000)", nullable: true),
                    Recepients = table.Column<string>(type: "varchar(4000)", nullable: true),
                    Subject = table.Column<string>(type: "varchar(4000)", nullable: true),
                    MessageBody = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailNotifications", x => x.EmailPKID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StatePKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StatePKID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserPKID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UserEmail = table.Column<string>(type: "varchar(4000)", nullable: true),
                    OldPassword = table.Column<string>(type: "varchar(4000)", nullable: true),
                    NewPassword = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsRemember = table.Column<bool>(type: "bit", nullable: false),
                    Mobile = table.Column<int>(nullable: false),
                    DOJ = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(type: "varchar(4000)", nullable: true),
                    PinCode = table.Column<int>(nullable: false),
                    CityFKID = table.Column<int>(nullable: false),
                    StateFKID = table.Column<int>(nullable: false),
                    RoleFKID = table.Column<int>(nullable: false),
                    ProfileImage = table.Column<string>(type: "varchar(4000)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(4000)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserPKID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "EmailNotifications");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
