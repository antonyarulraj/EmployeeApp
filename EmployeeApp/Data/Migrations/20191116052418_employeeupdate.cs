using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeApp.Data.Migrations
{
    public partial class employeeupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_employee_EmployeeId",
                table: "address");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "employee",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "employee",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Salary",
                table: "employee",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "address",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_address_employee_EmployeeId",
                table: "address",
                column: "EmployeeId",
                principalTable: "employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_employee_EmployeeId",
                table: "address");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "employee");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "address",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_address_employee_EmployeeId",
                table: "address",
                column: "EmployeeId",
                principalTable: "employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
