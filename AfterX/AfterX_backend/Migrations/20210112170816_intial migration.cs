using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AfterX_backend.Migrations
{
    public partial class intialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "drinkType",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drinkType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "package",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_package", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tableType",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tableType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying", maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    countryid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    zip = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.id);
                    table.ForeignKey(
                        name: "city_countryid_fkey",
                        column: x => x.countryid,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "drink",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    drinktypeid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drink", x => x.id);
                    table.ForeignKey(
                        name: "drink_drinktypeid_fkey",
                        column: x => x.drinktypeid,
                        principalTable: "drinkType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userattribues",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    firstname = table.Column<string>(type: "character varying", nullable: false),
                    lastname = table.Column<string>(type: "character varying", nullable: false),
                    gender = table.Column<char>(type: "character(1)", maxLength: 1, nullable: true),
                    yearofbirth = table.Column<DateTime>(type: "date", nullable: true),
                    telephone = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userattribues", x => x.id);
                    table.UniqueConstraint("AK_userattribues_userid", x => x.userid);
                    table.ForeignKey(
                        name: "userattribues_userid_fkey",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cityid = table.Column<int>(type: "integer", nullable: false),
                    street = table.Column<string>(type: "character varying", nullable: false),
                    number = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "address_cityid_fkey",
                        column: x => x.cityid,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "package_drink",
                columns: table => new
                {
                    packageid = table.Column<int>(type: "integer", nullable: false),
                    drinkid = table.Column<int>(type: "integer", nullable: false),
                    nobottles = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("package_drink_pkey", x => new { x.packageid, x.drinkid });
                    table.ForeignKey(
                        name: "package_drink_drinkid_fkey",
                        column: x => x.drinkid,
                        principalTable: "drink",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "package_drink_packageid_fkey",
                        column: x => x.packageid,
                        principalTable: "package",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_user",
                columns: table => new
                {
                    userid = table.Column<int>(type: "integer", nullable: false),
                    roleid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("role_user_pkey", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "FK_role_user_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "role_user_roleid_fkey",
                        column: x => x.roleid,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "role_user_userid_fkey",
                        column: x => x.userid,
                        principalTable: "userattribues",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "club",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    addressid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_club", x => x.id);
                    table.ForeignKey(
                        name: "club_addressid_fkey",
                        column: x => x.addressid,
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "drink_club",
                columns: table => new
                {
                    drinkid = table.Column<int>(type: "integer", nullable: false),
                    clubid = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("drink_club_pkey", x => new { x.drinkid, x.clubid });
                    table.ForeignKey(
                        name: "drink_club_clubid_fkey",
                        column: x => x.clubid,
                        principalTable: "club",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "drink_club_drinkid_fkey",
                        column: x => x.drinkid,
                        principalTable: "drink",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clubid = table.Column<int>(type: "integer", nullable: false),
                    _date = table.Column<DateTime>(type: "date", nullable: true),
                    description = table.Column<string>(type: "character varying", nullable: true),
                    price = table.Column<decimal>(type: "numeric", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.id);
                    table.ForeignKey(
                        name: "event_clubid_fkey",
                        column: x => x.clubid,
                        principalTable: "club",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clubid = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    desciption = table.Column<string>(type: "character varying", nullable: true),
                    grade = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review", x => x.id);
                    table.ForeignKey(
                        name: "review_clubid_fkey",
                        column: x => x.clubid,
                        principalTable: "club",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "review_userid_fkey",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: false),
                    tabletypeid = table.Column<int>(type: "integer", nullable: false),
                    clubid = table.Column<int>(type: "integer", nullable: false),
                    capacity = table.Column<short>(type: "smallint", nullable: true),
                    minnobottles = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table", x => x.id);
                    table.ForeignKey(
                        name: "table_clubid_fkey",
                        column: x => x.clubid,
                        principalTable: "club",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "table_tabletypeid_fkey",
                        column: x => x.tabletypeid,
                        principalTable: "tableType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tableid = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    reservationdate = table.Column<DateTime>(type: "date", nullable: false),
                    numberofpeople = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.id);
                    table.ForeignKey(
                        name: "reservation_tableid_fkey",
                        column: x => x.tableid,
                        principalTable: "table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "reservation_userid_fkey",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tableid = table.Column<int>(type: "integer", nullable: false),
                    reservationid = table.Column<int>(type: "integer", nullable: false),
                    _note = table.Column<string>(type: "character varying", nullable: true),
                    time = table.Column<TimeSpan>(type: "time without time zone", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "order_reservationid_fkey",
                        column: x => x.reservationid,
                        principalTable: "reservation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "order_tableid_fkey",
                        column: x => x.tableid,
                        principalTable: "table",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_drink",
                columns: table => new
                {
                    orderid = table.Column<int>(type: "integer", nullable: false),
                    drinkid = table.Column<int>(type: "integer", nullable: false),
                    nobottles = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("order_drink_pkey", x => new { x.orderid, x.drinkid });
                    table.ForeignKey(
                        name: "order_drink_drinkid_fkey",
                        column: x => x.drinkid,
                        principalTable: "drink",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "order_drink_orderid_fkey",
                        column: x => x.orderid,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "address_cityid_street_number_key",
                table: "address",
                columns: new[] { "cityid", "street", "number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "city_countryid_name_key",
                table: "city",
                columns: new[] { "countryid", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "club_name_addressid_key",
                table: "club",
                columns: new[] { "name", "addressid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_club_addressid",
                table: "club",
                column: "addressid");

            migrationBuilder.CreateIndex(
                name: "country_name_key",
                table: "country",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "drink_quantity_name_drinktypeid_key",
                table: "drink",
                columns: new[] { "quantity", "name", "drinktypeid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_drink_drinktypeid",
                table: "drink",
                column: "drinktypeid");

            migrationBuilder.CreateIndex(
                name: "IX_drink_club_clubid",
                table: "drink_club",
                column: "clubid");

            migrationBuilder.CreateIndex(
                name: "drinkType_name_key",
                table: "drinkType",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_event_clubid",
                table: "event",
                column: "clubid");

            migrationBuilder.CreateIndex(
                name: "IX_order_reservationid",
                table: "order",
                column: "reservationid");

            migrationBuilder.CreateIndex(
                name: "order_tableid_reservationid_time_key",
                table: "order",
                columns: new[] { "tableid", "reservationid", "time" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_drink_drinkid",
                table: "order_drink",
                column: "drinkid");

            migrationBuilder.CreateIndex(
                name: "package_name_key",
                table: "package",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_package_drink_drinkid",
                table: "package_drink",
                column: "drinkid");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_userid",
                table: "reservation",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "reservation_tableid_userid_reservationdate_key",
                table: "reservation",
                columns: new[] { "tableid", "userid", "reservationdate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_review_userid",
                table: "review",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "review_clubid_userid_date_key",
                table: "review",
                columns: new[] { "clubid", "userid", "date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "role_name_key",
                table: "role",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_role_user_roleid",
                table: "role_user",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "IX_table_clubid",
                table: "table",
                column: "clubid");

            migrationBuilder.CreateIndex(
                name: "IX_table_tabletypeid",
                table: "table",
                column: "tabletypeid");

            migrationBuilder.CreateIndex(
                name: "table_number_clubid_key",
                table: "table",
                columns: new[] { "number", "clubid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "tableType_name_key",
                table: "tableType",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "user",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "user_email_key",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "user",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "userattribues_userid_key",
                table: "userattribues",
                column: "userid",
                unique: true);
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
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "drink_club");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "order_drink");

            migrationBuilder.DropTable(
                name: "package_drink");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "role_user");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "drink");

            migrationBuilder.DropTable(
                name: "package");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "userattribues");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "drinkType");

            migrationBuilder.DropTable(
                name: "table");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "club");

            migrationBuilder.DropTable(
                name: "tableType");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
