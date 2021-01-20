using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataBase",
                columns: table => new
                {
                    idDataBase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDataBase = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ConnetionName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ConnectionString = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TypeDataBase = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataBase", x => x.idDataBase);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    IdTable = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Obj_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Obj_friendly_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Can_Update = table.Column<bool>(type: "bit", nullable: false),
                    Can_Delete = table.Column<bool>(type: "bit", nullable: false),
                    Can_Add = table.Column<bool>(type: "bit", nullable: false),
                    Fk_DataBase_Id = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.IdTable);
                    table.ForeignKey(
                        name: "FK_Tables_Fk_DataBase",
                        column: x => x.Fk_DataBase_Id,
                        principalTable: "DataBase",
                        principalColumn: "idDataBase",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    idFiled = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Field_friendly_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Field_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Max_Length = table.Column<int>(type: "int", nullable: false),
                    IsId = table.Column<bool>(type: "bit", nullable: false),
                    Is_Nullable = table.Column<bool>(type: "bit", nullable: false),
                    Is_Updatable = table.Column<bool>(type: "bit", nullable: false),
                    Is_Listable = table.Column<bool>(type: "bit", nullable: false),
                    Is_Viewtable = table.Column<bool>(type: "bit", nullable: false),
                    Is_Insertable = table.Column<bool>(type: "bit", nullable: true),
                    Fk_Tables_Id = table.Column<int>(type: "int", nullable: true),
                    Relation_id = table.Column<int>(type: "int", nullable: true),
                    Relation_value = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.idFiled);
                    table.ForeignKey(
                        name: "Fk_Tables_Id",
                        column: x => x.Fk_Tables_Id,
                        principalTable: "Tables",
                        principalColumn: "IdTable",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fields_Fk_Tables_Id",
                table: "Fields",
                column: "Fk_Tables_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_Fk_DataBase_Id",
                table: "Tables",
                column: "Fk_DataBase_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "DataBase");
        }
    }
}
