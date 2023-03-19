using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TaskEmployeeManager.Migrations
{
    public partial class seadRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                 table: "AspNetRoles",
                  columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() }

                );
            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { Guid.NewGuid().ToString(), "Manager", "Manager".ToUpper(), Guid.NewGuid().ToString() }
           );

            migrationBuilder.InsertData(
              table: "AspNetRoles",
              columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
              values: new object[] { Guid.NewGuid().ToString(), "Employee", "Employee".ToUpper(), Guid.NewGuid().ToString() }
          );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetRoles]");
        }
    }
}