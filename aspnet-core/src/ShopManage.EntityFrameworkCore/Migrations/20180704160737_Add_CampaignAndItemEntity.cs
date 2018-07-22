using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ShopManage.Migrations
{
    public partial class Add_CampaignAndItemEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<DateTime>(
            //    name: "BirthDay",
            //    table: "AbpUsers",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<string>(
            //    name: "Portrait",
            //    table: "AbpUsers",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "AbpCampaign",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TenantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpCampaign", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpCampaignItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CampaignId = table.Column<int>(nullable: true),
                    IsDetele = table.Column<bool>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpCampaignItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpCampaignItem_AbpCampaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "AbpCampaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpCampaignItem_CampaignId",
                table: "AbpCampaignItem",
                column: "CampaignId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpCampaignItem");

            migrationBuilder.DropTable(
                name: "AbpCampaign");

            //migrationBuilder.DropColumn(
            //    name: "BirthDay",
            //    table: "AbpUsers");

            //migrationBuilder.DropColumn(
            //    name: "Portrait",
            //    table: "AbpUsers");
        }
    }
}
