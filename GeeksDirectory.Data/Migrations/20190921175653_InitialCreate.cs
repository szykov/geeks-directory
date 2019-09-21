using System;
using Microsoft.EntityFrameworkCore.Metadata;
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                values: new object[,]
                {
                    { "b8eb90fa-e25a-43e1-a5b6-dadfc2bcf2a1", 0, "e5fade06-d6a6-4e23-bf56-ab678b5082c1", "sergey.zykov@mail.some", false, false, null, "SERGEY.ZYKOV@MAIL.SOME", "SERGEY.ZYKOV@MAIL.SOME", "AQAAAAEAACcQAAAAEACZ58zdtzy3DNmEujYTg6fSy0dpcqgopBzCAYvcRrN2Gz6/g+uJuNIA4m9VsAA/qw==", null, false, "f1549963-5171-45ef-b96f-9ec05d7274a2", false, "sergey.zykov@mail.some" },
                    { "e30e2446-ad11-46d6-bc13-68097fae0440", 0, "deb7911f-7b9b-44b5-b465-d27ee1b80a19", "nikolay.borisov@mail.some", false, false, null, "NIKOLAY.BORISOV@MAIL.SOME", "NIKOLAY.BORISOV@MAIL.SOME", "AQAAAAEAACcQAAAAEC1r2/IcWMAuoyYumZppcza4PirmT0J9qumzSyfdHgakhpiosSidmS0EoUsJu4otIQ==", null, false, "586a2159-6980-4512-ab54-59b6a0151c0e", false, "nikolay.borisov@mail.some" },
                    { "511a47e8-9c86-4ce7-996f-9e1a72b53e69", 0, "c44fd2bf-521d-4eee-9bd9-f198369e6daf", "oskar.davtyan@mail.some", false, false, null, "OSKAR.DAVTYAN@MAIL.SOME", "OSKAR.DAVTYAN@MAIL.SOME", "AQAAAAEAACcQAAAAEE9d5H0bE1XCdMrKj/flcJsQdRoHldbGqi/L6tEk89hbNR7plRFfIizhvv4wvtcKrg==", null, false, "fa77d36b-5a36-468a-ae09-363bb3cf912d", false, "oskar.davtyan@mail.some" },
                    { "98d7661f-19ac-4909-bf20-e700dd07c19a", 0, "46f82492-77e4-48f8-a0f3-dff47f710893", "anjela.trofimova@mail.some", false, false, null, "ANJELA.TROFIMOVA@MAIL.SOME", "ANJELA.TROFIMOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEE7KKxCc61yTzJwl+mKEZU91PQ7ARDMsxWBWwSiuFO15LtCuvd/u+Ujww0KOBfa4Aw==", null, false, "a1669459-e6c8-4e4a-9b4f-2d52d0f81726", false, "anjela.trofimova@mail.some" },
                    { "d5a53242-1c53-42dd-8833-a5072b367d80", 0, "a6a817f3-8e61-4f3c-b6ec-b32d19e2e166", "vanera.ryabova@mail.some", false, false, null, "VANERA.RYABOVA@MAIL.SOME", "VANERA.RYABOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEKUGxCOP+6KQEnRXJKAYqKS/W3Q9vrbl1Ud6xN1sKTxp6fujDaraDcrj3efwcfAAnQ==", null, false, "2120090b-2156-4819-ae75-46ff15112b9f", false, "vanera.ryabova@mail.some" },
                    { "f61dd9a6-49ee-4c40-ae5a-9b6b9122a38e", 0, "c9e66302-43ed-449e-9b19-ed4dd0c006ae", "polina.davydova@mail.some", false, false, null, "POLINA.DAVYDOVA@MAIL.SOME", "POLINA.DAVYDOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEDOFhwwbMvVkF4wwabUq4x8eYb5LKgNs7OxHpczdCjSMzo36pkfvIylCYj2op58oZA==", null, false, "ae6808f2-fc54-47cf-aa40-3fe98d6de68e", false, "polina.davydova@mail.some" },
                    { "ae8f195d-426c-45b3-8f56-17ef57fd3148", 0, "ab1b14f9-6ff7-4fd1-b383-2ea4916581d1", "vlada.lipnitskaya@mail.some", false, false, null, "VLADA.LIPNITSKAYA@MAIL.SOME", "VLADA.LIPNITSKAYA@MAIL.SOME", "AQAAAAEAACcQAAAAEIVnSwqZ0IfwBxiakrtLInzj43wz4RVeFqazG7xNNFmvntPmbF/wXwgTUro4oK8sTg==", null, false, "5499590c-4c8a-4c9d-a649-183fcd91fb03", false, "vlada.lipnitskaya@mail.some" },
                    { "73ad683c-7127-4b43-bc6c-c9e2a086d4c1", 0, "04b8aa3b-56ce-487c-959f-0ab85aded04a", "lubov.orehova@mail.some", false, false, null, "LUBOV.OREHOVA@MAIL.SOME", "LUBOV.OREHOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEKSH7de5k7h3eRvCgO288ZcDzurX35umCXYOsY/dj8ij/wUGUBHnYUqQ2UE4vbGtWQ==", null, false, "b23626d2-0cd6-4e09-b302-a501039832e7", false, "lubov.orehova@mail.some" },
                    { "4da310b4-87bb-4690-90c8-bf437114ae8e", 0, "87d592bb-0cac-4269-ab64-622ce4b942cf", "vladimir.udin@mail.some", false, false, null, "VLADIMIR.UDIN@MAIL.SOME", "VLADIMIR.UDIN@MAIL.SOME", "AQAAAAEAACcQAAAAEME6oOkX5D5TWwU2GIS6DtHioxxSOfVCSapzf9ggxPaS530k2WOiPU+s3hM3OLtBKA==", null, false, "e6bdd717-b554-4922-ab3b-c40a212fa2e9", false, "vladimir.udin@mail.some" },
                    { "dabe2f8b-5545-4572-8468-5febf3a15a09", 0, "d8af7891-1a58-4280-9d58-17035be05275", "oskar.kapustin@mail.some", false, false, null, "OSKAR.KAPUSTIN@MAIL.SOME", "OSKAR.KAPUSTIN@MAIL.SOME", "AQAAAAEAACcQAAAAEGbynSN33QSjtmC1HAkgQrhhQgR9Bjfi6v9b2ihU0cRVhYj0wLjhhzc+9UJnxAORNA==", null, false, "2e4bc32a-24f6-4815-b060-57bf0bd57c48", false, "oskar.kapustin@mail.some" },
                    { "83d419be-12fb-4c32-9079-44a6bf1f0086", 0, "3d5a1655-545e-4175-96bd-3a0a4a7d63d1", "vsevolod.lenin@mail.some", false, false, null, "VSEVOLOD.LENIN@MAIL.SOME", "VSEVOLOD.LENIN@MAIL.SOME", "AQAAAAEAACcQAAAAEKDtp/FrJUqs2f2Dxck70Vqm5OKmjuqOJc3y06ipZ7/UyNAJJir1bnIYD54sXVZFPQ==", null, false, "1e303ac1-149d-41e5-9409-e1378faf2fc8", false, "vsevolod.lenin@mail.some" },
                    { "a020921d-a94e-4606-b090-dc96d12ffd95", 0, "8f3b0ad1-dedc-4e15-82f4-e86000d29f1c", "galena.volkova@mail.some", false, false, null, "GALENA.VOLKOVA@MAIL.SOME", "GALENA.VOLKOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEDRBf3QaS9yANGAxmaLAI+ErIp2hyJVL/S5oP2I3Ac1y8ODm1Ng13Wv/F7KOCElWyQ==", null, false, "59d5525c-7221-41f2-a1ab-0ed307f12860", false, "galena.volkova@mail.some" },
                    { "a728faec-b5c7-41f4-bd56-162a897ff46f", 0, "0d54fa88-9f13-4535-8b47-1df7a8435a1f", "donat.latykin@mail.some", false, false, null, "DONAT.LATYKIN@MAIL.SOME", "DONAT.LATYKIN@MAIL.SOME", "AQAAAAEAACcQAAAAEEuHbC7Uz+89Bibowa0T6THKnZg98aLnaMLS3V/nZyWT6kfbrNLephgnHmRVkeFC+A==", null, false, "1f48bc8a-8c4d-4588-8152-0b338f1ef1ec", false, "donat.latykin@mail.some" },
                    { "8bd9b467-e47b-4720-ad89-6eda8d254f86", 0, "8f5ef248-08da-4101-9c1c-00afee3a47a8", "alina.lazareva@mail.some", false, false, null, "ALINA.LAZAREVA@MAIL.SOME", "ALINA.LAZAREVA@MAIL.SOME", "AQAAAAEAACcQAAAAEHVo76x9Kdm3DiWajFSkVPa8Fi5B3x2xTIeFnz39vRMKI4qVUQppVpJXUGR7f49bbg==", null, false, "fc654304-e722-4cb0-a3f6-3d08a16b6464", false, "alina.lazareva@mail.some" },
                    { "bb88c60a-257e-4b84-9a07-45206ccb3aad", 0, "9bcada4e-20da-4afe-87a2-5ab33e816c76", "zarina.uvarova@mail.some", false, false, null, "ZARINA.UVAROVA@MAIL.SOME", "ZARINA.UVAROVA@MAIL.SOME", "AQAAAAEAACcQAAAAEBYyb2KDrGfH+mFP7Up51G4VRUK/ryD+MGVFsnSSwnLp+jJpOx+gGC12ULuwgFKxpg==", null, false, "aabc7d0b-e763-493e-8cf2-acfc47364674", false, "zarina.uvarova@mail.some" },
                    { "64642283-ef5f-4d48-9ef6-9a4e30b8332e", 0, "d385f8fb-8fa5-44d3-8277-252c0e46f73b", "albert.archipov@mail.some", false, false, null, "ALBERT.ARCHIPOV@MAIL.SOME", "ALBERT.ARCHIPOV@MAIL.SOME", "AQAAAAEAACcQAAAAEEFGHu1QBKhXKP2ISGFT+gRlIjuJwR+BNdIbjEv35t9Vwfr6tQqyK3LoA18Baqqpbw==", null, false, "412937f6-eafe-4c5c-83d2-0a5fee645f16", false, "albert.archipov@mail.some" },
                    { "1a206a7d-646f-4c48-8578-1d2e6a76df05", 0, "025bb42b-e330-46f2-9a5c-4d8e8dd4c210", "zlata.tretyakova@mail.some", false, false, null, "ZLATA.TRETYAKOVA@MAIL.SOME", "ZLATA.TRETYAKOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEENcvyX4vxLIuxlkPBCTRq9QGpNqVL2TeHZ2xnkc6/eG6BLCM9AHhmlxnarb9A/M7A==", null, false, "19c52718-bd2b-422b-935f-21710e6264ac", false, "zlata.tretyakova@mail.some" },
                    { "46b27f3b-dca0-4b4a-8b2a-ab2b263c1171", 0, "c8552aa6-bb93-4ea5-96dc-7f8da23e215b", "vasya.alekseev@mail.some", false, false, null, "VASYA.ALEKSEEV@MAIL.SOME", "VASYA.ALEKSEEV@MAIL.SOME", "AQAAAAEAACcQAAAAEBOYTe4erVX9GrhAJ+H5UZEBaMo8lPoNiHL7NDP+Cx/60RIwOPWgyK0mE6OnBMnD5g==", null, false, "8e152985-cb5f-4128-ab8e-696e8cd91779", false, "vasya.alekseev@mail.some" },
                    { "964fb987-c3d0-4a17-a417-fb7edce1e3aa", 0, "650a7ece-9aed-4e00-bc67-c7d05b548491", "radislav.barsov@mail.some", false, false, null, "RADISLAV.BARSOV@MAIL.SOME", "RADISLAV.BARSOV@MAIL.SOME", "AQAAAAEAACcQAAAAEAmUAGUgqMzMPmnOzccZAYjrcxLwIB5iei/T882kkZ/W0MC1OtvNNXbVAmo0OKmb7Q==", null, false, "972343c3-c73c-44f6-9787-89d3bd300aa9", false, "radislav.barsov@mail.some" },
                    { "dc440a63-da95-43b0-98aa-3f4c4ff2a053", 0, "40a9fe4f-d5fe-477b-b6a9-3ac1eb196e76", "arsenia.panova@mail.some", false, false, null, "ARSENIA.PANOVA@MAIL.SOME", "ARSENIA.PANOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEI5MeeiJ8LIcTMLacSpJ0S+wnShZRxiZOV0L3Jy6d44fwECX+gXDdlH76O/NG3xa5Q==", null, false, "a0269c67-a128-4e61-b9be-efa029e49af3", false, "arsenia.panova@mail.some" },
                    { "b270427f-fc46-4fdc-b3d9-3bdc64364d0e", 0, "76e868e0-3070-4f7b-863c-6ace2b63de6e", "violeta.kanygina@mail.some", false, false, null, "VIOLETA.KANYGINA@MAIL.SOME", "VIOLETA.KANYGINA@MAIL.SOME", "AQAAAAEAACcQAAAAEJkeKhsDi1L0cSDw4SISWm+GFHYz4zJBRTF6cK3jhLBw7AT0k+d73IkguUDAQiBPJw==", null, false, "f62ea1bb-c72d-4f4c-be48-44d36a18855f", false, "violeta.kanygina@mail.some" },
                    { "4f99f9b1-b054-455e-9daa-8f0592823568", 0, "0e32412d-d2bb-4ceb-8bc1-8a76f91a92cc", "andrey.vladimirov@mail.some", false, false, null, "ANDREY.VLADIMIROV@MAIL.SOME", "ANDREY.VLADIMIROV@MAIL.SOME", "AQAAAAEAACcQAAAAEBYMA9NO47YVZvN09QcGi7CE2dt3RQlnu0FWD8dFGL5ap9c7M8xQFSWXLygYd80xiw==", null, false, "a8dcb4ec-ad54-4cb9-aa51-76798838d0fd", false, "andrey.vladimirov@mail.some" },
                    { "8636b3d5-af78-4a6f-a773-c96404516ba5", 0, "46493b28-30cb-4132-a543-9f00d955d6a0", "dasha.egorova@mail.some", false, false, null, "DASHA.EGOROVA@MAIL.SOME", "DASHA.EGOROVA@MAIL.SOME", "AQAAAAEAACcQAAAAEJDDVIGa+gqnITTcXyn1zqkPOJTPC7WQzBN/je+wj1jN+FouRVzIULj4Y5KKyp7lFA==", null, false, "626f6f95-8cd1-4c0c-86ef-af84206e247e", false, "dasha.egorova@mail.some" },
                    { "3fa5371e-5d44-42c6-b71f-daf3d38b2c5b", 0, "26c036d9-5bbd-4b88-8c50-03b20e83db26", "ivan.ivanov@mail.some", false, false, null, "IVAN.IVANOV@MAIL.SOME", "IVAN.IVANOV@MAIL.SOME", "AQAAAAEAACcQAAAAEIeDS/oYm0kqJFQgOfTa/K6c160ARrzGRaUndDQuxB5uJMejZ3l6XqdcD5VGCHbKFg==", null, false, "87f11ffc-4085-4e4a-8619-4af4a7e174c4", false, "ivan.ivanov@mail.some" },
                    { "0a50dbc4-23b5-4e0d-b588-0a7a72df0ed1", 0, "c4d69d7a-656e-472b-b057-1b37b69213bf", "john.smith@mail.some", false, false, null, "JOHN.SMITH@MAIL.SOME", "JOHN.SMITH@MAIL.SOME", "AQAAAAEAACcQAAAAEB8W5NLTfuXUQB1lDiT4Z0mXjcMHmcGIJjqPDHZ0p8EeXaU6ULXIBne23O/b2la6Sw==", null, false, "babf4b69-99d7-4f08-aa49-55772f6b09bf", false, "john.smith@mail.some" },
                    { "ab9f49d7-f20a-4951-88db-f75fcded0fe9", 0, "45bec219-eb76-46ae-970d-d7bc9c67d988", "nadezda.kolesnikova@mail.some", false, false, null, "NADEZDA.KOLESNIKOVA@MAIL.SOME", "NADEZDA.KOLESNIKOVA@MAIL.SOME", "AQAAAAEAACcQAAAAEKKMguXL0CKMs6BdqfLOJ8Gh5tznQl3UPHFCyg975OCx3tGwId6Gn+AGIidEQ28jrw==", null, false, "c27999ed-69c0-4e33-ac5d-233eb13a8b71", false, "nadezda.kolesnikova@mail.some" },
                    { "b1091cd4-d605-480b-aa23-6f49df0e53ad", 0, "323240ad-419b-4059-9638-5f9864b2b4c3", "maksim.kuzmin@mail.some", false, false, null, "MAKSIM.KUZMIN@MAIL.SOME", "MAKSIM.KUZMIN@MAIL.SOME", "AQAAAAEAACcQAAAAEMvC4RyWUeumNvk4mRB+kjoKGE2vR8+uDeHfqk/K/X1QNXold+pZ0o334K2U+NYArg==", null, false, "1d5764f9-e21f-466e-b0e5-eeea5db5df80", false, "maksim.kuzmin@mail.some" }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "ProfileId", "City", "MiddleName", "Name", "Surname", "UserName" },
                values: new object[,]
                {
                    { 1, "Moscow", null, "Sergey", "Zykov", "b8eb90fa-e25a-43e1-a5b6-dadfc2bcf2a1" },
                    { 25, "Mikhaylovka", null, "Nikolay", "Borisov", "e30e2446-ad11-46d6-bc13-68097fae0440" },
                    { 24, "Latoshinka", null, "Oskar", "Davtyan", "511a47e8-9c86-4ce7-996f-9e1a72b53e69" },
                    { 23, "Khvatkovo", null, "Anjela", "Trofimova", "98d7661f-19ac-4909-bf20-e700dd07c19a" },
                    { 22, "Krutilovka", null, "Vanera", "Ryabova", "d5a53242-1c53-42dd-8833-a5072b367d80" },
                    { 21, "Aryntsas", null, "Polina", "Davydova", "f61dd9a6-49ee-4c40-ae5a-9b6b9122a38e" },
                    { 20, "Nikitino", null, "Vlada", "Lipnitskaya", "ae8f195d-426c-45b3-8f56-17ef57fd3148" },
                    { 19, "Ragozina", null, "Lubov", "Orehova", "73ad683c-7127-4b43-bc6c-c9e2a086d4c1" },
                    { 18, "Skolkovo", null, "Vladimir", "Udin", "4da310b4-87bb-4690-90c8-bf437114ae8e" },
                    { 17, "Shvedovo", null, "Oskar", "Kapustin", "dabe2f8b-5545-4572-8468-5febf3a15a09" },
                    { 16, "Ungavitsa", null, "Vsevolod", "Lenin", "83d419be-12fb-4c32-9079-44a6bf1f0086" },
                    { 15, "Agutino", null, "Galena", "Volkova", "a020921d-a94e-4606-b090-dc96d12ffd95" },
                    { 26, "Nygda", null, "Donat", "Latykin", "a728faec-b5c7-41f4-bd56-162a897ff46f" },
                    { 14, "Lykoshina", null, "Alina", "Lazareva", "8bd9b467-e47b-4720-ad89-6eda8d254f86" },
                    { 12, "Trostyanka", null, "Zarina", "Uvarova", "bb88c60a-257e-4b84-9a07-45206ccb3aad" },
                    { 11, "Golitsyno", null, "Albert", "Archipov", "64642283-ef5f-4d48-9ef6-9a4e30b8332e" },
                    { 10, "Karaichev", null, "Zlata", "Tretyakova", "1a206a7d-646f-4c48-8578-1d2e6a76df05" },
                    { 9, "Walnut Park", null, "Vasya", "Alekseev", "46b27f3b-dca0-4b4a-8b2a-ab2b263c1171" },
                    { 8, "Kenton Vale", null, "Radislav", "Barsov", "964fb987-c3d0-4a17-a417-fb7edce1e3aa" },
                    { 7, "Dupree", null, "Arsenia", "Panova", "dc440a63-da95-43b0-98aa-3f4c4ff2a053" },
                    { 6, "New Preston", null, "Violeta", "Kanygina", "b270427f-fc46-4fdc-b3d9-3bdc64364d0e" },
                    { 5, "Landmark", null, "Andrey", "Vladimirov", "4f99f9b1-b054-455e-9daa-8f0592823568" },
                    { 4, "Deport", null, "Dasha", "Egorova", "8636b3d5-af78-4a6f-a773-c96404516ba5" },
                    { 3, "St. Petersburg", null, "Ivan", "Ivanov", "3fa5371e-5d44-42c6-b71f-daf3d38b2c5b" },
                    { 2, "Ekaterinburg", null, "John", "Smith", "0a50dbc4-23b5-4e0d-b588-0a7a72df0ed1" },
                    { 13, "Stawropol", null, "Nadezda", "Kolesnikova", "ab9f49d7-f20a-4951-88db-f75fcded0fe9" },
                    { 27, "Taygach", null, "Maksim", "Kuzmin", "b1091cd4-d605-480b-aa23-6f49df0e53ad" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "AverageScore", "Description", "Name", "ProfileId" },
                values: new object[,]
                {
                    { 1, 2, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 1 },
                    { 58, 1, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 21 },
                    { 57, 2, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 21 },
                    { 56, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 20 },
                    { 55, 0, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 20 },
                    { 54, 1, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 20 },
                    { 53, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 20 },
                    { 52, 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 20 },
                    { 59, 1, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "angular", 22 },
                    { 51, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 19 },
                    { 49, 4, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 19 },
                    { 48, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 19 },
                    { 47, 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 19 },
                    { 46, 2, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 19 },
                    { 45, 0, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "angular", 19 },
                    { 44, 2, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "javascript", 19 },
                    { 43, 2, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 18 },
                    { 50, 0, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 19 },
                    { 42, 0, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 17 },
                    { 60, 1, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 22 },
                    { 62, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 22 },
                    { 78, 3, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 27 },
                    { 77, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 27 },
                    { 76, 3, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 26 },
                    { 75, 3, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "angular", 26 },
                    { 74, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 25 },
                    { 73, 2, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 25 },
                    { 72, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 24 },
                    { 61, 2, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 22 },
                    { 71, 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 23 },
                    { 69, 2, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 23 },
                    { 68, 3, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 23 },
                    { 67, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 23 },
                    { 66, 1, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 23 },
                    { 65, 2, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 22 },
                    { 64, 4, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 22 },
                    { 63, 3, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 22 },
                    { 70, 0, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 23 },
                    { 41, 1, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 17 },
                    { 40, 3, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 17 },
                    { 39, 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 17 },
                    { 17, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 9 },
                    { 16, 1, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 9 },
                    { 15, 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 8 },
                    { 14, 1, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 8 },
                    { 13, 0, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 8 },
                    { 12, 2, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 8 },
                    { 11, 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 7 },
                    { 18, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 9 },
                    { 10, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 6 },
                    { 8, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 4 },
                    { 7, 4, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 4 },
                    { 6, 0, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 3 },
                    { 5, 2, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 2 },
                    { 4, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 2 },
                    { 3, 2, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 2 },
                    { 2, 3, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "angular", 2 },
                    { 9, 1, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 5 },
                    { 19, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 10 },
                    { 20, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 11 },
                    { 21, 3, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 12 },
                    { 38, 1, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 17 },
                    { 37, 0, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "angular", 17 },
                    { 36, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "ruby", 16 },
                    { 35, 3, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 16 },
                    { 34, 1, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 16 },
                    { 33, 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 16 },
                    { 32, 4, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 16 },
                    { 31, 2, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 16 },
                    { 30, 1, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 15 },
                    { 29, 2, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 15 },
                    { 28, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 15 },
                    { 27, 3, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 15 },
                    { 26, 0, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 14 },
                    { 25, 2, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 13 },
                    { 24, 0, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "cpp", 13 },
                    { 23, 1, "Excepteur sint occaecat cupidatat non proident, sunt in culpa anim id est laborum.", "python", 13 },
                    { 22, 3, "Ut enim ad minima veniam, quis nostrum exercitationem ullam.", "java", 13 },
                    { 79, 4, "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam.", "php", 27 },
                    { 80, 4, "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit.", "swift", 27 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
