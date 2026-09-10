using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dataaccess.Migrations
{
    /// <inheritdoc />
    public partial class role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_emp_DeptID",
                table: "emp");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UsersTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_emp_DeptID",
                table: "emp",
                column: "DeptID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_emp_DeptID",
                table: "emp");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "UsersTbl");

            migrationBuilder.CreateIndex(
                name: "IX_emp_DeptID",
                table: "emp",
                column: "DeptID");
        }
    }
}
