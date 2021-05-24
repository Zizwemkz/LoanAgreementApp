using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanAgreementAPI.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ReturnInterest",
                table: "TbCustomerLoan",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "TbCustomerLoan",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ReturnInterest",
                table: "TbCustomerLoan",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<float>(
                name: "Amount",
                table: "TbCustomerLoan",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
