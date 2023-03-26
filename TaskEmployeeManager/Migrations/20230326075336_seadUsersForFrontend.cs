using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskEmployeeManager.Migrations
{
    public partial class seadUsersForFrontend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                   table: "AspNetUsers",
                    columns: new[] { "Id", "Name", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount" },
                  values: new object[] { "e1d28b20-122b-4147-9d1f-a333c56896c5", "davidmonir", "davidmonir17", "davidmonir17".ToUpper(), "davidmonir17@gmail.com", "davidmonir17@gmail.com".ToUpper(), bool.Parse("False"), "AQAAAAEAACcQAAAAEPN/hAYXFSvzFFHirt28KHqmIOxiM9yxsJ7R+S4K7bMUq4L4X2Xqj+UP/Phay5mPXQ==", bool.Parse("False"), bool.Parse("False"), bool.Parse("True"), 0 }

                  );
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                 columns: new[] { "UserId", "RoleId" },
               values: new object[] { "e1d28b20-122b-4147-9d1f-a333c56896c5", "04d18d7c-94e8-49a5-acb9-7eaf1c1c3877" }

               );
            migrationBuilder.InsertData(
            table: "Depertments",
             columns: new[] { "Id", "Name" },
           values: new object[] { "17", "devops" }

           );

            migrationBuilder.InsertData(
               table: "Employees",
                columns: new[] { "Id", "Name", "Phone", "Birthday", "Email", "depId" },
              values: new object[] { "2007", "david mounir", "1202416929", "1997-09-17 00:00:00.0000000", "davidmonir17@gmail.com", "17" }

              );
            migrationBuilder.UpdateData(
     table: "Depertments",
     keyColumn: "Id",
     keyValue: "17",
     column: "MangerId",
     value: "2007");

            migrationBuilder.InsertData(
         table: "Statues",
          columns: new[] { "Id", "Name" },
        values: new object[] { "1", "Assigned" }

        );
            migrationBuilder.InsertData(
     table: "Statues",
      columns: new[] { "Id", "Name" },
    values: new object[] { "2", "In Prograss" }

    );
            migrationBuilder.InsertData(
     table: "Statues",
      columns: new[] { "Id", "Name" },
    values: new object[] { "3", "Closed" }

    );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetUsers]");
            migrationBuilder.Sql("DELETE FROM [AspNetUserRoles]");
            migrationBuilder.Sql("DELETE FROM [Depertments]");
            migrationBuilder.Sql("DELETE FROM [Employees]");
            migrationBuilder.Sql("DELETE FROM [Statues]");
        }
    }
}