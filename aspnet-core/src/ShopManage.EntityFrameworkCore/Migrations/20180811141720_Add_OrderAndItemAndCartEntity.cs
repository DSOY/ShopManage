using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShopManage.Migrations
{
    public partial class Add_OrderAndItemAndCartEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Area = table.Column<int>(nullable: false),
                    IsDefault = table.Column<int>(nullable: false),
                    IsDetele = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    StreetHouse = table.Column<string>(maxLength: 250, nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpOrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpOrderItem_AbpProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AbpProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbpOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityID = table.Column<int>(nullable: true),
                    AddressModelId = table.Column<int>(nullable: true),
                    BuyerRemark = table.Column<string>(maxLength: 500, nullable: true),
                    Carrier = table.Column<string>(maxLength: 50, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    ExpressID = table.Column<string>(nullable: true),
                    ExpressNO = table.Column<string>(nullable: true),
                    FreightPoint = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    OrderNo = table.Column<string>(nullable: false),
                    PayPoint = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TenantID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpOrder_AbpAddress_AddressModelId",
                        column: x => x.AddressModelId,
                        principalTable: "AbpAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrder_AddressModelId",
                table: "AbpOrder",
                column: "AddressModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrderItem_ProductId",
                table: "AbpOrderItem",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpOrder");

            migrationBuilder.DropTable(
                name: "AbpOrderItem");

            migrationBuilder.DropTable(
                name: "AbpAddress");
        }
    }
}
