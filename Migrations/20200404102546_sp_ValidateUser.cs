using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Data.SqlClient;



namespace TAS_AngularCoreProj.Migrations
{
    public partial class sp_ValidateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           
            
            var sp = @"create procedure sp_ValidateUser @UserEmail varchar(4000), @OldPassword varchar(4000)
                        as
                        begin
                        if exists(select * from Users where UserEmail=@UserEmail and OldPassword=@OldPassword)
                        select us.EmployeeID,uro.RoleTitle,us.UserName,us.UserEmail,us.OldPassword,us.isactive,us.DOJ from users us
                        join UserRoles uro on us.RoleFKID=uro.RolePKID where us.UserEmail=@UserEmail
                        and us.OldPassword=@OldPassword and us.IsActive=1;
                        else
                        print 'User does not exist';
                        end";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
