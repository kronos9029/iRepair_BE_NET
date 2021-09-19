using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iRepair_BE_NET.Migrations
{
    public partial class V0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Company_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Is_Online = table.Column<byte[]>(type: "binary(1)", fixedLength: true, maxLength: 1, nullable: true),
                    Hotline = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Full_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepairMan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Is_Online = table.Column<int>(type: "int", nullable: true),
                    Company_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairMan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairMan_Company",
                        column: x => x.Company_Id,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Is_Default = table.Column<byte[]>(type: "binary(1)", fixedLength: true, maxLength: 1, nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Customer",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinkedAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_LinkedAccount_Customer",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MajorField",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Major_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MajorField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MajorField_Major",
                        column: x => x.Major_Id,
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecializeIn",
                columns: table => new
                {
                    Company_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Major_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_SpecializeIn_Company",
                        column: x => x.Company_Id,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecializeIn_Major",
                        column: x => x.Major_Id,
                        principalTable: "Major",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteBy",
                columns: table => new
                {
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Repairman_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_FavoriteBy_Customer",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavoriteBy_RepairMan",
                        column: x => x.Repairman_Id,
                        principalTable: "RepairMan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Company_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Field_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Service_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Company",
                        column: x => x.Company_Id,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Service_MajorField",
                        column: x => x.Field_Id,
                        principalTable: "MajorField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Service_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Repairman_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Customer_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Create_Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    Payment_Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Customer_Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Feedback_Point = table.Column<int>(type: "int", nullable: true),
                    Feedback_Message = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_RepairMan",
                        column: x => x.Repairman_Id,
                        principalTable: "RepairMan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Service",
                        column: x => x.Service_Id,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkOn",
                columns: table => new
                {
                    Repairman_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Service_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOn", x => new { x.Repairman_Id, x.Service_Id });
                    table.ForeignKey(
                        name: "FK_WorkOn_RepairMan",
                        column: x => x.Repairman_Id,
                        principalTable: "RepairMan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOn_Service",
                        column: x => x.Service_Id,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedBack",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Service_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Feedback_Point = table.Column<int>(type: "int", nullable: true),
                    Feedback_Message = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "OrderEvidence",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_OrderEvidence_Order",
                        column: x => x.Order_Id,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Update_Time = table.Column<DateTime>(type: "datetime", nullable: true),
                    Update_By = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status_From = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status_To = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHistory_Order",
                        column: x => x.Order_Id,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Customer_Id",
                table: "Address",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_EMAIL",
                table: "Customer",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UK_Customer_USERNAME",
                table: "Customer",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBy_Customer_Id",
                table: "FavoriteBy",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteBy_Repairman_Id",
                table: "FavoriteBy",
                column: "Repairman_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBack_Order_Id",
                table: "FeedBack",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBack_Service_Id",
                table: "FeedBack",
                column: "Service_Id");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedAccount_Customer_Id",
                table: "LinkedAccount",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MajorField_Major_Id",
                table: "MajorField",
                column: "Major_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Customer_Id",
                table: "Order",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Repairman_Id",
                table: "Order",
                column: "Repairman_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Service_Id",
                table: "Order",
                column: "Service_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEvidence_Order_Id",
                table: "OrderEvidence",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_Order_Id",
                table: "OrderHistory",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RepairMan_Company_Id",
                table: "RepairMan",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "UK_RepairMan_Email",
                table: "RepairMan",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UK_RepairMan_Phone",
                table: "RepairMan",
                column: "Phone_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_RepairMan_Username",
                table: "RepairMan",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Company_Id",
                table: "Service",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Field_Id",
                table: "Service",
                column: "Field_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializeIn_Company_Id",
                table: "SpecializeIn",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializeIn_Major_Id",
                table: "SpecializeIn",
                column: "Major_Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOn_Service_Id",
                table: "WorkOn",
                column: "Service_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "FavoriteBy");

            migrationBuilder.DropTable(
                name: "FeedBack");

            migrationBuilder.DropTable(
                name: "LinkedAccount");

            migrationBuilder.DropTable(
                name: "OrderEvidence");

            migrationBuilder.DropTable(
                name: "OrderHistory");

            migrationBuilder.DropTable(
                name: "SpecializeIn");

            migrationBuilder.DropTable(
                name: "WorkOn");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "RepairMan");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "MajorField");

            migrationBuilder.DropTable(
                name: "Major");
        }
    }
}
