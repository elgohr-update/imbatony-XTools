﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XTools.Database.Migrations.Migrations
{
    public partial class v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Remark = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UniqueName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Remark = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemDataCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Remark = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Sequence = table.Column<int>(type: "INTEGER", nullable: false),
                    HigherId = table.Column<int>(type: "INTEGER", nullable: true),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemDataCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemDataCategory_SystemDataCategory_HigherId",
                        column: x => x.HigherId,
                        principalTable: "SystemDataCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Account = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Nickname = table.Column<string>(type: "TEXT", maxLength: 32, nullable: true),
                    Photo = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Synopsis = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    SigninedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleSecurity",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    SecurityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleSecurity", x => new { x.RoleId, x.SecurityId });
                    table.ForeignKey(
                        name: "FK_RoleSecurity_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleSecurity_Security_SecurityId",
                        column: x => x.SecurityId,
                        principalTable: "Security",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Remark = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Sequence = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemData_SystemDataCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SystemDataCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Name", "Remark", "UpdatedTime" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2020, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "超级管理员", "拥有所有权限", null });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Name", "Remark", "UpdatedTime" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2020, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "测试用户", "只有测试权限", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 21, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "security.service.all", "security.service.all", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 20, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "security.service.refresh", "security.service.refresh", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 19, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "security.service.give", "security.service.give", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 18, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "security.service.list", "security.service.list", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 17, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "role.service.give", "role.service.give", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 16, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "role.service.delete", "role.service.delete", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 15, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "role.service.modify", "role.service.modify", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 14, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "role.service.add", "role.service.add", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 13, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "role.service.list", "role.service.list", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 12, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "user.service.securities", "user.service.securities", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 11, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "user.service.securities.self", "user.service.securities.self", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 10, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "user.service.roles", "user.service.roles", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 9, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "user.service.roles.self", "user.service.roles.self", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 8, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "user.service.change.password", "user.service.change.password", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 7, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "user.service.add", "user.service.add", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 6, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "user.service.delete", "user.service.delete", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 5, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "user.service.modify", "user.service.modify", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "user.service.modify.self", "user.service.modify.self", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "user.service.list", "user.service.list", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "user.service.profile", "user.service.profile", null });

            migrationBuilder.InsertData(
                table: "Security",
                columns: new[] { "Id", "CreatedTime", "Enabled", "IsDeleted", "Remark", "UniqueName", "UpdatedTime" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2020, 12, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "user.service.profile.self", "user.service.profile.self", null });

            migrationBuilder.InsertData(
                table: "SystemDataCategory",
                columns: new[] { "Id", "CreatedTime", "Enabled", "HigherId", "IsDeleted", "Name", "Remark", "Sequence", "UpdatedTime" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2020, 12, 22, 15, 30, 20, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, null, false, "性别", "性别", 0, null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Account", "CreatedTime", "Enabled", "Gender", "IsDeleted", "Nickname", "Password", "Photo", "SigninedTime", "Synopsis", "UpdatedTime" },
                values: new object[] { 1, "admin", new DateTimeOffset(new DateTime(2020, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, 0, false, null, "21232f297a57a5a743894a0e4a801fc3", null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 21 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 20 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 19 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 18 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 17 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 16 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 15 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 14 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 13 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 12 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 10 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 9 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 8 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 7 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 6 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "RoleSecurity",
                columns: new[] { "RoleId", "SecurityId" },
                values: new object[] { 1, 11 });

            migrationBuilder.InsertData(
                table: "SystemData",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "Enabled", "IsDeleted", "Name", "Remark", "Sequence", "UpdatedTime" },
                values: new object[] { 2, 1, new DateTimeOffset(new DateTime(2020, 12, 22, 15, 30, 20, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "女", "女", 1, null });

            migrationBuilder.InsertData(
                table: "SystemData",
                columns: new[] { "Id", "CategoryId", "CreatedTime", "Enabled", "IsDeleted", "Name", "Remark", "Sequence", "UpdatedTime" },
                values: new object[] { 1, 1, new DateTimeOffset(new DateTime(2020, 12, 22, 15, 30, 20, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0)), true, false, "男", "男", 0, null });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_RoleSecurity_SecurityId",
                table: "RoleSecurity",
                column: "SecurityId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemData_CategoryId",
                table: "SystemData",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemDataCategory_HigherId",
                table: "SystemDataCategory",
                column: "HigherId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleSecurity");

            migrationBuilder.DropTable(
                name: "SystemData");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Security");

            migrationBuilder.DropTable(
                name: "SystemDataCategory");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
