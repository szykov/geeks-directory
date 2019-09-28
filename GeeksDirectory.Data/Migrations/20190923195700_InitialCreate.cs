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
                values: new object[] { "b8eb90fa-e25a-43e1-a5b6-dadfc2bcf2a1", 0, "dc15ffea-704e-4bc2-819c-2f6e93120692", "sergey.zykov@mail.some", false, false, null, "SERGEY.ZYKOV@MAIL.SOME", "SERGEY.ZYKOV@MAIL.SOME", "AQAAAAEAACcQAAAAELnOrTUIse1FYOicgj9azB8fg2VDZC6sHgEsUOQvfcPfn0GyruNOsJ5rVNiCLeoh3Q==", null, false, "1b4a91bc-d37d-4e13-ac8c-5f0c6fdf5c09", false, "sergey.zykov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e30e2446-ad11-46d6-bc13-68097fae0440", 0, "c2ad7ee5-d009-4ce5-9063-2c5db6be54a5", "nikolay.borisov@mail.some", false, false, null, "NIKOLAY.BORISOV@MAIL.SOME", "NIKOLAY.BORISOV@MAIL.SOME", "AQAAAAEAACcQAAAAEBVd8wQPfP3oHSsgko/g8QGPBbWt6fUOHM4PPjrVPcLM+FSs1ivjGhoXalodgid+Yw==", null, false, "7cc18e88-7271-4a15-8a19-dc1c29063476", false, "nikolay.borisov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "511a47e8-9c86-4ce7-996f-9e1a72b53e69", 0, "398a8551-2b8f-4fd3-a995-558f5309cf59", "oskar.davtyan@mail.some", false, false, null, "OSKAR.DAVTYAN@MAIL.SOME", "OSKAR.DAVTYAN@MAIL.SOME", "AQAAAAEAACcQAAAAEB8+k+25cR+EYulU3XHHlHzBGoJIujQX6JAtM6CVehzhpJYZ7oJ1TfsXcTJSkwqJaA==", null, false, "0e7f44f4-2dd4-4733-bdba-cf8b453d9103", false, "oskar.davtyan@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "98d7661f-19ac-4909-bf20-e700dd07c19a", 0, "d0227bc5-d988-4704-8acc-4e0e6b5a12a7", "anjela.trofimova@mail.some", false, false, null, "ANJELA.TROFIMOVA@MAIL.SOME", "ANJELA.TROFIMOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEOYvNOlT/A59Rk0xsnpxBaGnjQpt2jywdlaqz2Glv5kU0yjSIvC/lRbmOXSt7jGy2g==", null, false, "5caee5fc-5399-498f-af7e-f552fea95346", false, "anjela.trofimova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d5a53242-1c53-42dd-8833-a5072b367d80", 0, "3dce8241-72c8-4988-9b6c-12ae676b14d6", "vanera.ryabova@mail.some", false, false, null, "VANERA.RYABOVA@MAIL.SOME", "VANERA.RYABOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEHGhgCA7uWZm9kwM/4fbuDLOHxM7Rpua82UxOL/EaXlpJtyGf3HzXr4V2C7JqQRDwg==", null, false, "4bf171da-04cf-4a0b-b8a7-04f45c25ac7b", false, "vanera.ryabova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f61dd9a6-49ee-4c40-ae5a-9b6b9122a38e", 0, "bcb65171-303a-4150-920a-f4a11f85e96a", "polina.davydova@mail.some", false, false, null, "POLINA.DAVYDOVA@MAIL.SOME", "POLINA.DAVYDOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEBzEUUkSFj+w11JeJLgqrf6lYhPL/d9o3Q8bJytWZVqNl9Cpi8KW3C5TgWmSbcRtMA==", null, false, "0cbc34f9-aa34-45dd-93c9-4b93b74e518f", false, "polina.davydova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ae8f195d-426c-45b3-8f56-17ef57fd3148", 0, "661d4bd5-7037-4d0e-a086-067d7f801124", "vlada.lipnitskaya@mail.some", false, false, null, "VLADA.LIPNITSKAYA@MAIL.SOME", "VLADA.LIPNITSKAYA@MAIL.SOME", "AQAAAAEAACcQAAAAEMy0GIub0l20LxYrUdKgoScDUE7nEGdg2lUx/H9kk7MNGYUMrV/1PcsofYZbZQwDWQ==", null, false, "1b2ba1c7-5a23-47e9-89b3-bad7e6a55bdf", false, "vlada.lipnitskaya@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "73ad683c-7127-4b43-bc6c-c9e2a086d4c1", 0, "66aa020e-6331-48d1-a1f7-aedd25727351", "lubov.orehova@mail.some", false, false, null, "LUBOV.OREHOVA@MAIL.SOME", "LUBOV.OREHOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEAlQh+fItP6SKi5Thupcbeb9oAuEtWJutnEU2ci409cdpVGaTxoILTtxSINWuKdnSA==", null, false, "b9443557-ec3a-4b1f-92a4-68d49b3a4866", false, "lubov.orehova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4da310b4-87bb-4690-90c8-bf437114ae8e", 0, "8b127f2c-927f-483c-a2ec-b4d150469119", "vladimir.udin@mail.some", false, false, null, "VLADIMIR.UDIN@MAIL.SOME", "VLADIMIR.UDIN@MAIL.SOME", "AQAAAAEAACcQAAAAEJyd8oDdSpASS/H1G0Rb/8ASwgwBxcv18W0NjqN33lrqI8l59DR0b/2OaR8dsUq3LA==", null, false, "e3df0db9-6a98-4764-ae51-52e16bb689a2", false, "vladimir.udin@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dabe2f8b-5545-4572-8468-5febf3a15a09", 0, "ca7649a1-abfa-49d6-9497-ccb65126ff08", "oskar.kapustin@mail.some", false, false, null, "OSKAR.KAPUSTIN@MAIL.SOME", "OSKAR.KAPUSTIN@MAIL.SOME", "AQAAAAEAACcQAAAAEFFA8MQ0CSB2wDszzKR/I4zVdxTynLLMzecy08nwHN052WhGA5RIS6p05z5U06L2wQ==", null, false, "a58cf444-e330-4688-ad6c-7ee0d65c8c5c", false, "oskar.kapustin@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "83d419be-12fb-4c32-9079-44a6bf1f0086", 0, "6c65cdce-cd49-4a1a-b640-c118fb9ba254", "vsevolod.lenin@mail.some", false, false, null, "VSEVOLOD.LENIN@MAIL.SOME", "VSEVOLOD.LENIN@MAIL.SOME", "AQAAAAEAACcQAAAAEOYMHwMNYgG1ta4JRJmgUgV+dTfVrIwl5Jw4FozDYxjqwLgDnGKOg6XuwLP8kyArHQ==", null, false, "bd080270-1fd1-4e86-a238-5e733c7fd84c", false, "vsevolod.lenin@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a020921d-a94e-4606-b090-dc96d12ffd95", 0, "c8f01a99-0354-453f-9a7a-76aacea3cb94", "galena.volkova@mail.some", false, false, null, "GALENA.VOLKOVA@MAIL.SOME", "GALENA.VOLKOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEAYC2LQrv3E7D5grrHji8QQEWrlzFTQznBxJV53kvk7PuG7Eg8glspD5qmN71d4bdQ==", null, false, "311aecf3-4991-4fb2-a4bb-a2fc58053b70", false, "galena.volkova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a728faec-b5c7-41f4-bd56-162a897ff46f", 0, "78c03f2b-c279-4da3-99cc-47d44e410017", "donat.latykin@mail.some", false, false, null, "DONAT.LATYKIN@MAIL.SOME", "DONAT.LATYKIN@MAIL.SOME", "AQAAAAEAACcQAAAAEMOz6Lp8ZgawwxjzztJW1G21FybGJ6B0WJeCRUlJIgWlJ3n/BhM/vgkm3lHmSTgYcw==", null, false, "820e23ca-d33c-4b96-8726-f4af9f5fbe8f", false, "donat.latykin@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8bd9b467-e47b-4720-ad89-6eda8d254f86", 0, "34bc4695-81e4-4789-8a54-b8a80e1dab7e", "alina.lazareva@mail.some", false, false, null, "ALINA.LAZAREVA@MAIL.SOME", "ALINA.LAZAREVA@MAIL.SOME", "AQAAAAEAACcQAAAAEN2VyIbIlj3wmFvRtetoa28ti8cX9YeugNiRVPq8KN4t87HC27sLAco/61gVilTAcQ==", null, false, "6f994d7f-5c26-404e-8f10-b108dc74f596", false, "alina.lazareva@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bb88c60a-257e-4b84-9a07-45206ccb3aad", 0, "d2691e8f-7c54-468b-b668-07c2c735d884", "zarina.uvarova@mail.some", false, false, null, "ZARINA.UVAROVA@MAIL.SOME", "ZARINA.UVAROVA@MAIL.SOME", "AQAAAAEAACcQAAAAEAeAJCZeM5Loh5v9Cz6Oa//SFqnyAWBZS9vy3q7nCtddGoDUF6KUSrbQaVvpGFKJ6w==", null, false, "39c2307e-6d85-4c56-b22b-a02e3fe39c7b", false, "zarina.uvarova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "64642283-ef5f-4d48-9ef6-9a4e30b8332e", 0, "19dd5afe-ddd0-44e6-8b4d-bb70af0f704f", "albert.archipov@mail.some", false, false, null, "ALBERT.ARCHIPOV@MAIL.SOME", "ALBERT.ARCHIPOV@MAIL.SOME", "AQAAAAEAACcQAAAAEHW3X5gXKVnKPbVjv2q/VZd2SoJPURi2uk7kHkfvQTNtFQhCSCv7AI+ZeAJaNcqvRQ==", null, false, "a9b87232-7fa0-4ce3-9b2c-f058aa806dd1", false, "albert.archipov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a206a7d-646f-4c48-8578-1d2e6a76df05", 0, "440d0332-8636-4684-8f00-2f55599f34f9", "zlata.tretyakova@mail.some", false, false, null, "ZLATA.TRETYAKOVA@MAIL.SOME", "ZLATA.TRETYAKOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEMD23lnzjb085g7riaLIFprUYicqXbLm672mLTAgV1X+AQRC75b1q3Ct6cgS3CURzw==", null, false, "e0a9110e-cb58-4d0d-b35a-400b61502078", false, "zlata.tretyakova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "46b27f3b-dca0-4b4a-8b2a-ab2b263c1171", 0, "f96c6f33-24b0-4062-b6ba-db60eb060be0", "vasya.alekseev@mail.some", false, false, null, "VASYA.ALEKSEEV@MAIL.SOME", "VASYA.ALEKSEEV@MAIL.SOME", "AQAAAAEAACcQAAAAEBmqcOYwgTABUKy/ZeZPuMW/+vciTQ++B9oa9MjMwoTs6efdQ1SRBxyrFVkFcbXGVw==", null, false, "0502cd2c-8d0d-44bc-8cc3-d58182ffb2c8", false, "vasya.alekseev@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "964fb987-c3d0-4a17-a417-fb7edce1e3aa", 0, "43a101c5-cd8a-4a47-b812-9a089e718fe0", "radislav.barsov@mail.some", false, false, null, "RADISLAV.BARSOV@MAIL.SOME", "RADISLAV.BARSOV@MAIL.SOME", "AQAAAAEAACcQAAAAEDX+X+WWTIPCQL3xPz5quNX/CDAv3Mp9/LmWz0T4aGPiAEWqW/Y47GOXgw6BmBcjJA==", null, false, "87a94efa-40a7-46a9-9106-94644e1c671c", false, "radislav.barsov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dc440a63-da95-43b0-98aa-3f4c4ff2a053", 0, "db7fbb08-0811-4410-b0e7-2ec3a15b01b2", "arsenia.panova@mail.some", false, false, null, "ARSENIA.PANOVA@MAIL.SOME", "ARSENIA.PANOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEGIn+YM7oDLtXs2o70VFdkAf/wTT2IdjmyVrh45pu8Hf/3gQbvjRJaq5cIZ93DhcEQ==", null, false, "cd19d407-2a73-46bf-b9da-b073f454ab24", false, "arsenia.panova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b270427f-fc46-4fdc-b3d9-3bdc64364d0e", 0, "b70f2a2a-2f91-4196-977c-ed21a236584f", "violeta.kanygina@mail.some", false, false, null, "VIOLETA.KANYGINA@MAIL.SOME", "VIOLETA.KANYGINA@MAIL.SOME", "AQAAAAEAACcQAAAAEKQwDa1b1bKCVkGjKWUL+iEDv8GlLQEhgCouqtahbsCoeNLY012xP8xq60kQyxSzIA==", null, false, "31777f87-2c18-4e47-a92b-3fd1bcdacb8c", false, "violeta.kanygina@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4f99f9b1-b054-455e-9daa-8f0592823568", 0, "10f0b96f-5fdf-4d63-b2ee-a70a287dc2e8", "andrey.vladimirov@mail.some", false, false, null, "ANDREY.VLADIMIROV@MAIL.SOME", "ANDREY.VLADIMIROV@MAIL.SOME", "AQAAAAEAACcQAAAAEEWU+YcEGEoLe1Tgm0+NxODpCURprYfg7Zz6dQXSJ8oTsPNPBekyJ/kb9fvM2l3fSg==", null, false, "ef994637-f106-428b-88d1-4f9c62099aa5", false, "andrey.vladimirov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8636b3d5-af78-4a6f-a773-c96404516ba5", 0, "c7622e3a-18a1-4fff-bd2f-be680b6c31fd", "dasha.egorova@mail.some", false, false, null, "DASHA.EGOROVA@MAIL.SOME", "DASHA.EGOROVA@MAIL.SOME", "AQAAAAEAACcQAAAAEItpQRm863ANEykLHEpbu95ev8nAenp0siB9lLe2d0NSGCkMaNidQlLK3Qklxiplvw==", null, false, "e4f40cdb-ecd8-4ba5-9e38-25e21a0a6b8b", false, "dasha.egorova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3fa5371e-5d44-42c6-b71f-daf3d38b2c5b", 0, "ee1e1cc3-dbad-4e37-b9ee-6dccccf27261", "ivan.ivanov@mail.some", false, false, null, "IVAN.IVANOV@MAIL.SOME", "IVAN.IVANOV@MAIL.SOME", "AQAAAAEAACcQAAAAEIHEvcfSLH0zdDuszArTNQJHtyppVo6cHMKvqI04fI6XVeX14Nd0uFQPNQ7NYNnIKA==", null, false, "4c0ca75e-a580-42dc-bd79-df1ab42a65df", false, "ivan.ivanov@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0a50dbc4-23b5-4e0d-b588-0a7a72df0ed1", 0, "f0a539c7-527f-4f8d-98c6-efeae6b7d032", "john.smith@mail.some", false, false, null, "JOHN.SMITH@MAIL.SOME", "JOHN.SMITH@MAIL.SOME", "AQAAAAEAACcQAAAAEPaTyUGwJTpb4cEDcA+7NqoK8WpH+GN/zux41wPII1KHilSch7vC8XMwC8NlynRiRQ==", null, false, "2ca8d982-623f-4849-86cb-7333d85f1d00", false, "john.smith@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ab9f49d7-f20a-4951-88db-f75fcded0fe9", 0, "e2fb8f0b-c65a-4b84-b668-709ec22bc4ab", "nadezda.kolesnikova@mail.some", false, false, null, "NADEZDA.KOLESNIKOVA@MAIL.SOME", "NADEZDA.KOLESNIKOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEAbXDlibpRLwMXmDBtnKyfp06YHzfDfQGMxQ0kmRdGrK5CnKT97tVIcc5qtAOyTQ4Q==", null, false, "dc13897e-3e65-4a9c-be1a-876648911881", false, "nadezda.kolesnikova@mail.some" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b1091cd4-d605-480b-aa23-6f49df0e53ad", 0, "ca7dc424-9c14-4531-9dcf-cb5f30a32347", "maksim.kuzmin@mail.some", false, false, null, "MAKSIM.KUZMIN@MAIL.SOME", "MAKSIM.KUZMIN@MAIL.SOME", "AQAAAAEAACcQAAAAEJkICa9UgjMnF4WvO9xBNdWakgACNqs0eSQDgqw3TQQTYdSMHA/fD/C1tS9c1VAlFg==", null, false, "74a93651-399d-4676-aaef-3c35853e0681", false, "maksim.kuzmin@mail.some" });

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
                values: new object[] { 1, 4, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "angular", 1 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 62, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 17 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 61, 2, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 16 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 60, 0, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 16 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 59, 2, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 16 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 58, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 16 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 57, 2, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 15 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 56, 3, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 14 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 55, 2, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 13 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 54, 3, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 13 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 53, 3, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 13 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 52, 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 13 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 51, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 13 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 50, 4, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 13 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 49, 1, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "angular", 13 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 48, 3, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 12 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 47, 2, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 12 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 46, 2, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 12 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 63, 0, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 18 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 64, 4, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 18 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 65, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 19 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 66, 2, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 20 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 84, 4, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 26 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 83, 3, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "angular", 26 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 82, 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 25 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 81, 0, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 25 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 80, 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 24 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 79, 4, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 24 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 78, 3, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 23 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 77, 0, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 23 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 45, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 76, 3, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 23 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 74, 3, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 22 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 73, 4, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 22 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 72, 2, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "angular", 22 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 71, 4, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "javascript", 22 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 70, 0, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do.", "csharp", 22 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 69, 2, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 21 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 68, 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 20 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 67, 2, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 20 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 75, 2, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 22 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 44, 0, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 43, 0, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 42, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 19, 3, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 5 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 18, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 5 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 17, 3, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 5 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 16, 2, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 5 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 15, 4, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 4 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 14, 2, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 3 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 13, 1, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 3 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 12, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 20, 2, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 5 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 11, 4, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 9, 3, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 8, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 7, 0, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 6, 1, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "angular", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 5, 3, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "javascript", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 4, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do.", "csharp", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 3, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 1 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 2, 1, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 1 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 10, 3, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 85, 0, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "javascript", 27 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 21, 3, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 5 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 23, 4, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 7 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 41, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 40, 0, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 39, 0, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "angular", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 38, 0, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "javascript", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 37, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do.", "csharp", 11 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 36, 4, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 10 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 35, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 10 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 34, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 10 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 22, 0, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 6 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 33, 3, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 10 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 31, 2, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 9 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 30, 4, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 9 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 29, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 8 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 28, 0, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 8 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 27, 4, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 8 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 26, 3, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 8 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 25, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 8 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 24, 4, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 7 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 32, 2, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 9 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[] { 86, 0, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "angular", 27 });

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
