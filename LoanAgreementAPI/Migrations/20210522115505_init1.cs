using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanAgreementAPI.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbCustomerLoan_TbCustomer_Department_ID",
                table: "TbCustomerLoan");

            migrationBuilder.RenameColumn(
                name: "Department_ID",
                table: "TbCustomerLoan",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_TbCustomerLoan_Department_ID",
                table: "TbCustomerLoan",
                newName: "IX_TbCustomerLoan_CustomerId");

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "TbCustomerLoan",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<double>(
                name: "RepoRate",
                table: "TbCustomerLoan",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<float>(
                name: "ReturnInterest",
                table: "TbCustomerLoan",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_TbCustomerLoan_TbCustomer_CustomerId",
                table: "TbCustomerLoan",
                column: "CustomerId",
                principalTable: "TbCustomer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbCustomerLoan_TbCustomer_CustomerId",
                table: "TbCustomerLoan");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "TbCustomerLoan");

            migrationBuilder.DropColumn(
                name: "RepoRate",
                table: "TbCustomerLoan");

            migrationBuilder.DropColumn(
                name: "ReturnInterest",
                table: "TbCustomerLoan");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "TbCustomerLoan",
                newName: "Department_ID");

            migrationBuilder.RenameIndex(
                name: "IX_TbCustomerLoan_CustomerId",
                table: "TbCustomerLoan",
                newName: "IX_TbCustomerLoan_Department_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TbCustomerLoan_TbCustomer_Department_ID",
                table: "TbCustomerLoan",
                column: "Department_ID",
                principalTable: "TbCustomer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
