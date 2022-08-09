using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Posterr.Infrastructure.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PostMessage = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    RepostId = table.Column<Guid>(nullable: true),
                    Created = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 14, nullable: false),
                    UserScreenName = table.Column<string>(maxLength: 14, nullable: false),
                    ProfileImageUrl = table.Column<string>(maxLength: 100, nullable: true),
                    Created = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "UserName", "UserScreenName", "ProfileImageUrl", "Created" },
                values: new object[,]
                {
                                { "f9028ad9-c2a6-4467-b739-549a3d8e25eb", "test1","test1",null,"August 09, 2022" },
                                { "c9930f0e-e8e3-419b-b7e4-c169f42e6545", "test2","test2",null,"August 08, 2022" },
                                { "5fcc945d-6ed2-40b6-bf21-2a090e99588c", "test3","test3",null,"August 07, 2022" },
                                { "5a55a21c-2144-432c-943c-6530b0143cac", "test4","test4",null,"August 06, 2022" }
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
