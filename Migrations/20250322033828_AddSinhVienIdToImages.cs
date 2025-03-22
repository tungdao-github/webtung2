using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class AddSinhVienIdToImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "HocPhi",
                table: "sinhvien",
                type: "decimal(10)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SinhVienId",
                table: "image",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_image_SinhVienId",
                table: "image",
                column: "SinhVienId");

            migrationBuilder.AddForeignKey(
                name: "FK_image_sinhvien_SinhVienId",
                table: "image",
                column: "SinhVienId",
                principalTable: "sinhvien",
                principalColumn: "MaSinhVien",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_image_sinhvien_SinhVienId",
                table: "image");

            migrationBuilder.DropIndex(
                name: "IX_image_SinhVienId",
                table: "image");

            migrationBuilder.DropColumn(
                name: "SinhVienId",
                table: "image");

            migrationBuilder.AlterColumn<decimal>(
                name: "HocPhi",
                table: "sinhvien",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10,
                oldNullable: true);
        }
    }
}
