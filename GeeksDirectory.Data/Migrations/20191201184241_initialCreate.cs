using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeeksDirectory.Data.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_UserName",
                        column: x => x.UserName,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AverageScore = table.Column<int>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    SkillId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.AssessmentId);
                    table.ForeignKey(
                        name: "FK_Assessments_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assessments_AspNetUsers_UserName",
                        column: x => x.UserName,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b8eb90fa-e25a-43e1-a5b6-dadfc2bcf2a1", 0, "53ae42e2-4ad3-4446-836a-8625977950f2", "sergey.zykov@mail.some", false, false, null, "SERGEY.ZYKOV@MAIL.SOME", "SERGEY.ZYKOV@MAIL.SOME", "AQAAAAEAACcQAAAAEFJOcWIDBxwPz1kXKAaNOiupRSh1U74gbDPn0v48bCGiqfHSZ0deHt6GGnGfyfVdvg==", null, false, "50fab312-0dcb-41b5-8a22-7bbaecb48998", false, "sergey.zykov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e30e2446-ad11-46d6-bc13-68097fae0440", 0, "fd282b38-1adf-4d55-9b0e-53dc48a33275", "nikolay.borisov@mail.some", false, false, null, "NIKOLAY.BORISOV@MAIL.SOME", "NIKOLAY.BORISOV@MAIL.SOME", "AQAAAAEAACcQAAAAEE13sdahytRk4hZftmrzacGnpJI1MJx/7B2Ri4u76LzPJAqyvNWNCPj7pONiw3KKSw==", null, false, "13ceead8-f1c9-4890-afc7-835666ffe382", false, "nikolay.borisov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "511a47e8-9c86-4ce7-996f-9e1a72b53e69", 0, "aa5aa64e-cdf4-4d54-8e53-adc0e27e7116", "oskar.davtyan@mail.some", false, false, null, "OSKAR.DAVTYAN@MAIL.SOME", "OSKAR.DAVTYAN@MAIL.SOME", "AQAAAAEAACcQAAAAEEmrCGAcLZXmYsegNexg+goKO7rlkZYlnvovZwsxvy/31dQR4Nn8Fy3jWuOC9W838A==", null, false, "b86f9444-539f-4f96-88f4-a8adde2d5068", false, "oskar.davtyan@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "98d7661f-19ac-4909-bf20-e700dd07c19a", 0, "d282a08d-933e-4b1d-9bdf-8225e43c8e30", "anjela.trofimova@mail.some", false, false, null, "ANJELA.TROFIMOVA@MAIL.SOME", "ANJELA.TROFIMOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEA+A49xZ3DB0Mo0ZBPbAcEQMM+IQUtqgTLCmKJZjz0eDjkMqYdI1z8e/Hg2minqE4A==", null, false, "c210d836-9c4b-468a-a35b-44a1a329a0bb", false, "anjela.trofimova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d5a53242-1c53-42dd-8833-a5072b367d80", 0, "b2dc676c-6e9a-4ebf-be19-fd3fd258577e", "vanera.ryabova@mail.some", false, false, null, "VANERA.RYABOVA@MAIL.SOME", "VANERA.RYABOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEJq2M15jxvpkj2oPUrOq+cpr2EzE3XtCTGskOuxai/c76MGk4qR5izw1AzJt+ZGafA==", null, false, "cc16e08b-9815-4b9e-ac2f-e84acebff20b", false, "vanera.ryabova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f61dd9a6-49ee-4c40-ae5a-9b6b9122a38e", 0, "ba9c034f-8187-4d19-8b8f-fd2641212ecb", "polina.davydova@mail.some", false, false, null, "POLINA.DAVYDOVA@MAIL.SOME", "POLINA.DAVYDOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEIW90HbeQJi0WNTsrA4pTApfG/+XdEbEq00Renk56Cqm4P8+osBIk6YQEq1FDENtDg==", null, false, "4e09d16d-4a81-481f-b0e8-e4db9519b5f6", false, "polina.davydova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ae8f195d-426c-45b3-8f56-17ef57fd3148", 0, "cbb6c9d3-4a10-4588-b0ed-ff6c89ae33ad", "vlada.lipnitskaya@mail.some", false, false, null, "VLADA.LIPNITSKAYA@MAIL.SOME", "VLADA.LIPNITSKAYA@MAIL.SOME", "AQAAAAEAACcQAAAAED4i9f3wspejcsiZ28ror9uaM6tbzaB0msSzrvF/WP2gZVA8y+XO7sYE+xYfB+OEhQ==", null, false, "7d3cd5ae-83e2-4701-90c0-fbbd2ea9c4c4", false, "vlada.lipnitskaya@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "73ad683c-7127-4b43-bc6c-c9e2a086d4c1", 0, "9739baff-7f92-41da-bdfb-b01a980fce4e", "lubov.orehova@mail.some", false, false, null, "LUBOV.OREHOVA@MAIL.SOME", "LUBOV.OREHOVA@MAIL.SOME", "AQAAAAEAACcQAAAAENQrnI46H9uG/PumI5qooDbmDdoUizdOvr6Il2blfW70BXRBo41iJMfzXT3PWSbcxw==", null, false, "320d15f5-b0f6-4ff7-a850-3164a537688e", false, "lubov.orehova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4da310b4-87bb-4690-90c8-bf437114ae8e", 0, "994dc8ee-f0e4-4168-b05b-5cfbb84a0ab6", "vladimir.udin@mail.some", false, false, null, "VLADIMIR.UDIN@MAIL.SOME", "VLADIMIR.UDIN@MAIL.SOME", "AQAAAAEAACcQAAAAEDynd3qOyGfPCJ9yYY/JsQNohlVaXgwMXghlgndQxaoAq+EHjCoV8ap24Hd3Be8weQ==", null, false, "664e7b1a-3247-40ac-86a3-311400ba62a3", false, "vladimir.udin@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dabe2f8b-5545-4572-8468-5febf3a15a09", 0, "e4bb63da-bfa9-4e49-8515-e9a8fb327db7", "oskar.kapustin@mail.some", false, false, null, "OSKAR.KAPUSTIN@MAIL.SOME", "OSKAR.KAPUSTIN@MAIL.SOME", "AQAAAAEAACcQAAAAEEZRa6luSB5CfsyeOjXOS9FVxOUUH8uzdORS0EmOHu8+9SSehH7ng96tv1CbzCqeyQ==", null, false, "f956aebe-0a4f-4304-b152-e9c2807146a4", false, "oskar.kapustin@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "83d419be-12fb-4c32-9079-44a6bf1f0086", 0, "854de076-873f-4414-a41a-e64fea5ea808", "vsevolod.lenin@mail.some", false, false, null, "VSEVOLOD.LENIN@MAIL.SOME", "VSEVOLOD.LENIN@MAIL.SOME", "AQAAAAEAACcQAAAAEHocgtCyNtWOVAevgko9mixi/7kIX3TxIqhGHhipc6KC62tQRSszD/zP6mQzQdYuQQ==", null, false, "94f8b08d-43fc-4e7d-9fa6-aa935abdcbed", false, "vsevolod.lenin@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a020921d-a94e-4606-b090-dc96d12ffd95", 0, "386fb618-09cd-4aa3-94a9-182de6cb4399", "galena.volkova@mail.some", false, false, null, "GALENA.VOLKOVA@MAIL.SOME", "GALENA.VOLKOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEBuzmCspwz8ReFc+EbWvJl7ctlDjUwwlfWUZi5lfXo8mhd9IZILpVJNBRcAXK4KMGw==", null, false, "f51e5d3d-2ff1-41dc-8ca3-96fb55f5d0f5", false, "galena.volkova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a728faec-b5c7-41f4-bd56-162a897ff46f", 0, "6cc40430-ad76-4a26-b2a9-e0a701864709", "donat.latykin@mail.some", false, false, null, "DONAT.LATYKIN@MAIL.SOME", "DONAT.LATYKIN@MAIL.SOME", "AQAAAAEAACcQAAAAEGbzbu+JJsimUIaXIBR4CR0Q5yiAPzVu2yjhMLstxNY0weZUANXxe/aiVGW1Rctq0g==", null, false, "3de53798-7436-4ecd-8974-f6116a8e2e52", false, "donat.latykin@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8bd9b467-e47b-4720-ad89-6eda8d254f86", 0, "c9af3c6c-094c-453c-8348-3e0a0b10116a", "alina.lazareva@mail.some", false, false, null, "ALINA.LAZAREVA@MAIL.SOME", "ALINA.LAZAREVA@MAIL.SOME", "AQAAAAEAACcQAAAAEJX07poA2KPDV2ecJWo8WuviIZNgBTEq7Fn9j7WK+EKkw4ruxQtHoMM0nDqClByvwQ==", null, false, "97cf7fe8-28f1-472f-88f2-30e87a2ec31d", false, "alina.lazareva@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bb88c60a-257e-4b84-9a07-45206ccb3aad", 0, "4620a969-fa0c-40ad-9099-e5eda6d9543d", "zarina.uvarova@mail.some", false, false, null, "ZARINA.UVAROVA@MAIL.SOME", "ZARINA.UVAROVA@MAIL.SOME", "AQAAAAEAACcQAAAAEIA6PUyFUh+KkPUjGNn1qhLI/p4iz2w7aprNzKn/rIRXpO4FFjbY9YMzrA+q/F0qmQ==", null, false, "509897ac-54f8-4ac1-84f2-0b0602c385a1", false, "zarina.uvarova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "64642283-ef5f-4d48-9ef6-9a4e30b8332e", 0, "21ef97f1-6ee3-48e4-a2c8-abed7b2c5646", "albert.archipov@mail.some", false, false, null, "ALBERT.ARCHIPOV@MAIL.SOME", "ALBERT.ARCHIPOV@MAIL.SOME", "AQAAAAEAACcQAAAAEBvcbPzs+INVpoISXetfA9yeAqmkx30TN94v9lhzPHVYWo8/vfysr6mpIi5gMvMLxw==", null, false, "1ad798e8-6e8d-4eb0-b6d1-28334b4c626c", false, "albert.archipov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a206a7d-646f-4c48-8578-1d2e6a76df05", 0, "4c635cac-9ce7-42c8-8425-dad3a461901a", "zlata.tretyakova@mail.some", false, false, null, "ZLATA.TRETYAKOVA@MAIL.SOME", "ZLATA.TRETYAKOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEDrTJxRcpaob0Vqwyy+qqwLF79ebFJabqtykgEb/Dagix+G+tvgC5NQMKbajJq40FA==", null, false, "c2bf281e-a8f0-4a78-ae74-6c8f2cca37e4", false, "zlata.tretyakova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46b27f3b-dca0-4b4a-8b2a-ab2b263c1171", 0, "18b017cd-55fd-4272-9107-868ba0528966", "vasya.alekseev@mail.some", false, false, null, "VASYA.ALEKSEEV@MAIL.SOME", "VASYA.ALEKSEEV@MAIL.SOME", "AQAAAAEAACcQAAAAENn4XhcFf4Z82uw7x7WfHmL11xjAN2R7qZ/07qCaeTFdeJPJufRCLTJ7jGRlAHRTqw==", null, false, "a1ad1f33-b72a-4d0c-9323-5877a759a510", false, "vasya.alekseev@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "964fb987-c3d0-4a17-a417-fb7edce1e3aa", 0, "fd3b8d27-fbca-41ed-abc6-a43e999c92a6", "radislav.barsov@mail.some", false, false, null, "RADISLAV.BARSOV@MAIL.SOME", "RADISLAV.BARSOV@MAIL.SOME", "AQAAAAEAACcQAAAAEIauw5UUtEvgmMwdwTscKypBMel3BkGVsd2uWZ4xa4WNDShHqoadEYY0yRj/WFiyUQ==", null, false, "06305173-3eb3-4810-8d81-951374d74ee6", false, "radislav.barsov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dc440a63-da95-43b0-98aa-3f4c4ff2a053", 0, "3813048d-46fc-41a3-a825-fe388b86784a", "arsenia.panova@mail.some", false, false, null, "ARSENIA.PANOVA@MAIL.SOME", "ARSENIA.PANOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEN3ivguiloLgGYCa4cjblDpcCCjXrtYsegY8YIb1gjzEgG4cMDqDIo6u4TjpbTVMBg==", null, false, "189e7a34-548d-4695-a4d5-bcdbc27267a2", false, "arsenia.panova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b270427f-fc46-4fdc-b3d9-3bdc64364d0e", 0, "893e49ac-efba-4edf-9fa1-b1e0640e6778", "violeta.kanygina@mail.some", false, false, null, "VIOLETA.KANYGINA@MAIL.SOME", "VIOLETA.KANYGINA@MAIL.SOME", "AQAAAAEAACcQAAAAEMh/BfZW3JI4UGOqIb/vrIjsXySZ88lh8+tHUzolnigXJUn/jfmbRwozs5Qn1F4y2w==", null, false, "2c061130-4afb-45ff-a086-b92e09d6fdc7", false, "violeta.kanygina@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4f99f9b1-b054-455e-9daa-8f0592823568", 0, "c73e15c6-8f59-4c3a-9bad-094bfd5a88e2", "andrey.vladimirov@mail.some", false, false, null, "ANDREY.VLADIMIROV@MAIL.SOME", "ANDREY.VLADIMIROV@MAIL.SOME", "AQAAAAEAACcQAAAAEJd78oTPbYDH/Noy/RAzudSzowsxh2E/fz6VQUcm/VCAZS2+C9n/0cbc4YD1sPcEyg==", null, false, "3cd82a34-5c54-42ff-bf86-212289cdd9a6", false, "andrey.vladimirov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8636b3d5-af78-4a6f-a773-c96404516ba5", 0, "6b3253bf-f1a2-4872-8a0b-4c890b076040", "dasha.egorova@mail.some", false, false, null, "DASHA.EGOROVA@MAIL.SOME", "DASHA.EGOROVA@MAIL.SOME", "AQAAAAEAACcQAAAAEBkiyHtHi25SXy0mHidkWY3niPJUiGvWUvBb5mmnrOo/M72OB+/oT4EMGUVoxU0I6g==", null, false, "2c63d790-6f82-47e8-b59d-cf3527220304", false, "dasha.egorova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3fa5371e-5d44-42c6-b71f-daf3d38b2c5b", 0, "025fd647-48aa-40df-959f-dd2206ca403b", "ivan.ivanov@mail.some", false, false, null, "IVAN.IVANOV@MAIL.SOME", "IVAN.IVANOV@MAIL.SOME", "AQAAAAEAACcQAAAAEPM4LfL5RjrwWYRN4zdorkZRe/NUQdq9qcT8r3mGfS4vhER82J5V5bRaBQaBpZK4LA==", null, false, "f489f8d2-a595-4d16-a003-e5e9468db4b2", false, "ivan.ivanov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0a50dbc4-23b5-4e0d-b588-0a7a72df0ed1", 0, "445c9227-f1ee-4afc-a7ca-8825998d9f19", "john.smith@mail.some", false, false, null, "JOHN.SMITH@MAIL.SOME", "JOHN.SMITH@MAIL.SOME", "AQAAAAEAACcQAAAAEP5T74YWhlFsYe82zDCz+PgSqy1zCUTaspZraeR7k6TADadEd7VzhT+AnbaxMviaoQ==", null, false, "11958558-5dcc-4f4f-a902-beff0a197a91", false, "john.smith@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ab9f49d7-f20a-4951-88db-f75fcded0fe9", 0, "da569bb0-6588-449f-b48a-4aeccb4163d4", "nadezda.kolesnikova@mail.some", false, false, null, "NADEZDA.KOLESNIKOVA@MAIL.SOME", "NADEZDA.KOLESNIKOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEHtP0SqXpMji7uj/y0+3/ixXqiC5UX1ESxENfPlY42f/FF5z+MSJgjB+QO0QWDEvRw==", null, false, "0e316fca-ccc0-4251-b788-f00061c39d82", false, "nadezda.kolesnikova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b1091cd4-d605-480b-aa23-6f49df0e53ad", 0, "fadbbdb4-a7fa-4bde-90c2-d42e5539e008", "maksim.kuzmin@mail.some", false, false, null, "MAKSIM.KUZMIN@MAIL.SOME", "MAKSIM.KUZMIN@MAIL.SOME", "AQAAAAEAACcQAAAAEHSecoCwkNcK80gtW+pTJU4K0wvQEdLGn7HZhLe89mMr2Z8R0rE7w0S6XW17o5iW8w==", null, false, "7ae2ec8a-9867-48ce-bde4-a85ac02b495f", false, "maksim.kuzmin@mail.some" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 1, "Moscow", "sergey.zykov@mail.some", null, "Sergey", "Zykov", "b8eb90fa-e25a-43e1-a5b6-dadfc2bcf2a1" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 25, "Mikhaylovka", "nikolay.borisov@mail.some", null, "Nikolay", "Borisov", "e30e2446-ad11-46d6-bc13-68097fae0440" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 24, "Latoshinka", "oskar.davtyan@mail.some", null, "Oskar", "Davtyan", "511a47e8-9c86-4ce7-996f-9e1a72b53e69" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 23, "Khvatkovo", "anjela.trofimova@mail.some", null, "Anjela", "Trofimova", "98d7661f-19ac-4909-bf20-e700dd07c19a" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 22, "Krutilovka", "vanera.ryabova@mail.some", null, "Vanera", "Ryabova", "d5a53242-1c53-42dd-8833-a5072b367d80" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 21, "Aryntsas", "polina.davydova@mail.some", null, "Polina", "Davydova", "f61dd9a6-49ee-4c40-ae5a-9b6b9122a38e" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 20, "Nikitino", "vlada.lipnitskaya@mail.some", null, "Vlada", "Lipnitskaya", "ae8f195d-426c-45b3-8f56-17ef57fd3148" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 19, "Ragozina", "lubov.orehova@mail.some", null, "Lubov", "Orehova", "73ad683c-7127-4b43-bc6c-c9e2a086d4c1" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 18, "Skolkovo", "vladimir.udin@mail.some", null, "Vladimir", "Udin", "4da310b4-87bb-4690-90c8-bf437114ae8e" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 17, "Shvedovo", "oskar.kapustin@mail.some", null, "Oskar", "Kapustin", "dabe2f8b-5545-4572-8468-5febf3a15a09" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 16, "Ungavitsa", "vsevolod.lenin@mail.some", null, "Vsevolod", "Lenin", "83d419be-12fb-4c32-9079-44a6bf1f0086" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 15, "Agutino", "galena.volkova@mail.some", null, "Galena", "Volkova", "a020921d-a94e-4606-b090-dc96d12ffd95" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 26, "Nygda", "donat.latykin@mail.some", null, "Donat", "Latykin", "a728faec-b5c7-41f4-bd56-162a897ff46f" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 14, "Lykoshina", "alina.lazareva@mail.some", null, "Alina", "Lazareva", "8bd9b467-e47b-4720-ad89-6eda8d254f86" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 12, "Trostyanka", "zarina.uvarova@mail.some", null, "Zarina", "Uvarova", "bb88c60a-257e-4b84-9a07-45206ccb3aad" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 11, "Golitsyno", "albert.archipov@mail.some", null, "Albert", "Archipov", "64642283-ef5f-4d48-9ef6-9a4e30b8332e" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 10, "Karaichev", "zlata.tretyakova@mail.some", null, "Zlata", "Tretyakova", "1a206a7d-646f-4c48-8578-1d2e6a76df05" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 9, "Walnut Park", "vasya.alekseev@mail.some", null, "Vasya", "Alekseev", "46b27f3b-dca0-4b4a-8b2a-ab2b263c1171" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 8, "Kenton Vale", "radislav.barsov@mail.some", null, "Radislav", "Barsov", "964fb987-c3d0-4a17-a417-fb7edce1e3aa" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 7, "Dupree", "arsenia.panova@mail.some", null, "Arsenia", "Panova", "dc440a63-da95-43b0-98aa-3f4c4ff2a053" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 6, "New Preston", "violeta.kanygina@mail.some", null, "Violeta", "Kanygina", "b270427f-fc46-4fdc-b3d9-3bdc64364d0e" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 5, "Landmark", "andrey.vladimirov@mail.some", null, "Andrey", "Vladimirov", "4f99f9b1-b054-455e-9daa-8f0592823568" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 4, "Deport", "dasha.egorova@mail.some", null, "Dasha", "Egorova", "8636b3d5-af78-4a6f-a773-c96404516ba5" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 3, "St. Petersburg", "ivan.ivanov@mail.some", null, "Ivan", "Ivanov", "3fa5371e-5d44-42c6-b71f-daf3d38b2c5b" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 2, "Ekaterinburg", "john.smith@mail.some", null, "John", "Smith", "0a50dbc4-23b5-4e0d-b588-0a7a72df0ed1" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 13, "Stawropol", "nadezda.kolesnikova@mail.some", null, "Nadezda", "Kolesnikova", "ab9f49d7-f20a-4951-88db-f75fcded0fe9" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "Email", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 27, "Taygach", "maksim.kuzmin@mail.some", null, "Maksim", "Kuzmin", "b1091cd4-d605-480b-aa23-6f49df0e53ad" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 1, 4, "Excepteur sint in culpa id est laborum.", "python", 1 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 35, 2, "Quis autem vel eum iure repreherit in ea quam.", "php", 14 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 36, 0, "Excepteur sint cupitat, anim id est laborum.", "ruby", 15 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 37, 0, "Quis autem vel eum iure repreherit in ea quam.", "php", 16 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 38, 4, "Nemo enim ipsam voptatem aut odit.", "swift", 16 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 39, 2, "Nemo enim sit aspernatur aut odit.", "angular", 17 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 40, 4, "Excepteur occaecat cupida proident, suntid est.", "cpp", 18 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 41, 4, "Quis autem vel eum iure repreherit in ea quam.", "php", 18 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 42, 2, "Nemo enim ipsam voptatem aut odit.", "swift", 18 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 43, 4, "Excepteur sint cupitat, anim id est laborum.", "ruby", 18 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 44, 1, "Quis autem vel eum iure repreherit in ea quam.", "php", 19 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 45, 1, "Nemo enim ipsam voptatem aut odit.", "swift", 19 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 46, 4, "Ut enim ad minima, exercitationem ullam.", "java", 20 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 47, 3, "Excepteur sint in culpa id est laborum.", "python", 20 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 48, 4, "Excepteur occaecat cupida proident, suntid est.", "cpp", 20 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 49, 4, "Nemo enim ipsam voptatem aut odit.", "swift", 21 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 50, 4, "Quis autem eum iur velit esse quam.", "javascript", 22 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 51, 1, "Nemo enim sit aspernatur aut odit.", "angular", 22 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 52, 3, "Ut enim ad minima, exercitationem ullam.", "java", 22 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 53, 4, "Excepteur sint cupitat, anim id est laborum.", "ruby", 23 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 54, 4, "Nemo enim sit aspernatur aut odit.", "angular", 24 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 55, 1, "Ut enim ad minima, exercitationem ullam.", "java", 24 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 56, 4, "Excepteur sint in culpa id est laborum.", "python", 24 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 57, 1, "Excepteur occaecat cupida proident, suntid est.", "cpp", 24 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 58, 2, "Quis autem vel eum iure repreherit in ea quam.", "php", 24 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 59, 0, "Excepteur occaecat cupida proident, suntid est.", "cpp", 25 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 60, 0, "Quis autem vel eum iure repreherit in ea quam.", "php", 25 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 61, 4, "Nemo enim ipsam voptatem aut odit.", "swift", 25 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 62, 4, "Excepteur sint cupitat, anim id est laborum.", "ruby", 25 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 63, 2, "Nemo enim ipsam voptatem aut odit.", "swift", 26 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 34, 0, "Excepteur occaecat cupida proident, suntid est.", "cpp", 14 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 64, 0, "Excepteur sint cupitat, anim id est laborum.", "ruby", 26 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 33, 3, "Excepteur sint cupitat, anim id est laborum.", "ruby", 13 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 31, 3, "Excepteur sint in culpa id est laborum.", "python", 12 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 2, 3, "Excepteur occaecat cupida proident, suntid est.", "cpp", 1 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 3, 3, "Quis autem vel eum iure repreherit in ea quam.", "php", 1 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 4, 4, "Nemo enim ipsam voptatem aut odit.", "swift", 1 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 5, 3, "Nemo enim ipsam voptatem aut odit.", "swift", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 6, 4, "Excepteur sint cupitat, anim id est laborum.", "ruby", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 7, 2, "Excepteur occaecat cupida proident, suntid est.", "cpp", 3 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 8, 3, "Quis autem vel eum iure repreherit in ea quam.", "php", 3 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 9, 4, "Nemo enim ipsam voptatem aut odit.", "swift", 3 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 10, 3, "Excepteur sint cupitat, anim id est laborum.", "ruby", 3 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 11, 0, "Excepteur sint in culpa id est laborum.", "python", 4 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 12, 1, "Excepteur occaecat cupida proident, suntid est.", "cpp", 4 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 13, 3, "Quis autem vel eum iure repreherit in ea quam.", "php", 4 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 14, 0, "Nemo enim ipsam voptatem aut odit.", "swift", 4 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 15, 1, "Quis autem eum iur velit esse quam.", "javascript", 5 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 16, 0, "Nemo enim sit aspernatur aut odit.", "angular", 5 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 17, 1, "Ut enim ad minima, exercitationem ullam.", "java", 5 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 18, 0, "Excepteur sint in culpa id est laborum.", "python", 5 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 19, 2, "Quis autem vel eum iure repreherit in ea quam.", "php", 6 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 20, 0, "Nemo enim ipsam voptatem aut odit.", "swift", 6 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 21, 0, "Excepteur sint cupitat, anim id est laborum.", "ruby", 6 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 22, 0, "Excepteur sint cupitat, anim id est laborum.", "ruby", 7 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 23, 2, "Quis autem eum iur velit esse quam.", "javascript", 8 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 24, 1, "Nemo enim ipsam voptatem aut odit.", "swift", 9 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 25, 3, "Excepteur sint cupitat, anim id est laborum.", "ruby", 9 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 26, 2, "Excepteur occaecat cupida proident, suntid est.", "cpp", 10 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 27, 4, "Quis autem vel eum iure repreherit in ea quam.", "php", 10 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 28, 3, "Excepteur occaecat cupida proident, suntid est.", "cpp", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 29, 0, "Quis autem vel eum iure repreherit in ea quam.", "php", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 30, 4, "Nemo enim ipsam voptatem aut odit.", "swift", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 32, 2, "Excepteur occaecat cupida proident, suntid est.", "cpp", 12 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 65, 4, "Nemo enim sit aspernatur aut odit.", "angular", 27 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_SkillId",
                table: "Assessments",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_UserName",
                table: "Assessments",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserName",
                table: "Profiles",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ProfileId",
                table: "Skills",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
