using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bknsystem.privateApi.Migrations
{
    public partial class AddedAllMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address_guest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    longitude = table.Column<int>(nullable: false),
                    latitude = table.Column<int>(nullable: false),
                    area = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    guest_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address_guest", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "amenity_guest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wifi = table.Column<bool>(nullable: false),
                    fitness_center = table.Column<bool>(nullable: false),
                    cafeteria = table.Column<bool>(nullable: false),
                    restaurant = table.Column<bool>(nullable: false),
                    bathrobes = table.Column<bool>(nullable: false),
                    dry_cleaning = table.Column<bool>(nullable: false),
                    high_chair = table.Column<bool>(nullable: false),
                    slipper = table.Column<bool>(nullable: false),
                    wakeup_call = table.Column<bool>(nullable: false),
                    telephone = table.Column<bool>(nullable: false),
                    air_conditioning = table.Column<bool>(nullable: false),
                    parking = table.Column<bool>(nullable: false),
                    guest_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amenity_guest", x => x.id);
                });

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
                    AccessFailedCount = table.Column<int>(nullable: false),
                    birth_date = table.Column<DateTime>(nullable: false),
                    last_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "booking_payment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_method = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    payment_amount = table.Column<decimal>(nullable: false),
                    payment_reference = table.Column<string>(nullable: true),
                    payment_date = table.Column<DateTime>(nullable: true),
                    payment_made_by = table.Column<string>(nullable: true),
                    payment_status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking_payment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "check_in_check_out",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    check_in_from = table.Column<DateTime>(nullable: true),
                    check_out_until = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_check_in_check_out", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dated = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    SerialCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    EventType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "extras",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    created_by = table.Column<string>(nullable: true),
                    created_on = table.Column<DateTime>(nullable: true),
                    hotel_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_extras", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hotel_amenity",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wifi = table.Column<bool>(nullable: false),
                    fitness_center = table.Column<bool>(nullable: false),
                    cafeteria = table.Column<bool>(nullable: false),
                    restaurant = table.Column<bool>(nullable: false),
                    bathrobes = table.Column<bool>(nullable: false),
                    dry_cleaning = table.Column<bool>(nullable: false),
                    high_chair = table.Column<bool>(nullable: false),
                    slipper = table.Column<bool>(nullable: false),
                    wakeup_call = table.Column<bool>(nullable: false),
                    telephone = table.Column<bool>(nullable: false),
                    air_conditioning = table.Column<bool>(nullable: false),
                    parking = table.Column<bool>(nullable: false),
                    hotel_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel_amenity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "property_detail",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number_of_floors = table.Column<string>(nullable: true),
                    number_of_rooms = table.Column<string>(nullable: true),
                    most_recent_renovation = table.Column<string>(nullable: true),
                    hotel_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_property_detail", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "room_amenity",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wifi = table.Column<bool>(nullable: false),
                    fitness_center = table.Column<bool>(nullable: false),
                    cafeteria = table.Column<bool>(nullable: false),
                    restaurant = table.Column<bool>(nullable: false),
                    bathrobes = table.Column<bool>(nullable: false),
                    dry_cleaning = table.Column<bool>(nullable: false),
                    high_chair = table.Column<bool>(nullable: false),
                    slipper = table.Column<bool>(nullable: false),
                    wakeup_call = table.Column<bool>(nullable: false),
                    telephone = table.Column<bool>(nullable: false),
                    air_conditioning = table.Column<bool>(nullable: false),
                    parking = table.Column<bool>(nullable: false),
                    room_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_amenity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "room_guest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_type = table.Column<string>(nullable: true),
                    bath_Rooms = table.Column<int>(nullable: false),
                    room_beds = table.Column<int>(nullable: false),
                    guest_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_guest", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "system_exceptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorType = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_system_exceptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorType = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEventLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    LoggedInTime = table.Column<DateTime>(nullable: false),
                    LoggedInStatus = table.Column<string>(nullable: true),
                    UserCountry = table.Column<string>(nullable: true),
                    UserAgent = table.Column<string>(nullable: true),
                    UserBranch = table.Column<string>(nullable: true),
                    UserIpAddress = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEventLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "hotel_booking",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    special_requirements = table.Column<string>(nullable: true),
                    hotel_id = table.Column<string>(nullable: true),
                    room_id = table.Column<string>(nullable: true),
                    booking_status = table.Column<string>(nullable: true),
                    booking_paymentid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel_booking", x => x.id);
                    table.ForeignKey(
                        name: "FK_hotel_booking_booking_payment_booking_paymentid",
                        column: x => x.booking_paymentid,
                        principalTable: "booking_payment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "guest_house",
                columns: table => new
                {
                    _id = table.Column<string>(nullable: false),
                    guest_name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    stars = table.Column<string>(nullable: true),
                    image_url = table.Column<string>(nullable: true),
                    addressid = table.Column<int>(nullable: true),
                    roomsid = table.Column<int>(nullable: true),
                    amenitiesid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guest_house", x => x._id);
                    table.ForeignKey(
                        name: "FK_guest_house_address_guest_addressid",
                        column: x => x.addressid,
                        principalTable: "address_guest",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_guest_house_amenity_guest_amenitiesid",
                        column: x => x.amenitiesid,
                        principalTable: "amenity_guest",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_guest_house_room_guest_roomsid",
                        column: x => x.roomsid,
                        principalTable: "room_guest",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "file_gueset",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_url = table.Column<string>(nullable: true),
                    guest_id = table.Column<string>(nullable: true),
                    guestHouse_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_file_gueset", x => x.id);
                    table.ForeignKey(
                        name: "FK_file_gueset_guest_house_guestHouse_id",
                        column: x => x.guestHouse_id,
                        principalTable: "guest_house",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "guest_rules",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rule_name = table.Column<string>(nullable: true),
                    allow = table.Column<bool>(nullable: false),
                    guestHouse_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guest_rules", x => x.id);
                    table.ForeignKey(
                        name: "FK_guest_rules_guest_house_guestHouse_id",
                        column: x => x.guestHouse_id,
                        principalTable: "guest_house",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rating_guest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rate = table.Column<int>(nullable: false),
                    guest_id = table.Column<string>(nullable: true),
                    guestHouse_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating_guest", x => x.id);
                    table.ForeignKey(
                        name: "FK_rating_guest_guest_house_guestHouse_id",
                        column: x => x.guestHouse_id,
                        principalTable: "guest_house",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "review_guest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    review = table.Column<string>(nullable: true),
                    guest_id = table.Column<string>(nullable: true),
                    guestHouse_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review_guest", x => x.id);
                    table.ForeignKey(
                        name: "FK_review_guest_guest_house_guestHouse_id",
                        column: x => x.guestHouse_id,
                        principalTable: "guest_house",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hotel",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    hotel_name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    stars = table.Column<decimal>(nullable: false),
                    image_url = table.Column<string>(nullable: true),
                    addressid = table.Column<int>(nullable: true),
                    amenitiesid = table.Column<int>(nullable: true),
                    property_detailid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel", x => x.id);
                    table.ForeignKey(
                        name: "FK_hotel_hotel_amenity_amenitiesid",
                        column: x => x.amenitiesid,
                        principalTable: "hotel_amenity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_hotel_property_detail_property_detailid",
                        column: x => x.property_detailid,
                        principalTable: "property_detail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    longitude = table.Column<double>(nullable: false),
                    latitude = table.Column<double>(nullable: false),
                    area = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    hotel_id = table.Column<string>(nullable: true),
                    hotelid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_hotel_hotelid",
                        column: x => x.hotelid,
                        principalTable: "hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "getting_around",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    hotel_id = table.Column<string>(nullable: true),
                    hotelid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_getting_around", x => x.id);
                    table.ForeignKey(
                        name: "FK_getting_around_hotel_hotelid",
                        column: x => x.hotelid,
                        principalTable: "hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nearby_place",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    distance = table.Column<decimal>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: true),
                    created_by = table.Column<string>(nullable: true),
                    hotel_id = table.Column<string>(nullable: true),
                    hotelid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nearby_place", x => x.id);
                    table.ForeignKey(
                        name: "FK_nearby_place_hotel_hotelid",
                        column: x => x.hotelid,
                        principalTable: "hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nearest_essential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    distance = table.Column<decimal>(nullable: false),
                    created_on = table.Column<DateTime>(nullable: true),
                    created_by = table.Column<string>(nullable: true),
                    hotel_id = table.Column<string>(nullable: true),
                    hotelid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nearest_essential", x => x.id);
                    table.ForeignKey(
                        name: "FK_nearest_essential_hotel_hotelid",
                        column: x => x.hotelid,
                        principalTable: "hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rating",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hotel_id = table.Column<string>(nullable: true),
                    hotelid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rating", x => x.id);
                    table.ForeignKey(
                        name: "FK_rating_hotel_hotelid",
                        column: x => x.hotelid,
                        principalTable: "hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hotel_id = table.Column<string>(nullable: true),
                    hotelid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review", x => x.id);
                    table.ForeignKey(
                        name: "FK_review_hotel_hotelid",
                        column: x => x.hotelid,
                        principalTable: "hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_type = table.Column<string>(nullable: true),
                    room_amenityid = table.Column<int>(nullable: true),
                    room_beds = table.Column<int>(nullable: false),
                    floor_number = table.Column<int>(nullable: false),
                    room_price = table.Column<decimal>(nullable: false),
                    hotel_id = table.Column<string>(nullable: true),
                    hotelid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room", x => x.id);
                    table.ForeignKey(
                        name: "FK_room_hotel_hotelid",
                        column: x => x.hotelid,
                        principalTable: "hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_room_room_amenity_room_amenityid",
                        column: x => x.room_amenityid,
                        principalTable: "room_amenity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nearby_hotel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    addressid = table.Column<int>(nullable: true),
                    hotel_id = table.Column<string>(nullable: true),
                    hotelid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nearby_hotel", x => x.id);
                    table.ForeignKey(
                        name: "FK_nearby_hotel_address_addressid",
                        column: x => x.addressid,
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nearby_hotel_hotel_hotelid",
                        column: x => x.hotelid,
                        principalTable: "hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "house_rule",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    check_in_check_outsid = table.Column<int>(nullable: true),
                    extrasid = table.Column<int>(nullable: true),
                    getting_aroundid = table.Column<int>(nullable: true),
                    property_detailsid = table.Column<int>(nullable: true),
                    hotel_id = table.Column<string>(nullable: true),
                    hotelid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_house_rule", x => x.id);
                    table.ForeignKey(
                        name: "FK_house_rule_check_in_check_out_check_in_check_outsid",
                        column: x => x.check_in_check_outsid,
                        principalTable: "check_in_check_out",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_house_rule_extras_extrasid",
                        column: x => x.extrasid,
                        principalTable: "extras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_house_rule_getting_around_getting_aroundid",
                        column: x => x.getting_aroundid,
                        principalTable: "getting_around",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_house_rule_hotel_hotelid",
                        column: x => x.hotelid,
                        principalTable: "hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_house_rule_property_detail_property_detailsid",
                        column: x => x.property_detailsid,
                        principalTable: "property_detail",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_url = table.Column<string>(nullable: true),
                    hotel_id = table.Column<string>(nullable: true),
                    hotelid = table.Column<string>(nullable: true),
                    roomid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.id);
                    table.ForeignKey(
                        name: "FK_Files_hotel_hotelid",
                        column: x => x.hotelid,
                        principalTable: "hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_room_roomid",
                        column: x => x.roomid,
                        principalTable: "room",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_hotelid",
                table: "address",
                column: "hotelid");

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
                name: "IX_file_gueset_guestHouse_id",
                table: "file_gueset",
                column: "guestHouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_Files_hotelid",
                table: "Files",
                column: "hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_Files_roomid",
                table: "Files",
                column: "roomid");

            migrationBuilder.CreateIndex(
                name: "IX_getting_around_hotelid",
                table: "getting_around",
                column: "hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_guest_house_addressid",
                table: "guest_house",
                column: "addressid");

            migrationBuilder.CreateIndex(
                name: "IX_guest_house_amenitiesid",
                table: "guest_house",
                column: "amenitiesid");

            migrationBuilder.CreateIndex(
                name: "IX_guest_house_roomsid",
                table: "guest_house",
                column: "roomsid");

            migrationBuilder.CreateIndex(
                name: "IX_guest_rules_guestHouse_id",
                table: "guest_rules",
                column: "guestHouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_hotel_addressid",
                table: "hotel",
                column: "addressid");

            migrationBuilder.CreateIndex(
                name: "IX_hotel_amenitiesid",
                table: "hotel",
                column: "amenitiesid");

            migrationBuilder.CreateIndex(
                name: "IX_hotel_property_detailid",
                table: "hotel",
                column: "property_detailid");

            migrationBuilder.CreateIndex(
                name: "IX_hotel_booking_booking_paymentid",
                table: "hotel_booking",
                column: "booking_paymentid");

            migrationBuilder.CreateIndex(
                name: "IX_house_rule_check_in_check_outsid",
                table: "house_rule",
                column: "check_in_check_outsid");

            migrationBuilder.CreateIndex(
                name: "IX_house_rule_extrasid",
                table: "house_rule",
                column: "extrasid");

            migrationBuilder.CreateIndex(
                name: "IX_house_rule_getting_aroundid",
                table: "house_rule",
                column: "getting_aroundid");

            migrationBuilder.CreateIndex(
                name: "IX_house_rule_hotelid",
                table: "house_rule",
                column: "hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_house_rule_property_detailsid",
                table: "house_rule",
                column: "property_detailsid");

            migrationBuilder.CreateIndex(
                name: "IX_nearby_hotel_addressid",
                table: "nearby_hotel",
                column: "addressid");

            migrationBuilder.CreateIndex(
                name: "IX_nearby_hotel_hotelid",
                table: "nearby_hotel",
                column: "hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_nearby_place_hotelid",
                table: "nearby_place",
                column: "hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_nearest_essential_hotelid",
                table: "nearest_essential",
                column: "hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_rating_hotelid",
                table: "rating",
                column: "hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_rating_guest_guestHouse_id",
                table: "rating_guest",
                column: "guestHouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_hotelid",
                table: "review",
                column: "hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_review_guest_guestHouse_id",
                table: "review_guest",
                column: "guestHouse_id");

            migrationBuilder.CreateIndex(
                name: "IX_room_hotelid",
                table: "room",
                column: "hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_room_room_amenityid",
                table: "room",
                column: "room_amenityid");

            migrationBuilder.AddForeignKey(
                name: "FK_hotel_address_addressid",
                table: "hotel",
                column: "addressid",
                principalTable: "address",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_hotel_hotelid",
                table: "address");

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
                name: "EventLogs");

            migrationBuilder.DropTable(
                name: "file_gueset");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "guest_rules");

            migrationBuilder.DropTable(
                name: "hotel_booking");

            migrationBuilder.DropTable(
                name: "house_rule");

            migrationBuilder.DropTable(
                name: "nearby_hotel");

            migrationBuilder.DropTable(
                name: "nearby_place");

            migrationBuilder.DropTable(
                name: "nearest_essential");

            migrationBuilder.DropTable(
                name: "rating");

            migrationBuilder.DropTable(
                name: "rating_guest");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "review_guest");

            migrationBuilder.DropTable(
                name: "system_exceptions");

            migrationBuilder.DropTable(
                name: "SystemLogs");

            migrationBuilder.DropTable(
                name: "UserEventLogs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "room");

            migrationBuilder.DropTable(
                name: "booking_payment");

            migrationBuilder.DropTable(
                name: "check_in_check_out");

            migrationBuilder.DropTable(
                name: "extras");

            migrationBuilder.DropTable(
                name: "getting_around");

            migrationBuilder.DropTable(
                name: "guest_house");

            migrationBuilder.DropTable(
                name: "room_amenity");

            migrationBuilder.DropTable(
                name: "address_guest");

            migrationBuilder.DropTable(
                name: "amenity_guest");

            migrationBuilder.DropTable(
                name: "room_guest");

            migrationBuilder.DropTable(
                name: "hotel");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "hotel_amenity");

            migrationBuilder.DropTable(
                name: "property_detail");
        }
    }
}
