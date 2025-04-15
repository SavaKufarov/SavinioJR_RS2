using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace DataLayer.Migrations
{
    public partial class PeopleIntrest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "friends",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friends", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "interests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    districtId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interests", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    lastName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    age = table.Column<int>(type: "int", nullable: true),
                    username = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    email = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    friendsId = table.Column<int>(type: "int", nullable: true),
                    districtId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "userfriends",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false),
                    friendsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.userId, x.friendsId });
                    table.ForeignKey(
                        name: "FK_UserFriends_Friends",
                        column: x => x.friendsId,
                        principalTable: "friends",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFriends_User",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FK_UserFriends_Friends",
                table: "userfriends",
                column: "friendsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "interests");

            migrationBuilder.DropTable(
                name: "userfriends");

            migrationBuilder.DropTable(
                name: "friends");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
