using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iRepair_BE_NET.Migrations
{
    public partial class V01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedBack");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedBack",
                columns: table => new
                {
                    Feedback_Message = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Feedback_Point = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Service_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_FeedBack_Order",
                        column: x => x.Order_Id,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FeedBack_Service",
                        column: x => x.Service_Id,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedBack_Order_Id",
                table: "FeedBack",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBack_Service_Id",
                table: "FeedBack",
                column: "Service_Id");
        }
    }
}
