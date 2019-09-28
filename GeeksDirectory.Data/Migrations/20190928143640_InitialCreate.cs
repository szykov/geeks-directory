using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeeksDirectory.Data.Migrations
{
    public partial class InitialCreate : Migration
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
                values: new object[] { "b8eb90fa-e25a-43e1-a5b6-dadfc2bcf2a1", 0, "5df37ac7-4b40-4967-a2cb-27c869ba22d6", "sergey.zykov@mail.some", false, false, null, "SERGEY.ZYKOV@MAIL.SOME", "SERGEY.ZYKOV@MAIL.SOME", "AQAAAAEAACcQAAAAEMSsZ2C2hYBOP5isrytuaPTeqnFj7fLLjk92IFnDAvJgXuKEGKdtBmwNLayRz0lFlg==", null, false, "18cfc0df-7747-44be-b5e2-713bfdd38099", false, "sergey.zykov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e30e2446-ad11-46d6-bc13-68097fae0440", 0, "ce392859-b7ae-4405-8815-064549924cec", "nikolay.borisov@mail.some", false, false, null, "NIKOLAY.BORISOV@MAIL.SOME", "NIKOLAY.BORISOV@MAIL.SOME", "AQAAAAEAACcQAAAAEH03GOydHwouiqsHTowPvoXCyBHdoIRnuxb5iRFjYakk8gYw9UHMgU+BomNnHrh9HQ==", null, false, "77456845-64eb-4d17-b212-b01bb778aa16", false, "nikolay.borisov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "511a47e8-9c86-4ce7-996f-9e1a72b53e69", 0, "d175b7e1-a206-42de-a361-57350ff748ee", "oskar.davtyan@mail.some", false, false, null, "OSKAR.DAVTYAN@MAIL.SOME", "OSKAR.DAVTYAN@MAIL.SOME", "AQAAAAEAACcQAAAAEPYW+iAHjP/4SSJBKAnShcBNwji+drpGv23EzChV7Py5kiMBMs7s0ALaYbOKqh7o5Q==", null, false, "5dc366c7-859b-45f9-a6d6-7c2144c5fb7f", false, "oskar.davtyan@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "98d7661f-19ac-4909-bf20-e700dd07c19a", 0, "edc63674-6c41-4d0e-a526-1a525efd99d2", "anjela.trofimova@mail.some", false, false, null, "ANJELA.TROFIMOVA@MAIL.SOME", "ANJELA.TROFIMOVA@MAIL.SOME", "AQAAAAEAACcQAAAAECJAVQ0VBngMGUcq9XA96m4OrIp3zhmO73k4yYkkjSdTGkdfRsu5KiNBLTaAF88YXg==", null, false, "3a5a69c9-6f81-4408-ac46-2b99ab1f500f", false, "anjela.trofimova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d5a53242-1c53-42dd-8833-a5072b367d80", 0, "3570372b-86f4-4073-9883-a5c59a6d01bb", "vanera.ryabova@mail.some", false, false, null, "VANERA.RYABOVA@MAIL.SOME", "VANERA.RYABOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEKv1GBUnUFw/6tFjUDnLQUmwXATSJa+J/NQY5S74QhIZx1Vx940dcUAdyuYrHgL5+A==", null, false, "5b544274-daef-477f-a15e-eb52b1a524e1", false, "vanera.ryabova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f61dd9a6-49ee-4c40-ae5a-9b6b9122a38e", 0, "6f5c2856-cf44-44a1-9aa1-c8598bcbab91", "polina.davydova@mail.some", false, false, null, "POLINA.DAVYDOVA@MAIL.SOME", "POLINA.DAVYDOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEB8dZIglVQ/r7nKycoVlvItqtWnXp5VP2Yrk3cwZepU4vmFbT+/WnuTjUJAvWuKbig==", null, false, "65a084a6-8e5f-4562-9591-685a052812d0", false, "polina.davydova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ae8f195d-426c-45b3-8f56-17ef57fd3148", 0, "e6b97dbf-fce1-48eb-a3ff-ab8a43ff93f4", "vlada.lipnitskaya@mail.some", false, false, null, "VLADA.LIPNITSKAYA@MAIL.SOME", "VLADA.LIPNITSKAYA@MAIL.SOME", "AQAAAAEAACcQAAAAEJ8OqqgJPrKHVNh3e+Onyl2wmuBuUwhjo/bPZQRkBtUiAUajBGogCoCHtsGq8xKnKg==", null, false, "1ba207c8-9bdd-4d86-b61c-0a1903c25712", false, "vlada.lipnitskaya@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "73ad683c-7127-4b43-bc6c-c9e2a086d4c1", 0, "59409089-39a1-4321-8b9d-c54563f5a40e", "lubov.orehova@mail.some", false, false, null, "LUBOV.OREHOVA@MAIL.SOME", "LUBOV.OREHOVA@MAIL.SOME", "AQAAAAEAACcQAAAAECsJF1YQiwzBffaBqOls0Pf0mH/eaz2OtgGp0H+geC+Cvw+tYyl4artgQNIXcjYBzQ==", null, false, "9ad1e001-2c25-46fa-b784-df9aa97844d4", false, "lubov.orehova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4da310b4-87bb-4690-90c8-bf437114ae8e", 0, "e898006f-10ac-422b-b702-67d4d741a550", "vladimir.udin@mail.some", false, false, null, "VLADIMIR.UDIN@MAIL.SOME", "VLADIMIR.UDIN@MAIL.SOME", "AQAAAAEAACcQAAAAEMlF07EFJ0iIRcg+wD7cKvyyHFqnpZoGBntuzTgIIpCTFSOoMsheq/yg8emrU1KCNw==", null, false, "933153df-7fc9-4a34-b985-395b23b0318e", false, "vladimir.udin@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dabe2f8b-5545-4572-8468-5febf3a15a09", 0, "d26f014d-0720-4032-9e2b-71df0273b530", "oskar.kapustin@mail.some", false, false, null, "OSKAR.KAPUSTIN@MAIL.SOME", "OSKAR.KAPUSTIN@MAIL.SOME", "AQAAAAEAACcQAAAAEFHnik+8fIgUDCG7rSVNKfxYxqu+KfifbP9h2TrHE0bC/qDH+S8Y3oGAGQNVCNrtdQ==", null, false, "9fee0f22-7888-41e1-b597-c80af67a821a", false, "oskar.kapustin@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "83d419be-12fb-4c32-9079-44a6bf1f0086", 0, "f0457752-e93b-4983-a3c4-21d2dd2bb94c", "vsevolod.lenin@mail.some", false, false, null, "VSEVOLOD.LENIN@MAIL.SOME", "VSEVOLOD.LENIN@MAIL.SOME", "AQAAAAEAACcQAAAAEKt3HAZvdb7eX1zPX2T2iAoN653xpKz2ovCqwgSnBSUirOMpd4dxSnbkeoSfW2hbeA==", null, false, "f0d69115-570f-4b9a-85fd-f25fe33561c3", false, "vsevolod.lenin@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a020921d-a94e-4606-b090-dc96d12ffd95", 0, "aa048c49-de33-467f-ba1e-c2c40302c09d", "galena.volkova@mail.some", false, false, null, "GALENA.VOLKOVA@MAIL.SOME", "GALENA.VOLKOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEKfKt3dk1Xb0iUj2PGX1KNWZHHhIou0wezUNDMupkH6XQhAi5Ns+DHTqHQw++AFgPg==", null, false, "729771ec-987c-486e-b927-8c45fe2831e1", false, "galena.volkova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a728faec-b5c7-41f4-bd56-162a897ff46f", 0, "ded61cf9-6f60-47fc-ba20-4e28248cd095", "donat.latykin@mail.some", false, false, null, "DONAT.LATYKIN@MAIL.SOME", "DONAT.LATYKIN@MAIL.SOME", "AQAAAAEAACcQAAAAEHSwdpF7LMOSB74dXbY/+x48tjjip5NHmI1q01LaDVZHW5ZWrjUCSJylwhq9m3crfg==", null, false, "a3f6ad75-0522-4e53-8acf-2c007dff3789", false, "donat.latykin@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8bd9b467-e47b-4720-ad89-6eda8d254f86", 0, "963a6ab1-a8ef-4ea1-8215-cc270943f43e", "alina.lazareva@mail.some", false, false, null, "ALINA.LAZAREVA@MAIL.SOME", "ALINA.LAZAREVA@MAIL.SOME", "AQAAAAEAACcQAAAAECBkQMMqOR0wPN+6Ev1Z1/eQSUafRso7Orfr4bcRScurxKn3NsM+xmmP5M42EAUR6g==", null, false, "dbfb6f2a-98d2-4f66-a94f-c10bac1c1eb2", false, "alina.lazareva@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bb88c60a-257e-4b84-9a07-45206ccb3aad", 0, "8db6cf46-3d6e-4136-94c1-061c1c58e7b7", "zarina.uvarova@mail.some", false, false, null, "ZARINA.UVAROVA@MAIL.SOME", "ZARINA.UVAROVA@MAIL.SOME", "AQAAAAEAACcQAAAAENxJ4s6cNNtxtbn8vuv2K1Y9HC1gfUWZue/WU3yNU8pb4gp/vdPl3a1PS7IpJQcF7w==", null, false, "667d0c87-aad5-4fae-85a3-e6fca48841d4", false, "zarina.uvarova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "64642283-ef5f-4d48-9ef6-9a4e30b8332e", 0, "c517a0de-f239-4c5c-84a2-a0c563a6175a", "albert.archipov@mail.some", false, false, null, "ALBERT.ARCHIPOV@MAIL.SOME", "ALBERT.ARCHIPOV@MAIL.SOME", "AQAAAAEAACcQAAAAELd4x72kyniyzoIbWTgNN+tHvem3qXQNBmxRJJsAh7/zboQ+EV3e3XVXkNp2K6wZLA==", null, false, "b9d1aa6e-d7e6-46e3-85a4-17a625a5297f", false, "albert.archipov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a206a7d-646f-4c48-8578-1d2e6a76df05", 0, "ec81a69c-bc0c-472e-b2aa-93083c4d3715", "zlata.tretyakova@mail.some", false, false, null, "ZLATA.TRETYAKOVA@MAIL.SOME", "ZLATA.TRETYAKOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEKDrfg8+hT7bmTxqBGHGrtOJ+uH2vlkcAxjdo3oT/BLb76wSNJyzY0AXI1Od7Hzqhg==", null, false, "fbebfdfe-50e7-4e93-adfa-bb007b22321d", false, "zlata.tretyakova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46b27f3b-dca0-4b4a-8b2a-ab2b263c1171", 0, "570a1b8e-cb5b-4039-96e4-83f3eba3f28c", "vasya.alekseev@mail.some", false, false, null, "VASYA.ALEKSEEV@MAIL.SOME", "VASYA.ALEKSEEV@MAIL.SOME", "AQAAAAEAACcQAAAAEBn6RxtwEIf3+XlfN1Ud+/Im3vay4WAjiQckyheMxnSmo/hb1cB8bMPZj7RFRl65cQ==", null, false, "8ea7efdd-6220-44f6-8752-f468dc60a398", false, "vasya.alekseev@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "964fb987-c3d0-4a17-a417-fb7edce1e3aa", 0, "0d354a8e-41e3-4ad2-ba11-bb9062b05f7e", "radislav.barsov@mail.some", false, false, null, "RADISLAV.BARSOV@MAIL.SOME", "RADISLAV.BARSOV@MAIL.SOME", "AQAAAAEAACcQAAAAELzvMmPk7U55Tho4Xu0860HhNdQpEPXilyG7iGlW+dCZh9RA5DEr0XApd9bLi8M0Tg==", null, false, "3b10fcbb-3ec6-4a99-9ef7-da2725cee2ed", false, "radislav.barsov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dc440a63-da95-43b0-98aa-3f4c4ff2a053", 0, "84c43ae6-7c9b-49ad-9b3f-2126928a02fe", "arsenia.panova@mail.some", false, false, null, "ARSENIA.PANOVA@MAIL.SOME", "ARSENIA.PANOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEDLWgogfxA6i5xZuRxZOd1fH6bXf2ql5yQjSwmUR40QO4OcKzYH6/5bh26Wurfv4mA==", null, false, "2b907564-2e3a-4a4e-b4a9-f16a1c92fbf7", false, "arsenia.panova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b270427f-fc46-4fdc-b3d9-3bdc64364d0e", 0, "9d9cbc66-4597-4790-808b-dbc4cc9bd746", "violeta.kanygina@mail.some", false, false, null, "VIOLETA.KANYGINA@MAIL.SOME", "VIOLETA.KANYGINA@MAIL.SOME", "AQAAAAEAACcQAAAAEPn4AMLGNKcA3p1+4tuOTYbrlhVC46DnbwwUHQmXyJhHzjz5foyYlZhQwbuRbrKO0Q==", null, false, "d755a677-ae36-45ff-9792-324e6f5e68c4", false, "violeta.kanygina@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4f99f9b1-b054-455e-9daa-8f0592823568", 0, "f971ea07-bcf1-4a3f-bbbc-81aec5d4fa10", "andrey.vladimirov@mail.some", false, false, null, "ANDREY.VLADIMIROV@MAIL.SOME", "ANDREY.VLADIMIROV@MAIL.SOME", "AQAAAAEAACcQAAAAEG3QMVo0YMprdh7Rldva71rhn6axrhqnY9wKtOx4gyO4UIFs5vA2I1ZoI+GhEtxLNg==", null, false, "bb49e97e-ea36-4917-9b73-aefa978a81a1", false, "andrey.vladimirov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8636b3d5-af78-4a6f-a773-c96404516ba5", 0, "a79be290-3ddd-4540-a0ee-72477a4fdd3a", "dasha.egorova@mail.some", false, false, null, "DASHA.EGOROVA@MAIL.SOME", "DASHA.EGOROVA@MAIL.SOME", "AQAAAAEAACcQAAAAEBZKr6YBS7ApTKh2EoCH2DYRP5kdHFq57wvgjXx26AEE5F3A6CW0EAN9DmexS207vQ==", null, false, "8999ab89-9ee8-4e51-a860-96c8bea14ebc", false, "dasha.egorova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3fa5371e-5d44-42c6-b71f-daf3d38b2c5b", 0, "85f5e17e-940c-4f88-a0e8-e3895647fbf1", "ivan.ivanov@mail.some", false, false, null, "IVAN.IVANOV@MAIL.SOME", "IVAN.IVANOV@MAIL.SOME", "AQAAAAEAACcQAAAAEKLdbZVMJRUbhSXT1U//U/qo6NP280acR2WQSQHGvBB4rRgEQ+fg4eBhRCQ4Ma3ruA==", null, false, "f2374fbd-2bb1-4ab8-890d-1daf5b4ddcc3", false, "ivan.ivanov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0a50dbc4-23b5-4e0d-b588-0a7a72df0ed1", 0, "96fd0033-8708-4df0-b1d8-5ab89c3eaddd", "john.smith@mail.some", false, false, null, "JOHN.SMITH@MAIL.SOME", "JOHN.SMITH@MAIL.SOME", "AQAAAAEAACcQAAAAEDDvA64xMBs1Hw22egpzT57yLkfbzC6o6kajIQYN+jDBERcLlUojqCMrK7kM87JeCQ==", null, false, "55ca4ab1-0f12-4264-b7d7-b675d6dfc8e1", false, "john.smith@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ab9f49d7-f20a-4951-88db-f75fcded0fe9", 0, "b15ce872-57a0-4b98-8428-569fa6967130", "nadezda.kolesnikova@mail.some", false, false, null, "NADEZDA.KOLESNIKOVA@MAIL.SOME", "NADEZDA.KOLESNIKOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEIT4/Ov6Ahl7WRZ343XR0hHIlYAjF7msrEX+fnd72TZI+k5E9uBHZMnHBQKkOUwVDg==", null, false, "6aa05ce0-9f6a-4b74-b2d6-b98b4f8fc0f1", false, "nadezda.kolesnikova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b1091cd4-d605-480b-aa23-6f49df0e53ad", 0, "f9d7b5a2-9056-42e8-b96a-abec19b4b71a", "maksim.kuzmin@mail.some", false, false, null, "MAKSIM.KUZMIN@MAIL.SOME", "MAKSIM.KUZMIN@MAIL.SOME", "AQAAAAEAACcQAAAAEH4Ph2KZ4tMcx68wDLOlBRDlsXKMGDD06QK3Om4W/oZrDmcqXpQ1yfb/EisHv/DPRw==", null, false, "b4a9cf6b-47e4-48c3-bd73-dd4e50346bd6", false, "maksim.kuzmin@mail.some" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 1, "Moscow", null, "Sergey", "Zykov", "b8eb90fa-e25a-43e1-a5b6-dadfc2bcf2a1" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 25, "Mikhaylovka", null, "Nikolay", "Borisov", "e30e2446-ad11-46d6-bc13-68097fae0440" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 24, "Latoshinka", null, "Oskar", "Davtyan", "511a47e8-9c86-4ce7-996f-9e1a72b53e69" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 23, "Khvatkovo", null, "Anjela", "Trofimova", "98d7661f-19ac-4909-bf20-e700dd07c19a" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 22, "Krutilovka", null, "Vanera", "Ryabova", "d5a53242-1c53-42dd-8833-a5072b367d80" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 21, "Aryntsas", null, "Polina", "Davydova", "f61dd9a6-49ee-4c40-ae5a-9b6b9122a38e" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 20, "Nikitino", null, "Vlada", "Lipnitskaya", "ae8f195d-426c-45b3-8f56-17ef57fd3148" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 19, "Ragozina", null, "Lubov", "Orehova", "73ad683c-7127-4b43-bc6c-c9e2a086d4c1" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 18, "Skolkovo", null, "Vladimir", "Udin", "4da310b4-87bb-4690-90c8-bf437114ae8e" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 17, "Shvedovo", null, "Oskar", "Kapustin", "dabe2f8b-5545-4572-8468-5febf3a15a09" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 16, "Ungavitsa", null, "Vsevolod", "Lenin", "83d419be-12fb-4c32-9079-44a6bf1f0086" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 15, "Agutino", null, "Galena", "Volkova", "a020921d-a94e-4606-b090-dc96d12ffd95" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 26, "Nygda", null, "Donat", "Latykin", "a728faec-b5c7-41f4-bd56-162a897ff46f" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 14, "Lykoshina", null, "Alina", "Lazareva", "8bd9b467-e47b-4720-ad89-6eda8d254f86" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 12, "Trostyanka", null, "Zarina", "Uvarova", "bb88c60a-257e-4b84-9a07-45206ccb3aad" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 11, "Golitsyno", null, "Albert", "Archipov", "64642283-ef5f-4d48-9ef6-9a4e30b8332e" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 10, "Karaichev", null, "Zlata", "Tretyakova", "1a206a7d-646f-4c48-8578-1d2e6a76df05" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 9, "Walnut Park", null, "Vasya", "Alekseev", "46b27f3b-dca0-4b4a-8b2a-ab2b263c1171" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 8, "Kenton Vale", null, "Radislav", "Barsov", "964fb987-c3d0-4a17-a417-fb7edce1e3aa" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 7, "Dupree", null, "Arsenia", "Panova", "dc440a63-da95-43b0-98aa-3f4c4ff2a053" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 6, "New Preston", null, "Violeta", "Kanygina", "b270427f-fc46-4fdc-b3d9-3bdc64364d0e" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 5, "Landmark", null, "Andrey", "Vladimirov", "4f99f9b1-b054-455e-9daa-8f0592823568" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 4, "Deport", null, "Dasha", "Egorova", "8636b3d5-af78-4a6f-a773-c96404516ba5" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 3, "St. Petersburg", null, "Ivan", "Ivanov", "3fa5371e-5d44-42c6-b71f-daf3d38b2c5b" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 2, "Ekaterinburg", null, "John", "Smith", "0a50dbc4-23b5-4e0d-b588-0a7a72df0ed1" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 13, "Stawropol", null, "Nadezda", "Kolesnikova", "ab9f49d7-f20a-4951-88db-f75fcded0fe9" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[] { 27, "Taygach", null, "Maksim", "Kuzmin", "b1091cd4-d605-480b-aa23-6f49df0e53ad" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 1, 1, "Excepteur occaecat cupida proident, suntid est.", "cpp", 1 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 55, 0, "Excepteur sint in culpa id est laborum.", "python", 20 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 54, 4, "Ut enim ad minima, exercitationem ullam.", "java", 20 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 53, 1, "Nemo enim sit aspernatur aut odit.", "angular", 20 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 52, 1, "Ut enim ad minima, exercitationem ullam.", "java", 19 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 51, 2, "Excepteur sint cupitat, anim id est laborum.", "ruby", 18 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 50, 4, "Nemo enim ipsam voptatem aut odit.", "swift", 18 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 49, 0, "Quis autem vel eum iure repreherit in ea quam.", "php", 17 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 48, 4, "Excepteur occaecat cupida proident, suntid est.", "cpp", 17 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 47, 0, "Nemo enim sit aspernatur aut odit.", "angular", 16 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 46, 2, "Quis autem eum iur velit esse quam.", "javascript", 16 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 45, 2, "Lorem ipsum dolor sit amet.", "csharp", 16 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 44, 2, "Nemo enim ipsam voptatem aut odit.", "swift", 15 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 43, 1, "Quis autem vel eum iure repreherit in ea quam.", "php", 15 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 42, 4, "Excepteur occaecat cupida proident, suntid est.", "cpp", 15 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 41, 0, "Excepteur sint in culpa id est laborum.", "python", 15 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 56, 0, "Excepteur occaecat cupida proident, suntid est.", "cpp", 20 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 40, 2, "Excepteur sint cupitat, anim id est laborum.", "ruby", 14 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 57, 1, "Quis autem vel eum iure repreherit in ea quam.", "php", 20 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 59, 3, "Quis autem vel eum iure repreherit in ea quam.", "php", 21 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 74, 4, "Lorem ipsum dolor sit amet.", "csharp", 27 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 73, 3, "Quis autem vel eum iure repreherit in ea quam.", "php", 26 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 72, 3, "Excepteur occaecat cupida proident, suntid est.", "cpp", 26 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 71, 4, "Nemo enim sit aspernatur aut odit.", "angular", 25 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 70, 3, "Quis autem eum iur velit esse quam.", "javascript", 25 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 69, 2, "Nemo enim sit aspernatur aut odit.", "angular", 24 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 68, 2, "Quis autem vel eum iure repreherit in ea quam.", "php", 23 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 67, 1, "Excepteur occaecat cupida proident, suntid est.", "cpp", 23 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 66, 3, "Excepteur sint in culpa id est laborum.", "python", 23 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 65, 0, "Excepteur sint cupitat, anim id est laborum.", "ruby", 22 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 64, 4, "Nemo enim ipsam voptatem aut odit.", "swift", 22 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 63, 2, "Quis autem vel eum iure repreherit in ea quam.", "php", 22 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 62, 2, "Excepteur occaecat cupida proident, suntid est.", "cpp", 22 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 61, 4, "Excepteur sint cupitat, anim id est laborum.", "ruby", 21 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 60, 3, "Nemo enim ipsam voptatem aut odit.", "swift", 21 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 58, 4, "Excepteur occaecat cupida proident, suntid est.", "cpp", 21 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 39, 3, "Nemo enim ipsam voptatem aut odit.", "swift", 14 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 38, 1, "Quis autem vel eum iure repreherit in ea quam.", "php", 14 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 37, 3, "Excepteur occaecat cupida proident, suntid est.", "cpp", 14 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 16, 3, "Excepteur occaecat cupida proident, suntid est.", "cpp", 7 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 15, 0, "Excepteur sint in culpa id est laborum.", "python", 7 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 14, 3, "Excepteur sint in culpa id est laborum.", "python", 6 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 13, 2, "Nemo enim ipsam voptatem aut odit.", "swift", 5 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 12, 4, "Quis autem vel eum iure repreherit in ea quam.", "php", 4 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 11, 1, "Excepteur occaecat cupida proident, suntid est.", "cpp", 4 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 10, 2, "Excepteur sint in culpa id est laborum.", "python", 4 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 9, 3, "Excepteur sint cupitat, anim id est laborum.", "ruby", 3 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 8, 1, "Nemo enim ipsam voptatem aut odit.", "swift", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 7, 3, "Quis autem vel eum iure repreherit in ea quam.", "php", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 6, 4, "Excepteur occaecat cupida proident, suntid est.", "cpp", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 5, 3, "Excepteur sint in culpa id est laborum.", "python", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 4, 2, "Ut enim ad minima, exercitationem ullam.", "java", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 3, 1, "Nemo enim sit aspernatur aut odit.", "angular", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 2, 2, "Quis autem vel eum iure repreherit in ea quam.", "php", 1 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 17, 4, "Quis autem vel eum iure repreherit in ea quam.", "php", 7 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 18, 2, "Quis autem eum iur velit esse quam.", "javascript", 8 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 19, 1, "Nemo enim sit aspernatur aut odit.", "angular", 8 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 20, 1, "Ut enim ad minima, exercitationem ullam.", "java", 8 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 36, 1, "Excepteur sint in culpa id est laborum.", "python", 14 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 35, 1, "Excepteur sint cupitat, anim id est laborum.", "ruby", 13 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 34, 4, "Nemo enim ipsam voptatem aut odit.", "swift", 12 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 33, 3, "Quis autem vel eum iure repreherit in ea quam.", "php", 12 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 32, 3, "Excepteur occaecat cupida proident, suntid est.", "cpp", 12 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 31, 1, "Excepteur sint in culpa id est laborum.", "python", 12 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 30, 4, "Ut enim ad minima, exercitationem ullam.", "java", 12 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 75, 0, "Quis autem eum iur velit esse quam.", "javascript", 27 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 29, 4, "Excepteur occaecat cupida proident, suntid est.", "cpp", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 27, 0, "Excepteur sint cupitat, anim id est laborum.", "ruby", 10 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 26, 0, "Quis autem vel eum iure repreherit in ea quam.", "php", 9 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 25, 4, "Excepteur occaecat cupida proident, suntid est.", "cpp", 9 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 24, 2, "Nemo enim ipsam voptatem aut odit.", "swift", 8 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 23, 0, "Quis autem vel eum iure repreherit in ea quam.", "php", 8 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 22, 0, "Excepteur occaecat cupida proident, suntid est.", "cpp", 8 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 21, 3, "Excepteur sint in culpa id est laborum.", "python", 8 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 28, 0, "Excepteur sint in culpa id est laborum.", "python", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 76, 3, "Nemo enim sit aspernatur aut odit.", "angular", 27 });

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
