using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AksaraBackendApi.Migrations
{
    /// <inheritdoc />
    public partial class Migrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeModels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmployeeModels",
                columns: new[] { "Id", "Email", "NIP", "Password", "Phone", "Role", "Username" },
                values: new object[] { 1, "admin@myvin.cafe", "123456789", "$2a$11$S6xp537tCo7I/qwckajqWura5AyQ0tGQc60n5tR4VuRRFHNigtaMC", "081234567890", "Admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeModels");
        }
    }
}
