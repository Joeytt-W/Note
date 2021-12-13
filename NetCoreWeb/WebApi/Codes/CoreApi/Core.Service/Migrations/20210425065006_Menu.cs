using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Service.Migrations
{
    public partial class Menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkSpaces");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "WsAvailable",
                table: "Users",
                newName: "Avaiable");

            migrationBuilder.RenameColumn(
                name: "remark",
                table: "Roles",
                newName: "UpdateUser");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Roles",
                newName: "Avaiable");

            migrationBuilder.RenameColumn(
                name: "Describe",
                table: "Departments",
                newName: "UpdateUser");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "RoleUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "RoleUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MenuUrl = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MenuImageUrl = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Avaiable = table.Column<int>(type: "int", nullable: false),
                    ParentMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuType = table.Column<int>(type: "int", nullable: false),
                    MenuSort = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spell = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MenuRole",
                columns: table => new
                {
                    MenusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRole", x => new { x.MenusID, x.RolesID });
                    table.ForeignKey(
                        name: "FK_MenuRole_Menus_MenusID",
                        column: x => x.MenusID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuRole_Roles_RolesID",
                        column: x => x.RolesID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenus",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenus", x => new { x.MenuID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_RoleMenus_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleMenus_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUsers_RoleID",
                table: "RoleUsers",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRole_RolesID",
                table: "MenuRole",
                column: "RolesID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenus_RoleID",
                table: "RoleMenus",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUsers_Roles_RoleID",
                table: "RoleUsers",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUsers_Users_UserID",
                table: "RoleUsers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUsers_Roles_RoleID",
                table: "RoleUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUsers_Users_UserID",
                table: "RoleUsers");

            migrationBuilder.DropTable(
                name: "MenuRole");

            migrationBuilder.DropTable(
                name: "RoleMenus");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_RoleUsers_RoleID",
                table: "RoleUsers");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "RoleUsers");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "RoleUsers");

            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "Avaiable",
                table: "Users",
                newName: "WsAvailable");

            migrationBuilder.RenameColumn(
                name: "UpdateUser",
                table: "Roles",
                newName: "remark");

            migrationBuilder.RenameColumn(
                name: "Avaiable",
                table: "Roles",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "UpdateUser",
                table: "Departments",
                newName: "Describe");

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Departments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkSpaces",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SpaceCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    wsAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSpaces", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkSpaces_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkSpaces_UserID",
                table: "WorkSpaces",
                column: "UserID",
                unique: true);
        }
    }
}
