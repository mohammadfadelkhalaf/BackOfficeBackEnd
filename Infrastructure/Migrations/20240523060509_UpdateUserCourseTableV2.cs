using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserCourseTableV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxMemberCount",
                table: "UserCourses");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "UserCourses",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "IsExpire",
                table: "UserCourses",
                newName: "IsFullyPaid");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "UserCourses",
                newName: "IsCompleted");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserCourses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "UserCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifierId",
                table: "UserCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "UserCourses");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "UserCourses");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "UserCourses",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "IsFullyPaid",
                table: "UserCourses",
                newName: "IsExpire");

            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "UserCourses",
                newName: "IsActive");

            migrationBuilder.AddColumn<decimal>(
                name: "MaxMemberCount",
                table: "UserCourses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
