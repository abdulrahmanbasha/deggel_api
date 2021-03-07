using bknsystem.privateApi.Models.identity;
using bknsystem.privateApi.Models.logs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using bknsystem.privateApi.Models;
using martisoor.privateApi_master.Models;

namespace bknsystem.privateApi.Models
{
    public class Datalayer : IdentityDbContext<Users>
    {
        public Datalayer(DbContextOptions<Datalayer> options) : base(options)
        {

        }


        public virtual DbSet<hotel_booking> hotel_booking { get; set; }
 
        public virtual DbSet<address> address { get; set; }
        public virtual DbSet<extras> extras { get; set; }
        public virtual DbSet<getting_around> getting_around { get; set; }
        public virtual DbSet<hotel> hotel { get; set; }
        public virtual DbSet<house_rule> house_rule { get; set; }
        public virtual DbSet<nearby_hotel> nearby_hotel { get; set; }
        public virtual DbSet<nearby_place> nearby_place { get; set; }
        public virtual DbSet<nearest_essential> nearest_essential { get; set; }
        public virtual DbSet<property_detail> property_detail { get; set; }
        public virtual DbSet<rating> rating { get; set; }
        public virtual DbSet<review> review { get; set; }
        public virtual DbSet<room> room { get; set; }

        public virtual DbSet<system_exceptions> system_exceptions { get; set; }
        public virtual DbSet<file> Files { get; set; }
        // Security and logs section
        public DbSet<EventLogs> EventLogs { get; set; }
        public DbSet<UserEventLogs> UserEventLogs { get; set; }
        // public DbSet<IpAddresses> IpAddresses { get; set; }
        public DbSet<SystemLogs> SystemLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<bknsystem.privateApi.Models.check_in_check_out> check_in_check_out { get; set; }
        public DbSet<bknsystem.privateApi.Models.amenity> hotel_amenity { get; set; }
        public DbSet<bknsystem.privateApi.Models.room_amenity> room_amenity { get; set; }


        public DbSet<bknsystem.privateApi.Models.booking_payment> booking_payment { get; set; }
        public DbSet<guestHouse> guest_house { get; set; }

        public DbSet<GuestRule> guest_rules { get; set; }
        public DbSet<ReviewGuest> review_guest   { get; set; }
        public DbSet<RatingGuest> rating_guest { get; set; }
        public DbSet<AmenityGuest> amenity_guest { get; set; }
        public DbSet<FileGuest> file_gueset { get; set; }
        public DbSet<AddressGuest> address_guest { get; set; }
        public DbSet<RoomGuest> room_guest { get; set; }
        public DbSet<guesthouse_booking> guesthouse_booking { get; set; }
    }
}