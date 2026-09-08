using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dataaccess.Migrations
{
    /// <inheritdoc />
    public partial class pan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aadhar",
                columns: table => new
                {
                    AadharID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aadhar", x => x.AadharID);
                });

            migrationBuilder.CreateTable(
                name: "Dept2",
                columns: table => new
                {
                    DeptID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dept2", x => x.DeptID);
                });

            migrationBuilder.CreateTable(
                name: "Pan",
                columns: table => new
                {
                    PanNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PanuserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AAdharRefID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pan", x => x.PanNO);
                    table.ForeignKey(
                        name: "FK_Pan_Aadhar_AAdharRefID",
                        column: x => x.AAdharRefID,
                        principalTable: "Aadhar",
                        principalColumn: "AadharID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emp2",
                columns: table => new
                {
                    EID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    xyz = table.Column<int>(type: "int", nullable: false),
                    DeptID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emp2", x => x.EID);
                    table.ForeignKey(
                        name: "FK_Emp2_Dept2_DeptID",
                        column: x => x.DeptID,
                        principalTable: "Dept2",
                        principalColumn: "DeptID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emp2_DeptID",
                table: "Emp2",
                column: "DeptID");

            migrationBuilder.CreateIndex(
                name: "IX_Pan_AAdharRefID",
                table: "Pan",
                column: "AAdharRefID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emp2");

            migrationBuilder.DropTable(
                name: "Pan");

            migrationBuilder.DropTable(
                name: "Dept2");

            migrationBuilder.DropTable(
                name: "Aadhar");
        }
    }
}
