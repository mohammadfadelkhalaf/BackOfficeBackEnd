using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_AspNetUsers_UserId",
                table: "OrderEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEntity_Batches_BatchId",
                table: "OrderEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderEntity",
                table: "OrderEntity");

            migrationBuilder.RenameTable(
                name: "OrderEntity",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEntity_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEntity_BatchId",
                table: "Orders",
                newName: "IX_Orders_BatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Batches_BatchId",
                table: "Orders",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Batches_BatchId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "OrderEntity",
                newName: "IX_OrderEntity_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BatchId",
                table: "OrderEntity",
                newName: "IX_OrderEntity_BatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderEntity",
                table: "OrderEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_AspNetUsers_UserId",
                table: "OrderEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEntity_Batches_BatchId",
                table: "OrderEntity",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
