using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSEA.Migrations.WSEA
{
    /// <inheritdoc />
    public partial class addMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Realtors",
                columns: table => new
                {
                    id_realtor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    patronymic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AspNetUserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Realtors__318DB275EAEF5B9E", x => x.id_realtor);
                });

            migrationBuilder.CreateTable(
                name: "RealtyTypes",
                columns: table => new
                {
                    id_type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RealtyTy__C3F091E0B10F63B6", x => x.id_type);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    id_request = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    id_realtor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Requests__7ADC39FCF8B79BE4", x => x.id_request);
                    table.ForeignKey(
                        name: "FK__Requests__id_rea__6477ECF3",
                        column: x => x.id_realtor,
                        principalTable: "Realtors",
                        principalColumn: "id_realtor");
                });

            migrationBuilder.CreateTable(
                name: "Realties",
                columns: table => new
                {
                    id_realty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    district = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    house = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    apartment_number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    square_object = table.Column<double>(type: "float", nullable: true),
                    square_area = table.Column<double>(type: "float", nullable: true),
                    material = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    room_count = table.Column<int>(type: "int", nullable: true),
                    floor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    cost = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    year_of_commissioning = table.Column<int>(type: "int", nullable: true),
                    buildDone = table.Column<bool>(type: "bit", nullable: false),
                    rent = table.Column<bool>(type: "bit", nullable: false),
                    cadastral_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    realty_type_id = table.Column<int>(type: "int", nullable: false),
                    id_realtor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Realties__EB07D997A22FAE47", x => x.id_realty);
                    table.ForeignKey(
                        name: "FK__Realties__id_rea__6C190EBB",
                        column: x => x.id_realtor,
                        principalTable: "Realtors",
                        principalColumn: "id_realtor");
                    table.ForeignKey(
                        name: "FK__Realties__realty__6B24EA82",
                        column: x => x.realty_type_id,
                        principalTable: "RealtyTypes",
                        principalColumn: "id_type");
                });

            migrationBuilder.CreateTable(
                name: "RealtyImages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_realty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RealtyIm__3213E83F83B7A1F6", x => x.id);
                    table.ForeignKey(
                        name: "FK__RealtyIma__id_re__6EF57B66",
                        column: x => x.id_realty,
                        principalTable: "Realties",
                        principalColumn: "id_realty");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Realties_id_realtor",
                table: "Realties",
                column: "id_realtor");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_realty_type_id",
                table: "Realties",
                column: "realty_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyImages_id_realty",
                table: "RealtyImages",
                column: "id_realty");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_id_realtor",
                table: "Requests",
                column: "id_realtor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealtyImages");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Realties");

            migrationBuilder.DropTable(
                name: "Realtors");

            migrationBuilder.DropTable(
                name: "RealtyTypes");
        }
    }
}
