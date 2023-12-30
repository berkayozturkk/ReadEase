using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadEase.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "BookID",
            //    table: "Loans",
            //    type: "nvarchar(450)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackTree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.Id);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Loans_BookID",
            //    table: "Loans",
            //    column: "BookID",
            //    unique: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Loans_Books_BookID",
            //    table: "Loans",
            //    column: "BookID",
            //    principalTable: "Books",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Loans_Books_BookID",
            //    table: "Loans");

            migrationBuilder.DropTable(
                name: "ErrorLogs");

            //migrationBuilder.DropIndex(
            //    name: "IX_Loans_BookID",
            //    table: "Loans");

            //migrationBuilder.AlterColumn<string>(
            //    name: "BookID",
            //    table: "Loans",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(450)");
        }
    }
}
