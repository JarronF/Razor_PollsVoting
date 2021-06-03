using Microsoft.EntityFrameworkCore.Migrations;

namespace Razor_PollsVoting.Migrations
{
    public partial class RemoveFieldsFromPollAndChoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeenAnswered",
                table: "Poll");

            migrationBuilder.DropColumn(
                name: "UserPicked",
                table: "Choice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BeenAnswered",
                table: "Poll",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UserPicked",
                table: "Choice",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
