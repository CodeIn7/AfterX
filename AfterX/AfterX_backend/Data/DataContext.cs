using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AfterX
{
    public partial class DataContext :
        IdentityDbContext<User, Role, int, IdentityUserClaim<int>, RoleUser, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>

    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<DrinkClub> DrinkClubs { get; set; }
        public virtual DbSet<DrinkType> DrinkTypes { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDrink> OrderDrinks { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<PackageDrink> PackageDrinks { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleUser> RoleUsers { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<TableType> TableTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Userattribue> Userattribues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=dbafterx2021.postgres.database.azure.com;Database=AfterX;Username=afterx2021@dbafterx2021;Password=$#SAy8k8Q=CU%Be,;SSL Mode=Require;Trust Server Certificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.HasPostgresExtension("pg_buffercache")
            //    .HasPostgresExtension("pg_stat_statements")
            //    .HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasIndex(e => new { e.Cityid, e.Street, e.Number }, "address_cityid_street_number_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cityid).HasColumnName("cityid");

                entity.Property(e => e.Number)
                    .HasColumnType("character varying")
                    .HasColumnName("number");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("street");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.Cityid)
                    .HasConstraintName("address_cityid_fkey");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => new { e.Countryid, e.Name }, "city_countryid_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Zip).HasColumnName("zip");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("city_countryid_fkey");
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("club");

                entity.HasIndex(e => new { e.Name, e.Addressid }, "club_name_addressid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Addressid).HasColumnName("addressid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.Addressid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("club_addressid_fkey");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.HasIndex(e => e.Name, "country_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Drink>(entity =>
            {
                entity.ToTable("drink");

                entity.HasIndex(e => new { e.Quantity, e.Name, e.Drinktypeid }, "drink_quantity_name_drinktypeid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Drinktypeid).HasColumnName("drinktypeid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Drinktype)
                    .WithMany(p => p.Drinks)
                    .HasForeignKey(d => d.Drinktypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("drink_drinktypeid_fkey");
            });

            modelBuilder.Entity<DrinkClub>(entity =>
            {
                entity.HasKey(e => new { e.Drinkid, e.Clubid })
                    .HasName("drink_club_pkey");

                entity.ToTable("drink_club");

                entity.Property(e => e.Drinkid).HasColumnName("drinkid");

                entity.Property(e => e.Clubid).HasColumnName("clubid");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.DrinkClubs)
                    .HasForeignKey(d => d.Clubid)
                    .HasConstraintName("drink_club_clubid_fkey");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.DrinkClubs)
                    .HasForeignKey(d => d.Drinkid)
                    .HasConstraintName("drink_club_drinkid_fkey");
            });

            modelBuilder.Entity<DrinkType>(entity =>
            {
                entity.ToTable("drinkType");

                entity.HasIndex(e => e.Name, "drinkType_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Clubid).HasColumnName("clubid");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("_date");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.Clubid)
                    .HasConstraintName("event_clubid_fkey");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => new { e.Tableid, e.Reservationid, e.Time }, "order_tableid_reservationid_time_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Note)
                    .HasColumnType("character varying")
                    .HasColumnName("_note");

                entity.Property(e => e.Reservationid).HasColumnName("reservationid");

                entity.Property(e => e.Tableid).HasColumnName("tableid");

                entity.Property(e => e.Time)
                    .HasColumnType("time without time zone")
                    .HasColumnName("time");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Reservationid)
                    .HasConstraintName("order_reservationid_fkey");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Tableid)
                    .HasConstraintName("order_tableid_fkey");
            });

            modelBuilder.Entity<OrderDrink>(entity =>
            {
                entity.HasKey(e => new { e.Orderid, e.Drinkid })
                    .HasName("order_drink_pkey");

                entity.ToTable("order_drink");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Drinkid).HasColumnName("drinkid");

                entity.Property(e => e.Nobottles).HasColumnName("nobottles");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.OrderDrinks)
                    .HasForeignKey(d => d.Drinkid)
                    .HasConstraintName("order_drink_drinkid_fkey");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDrinks)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("order_drink_orderid_fkey");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("package");

                entity.HasIndex(e => e.Name, "package_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<PackageDrink>(entity =>
            {
                entity.HasKey(e => new { e.Packageid, e.Drinkid })
                    .HasName("package_drink_pkey");

                entity.ToTable("package_drink");

                entity.Property(e => e.Packageid).HasColumnName("packageid");

                entity.Property(e => e.Drinkid).HasColumnName("drinkid");

                entity.Property(e => e.Nobottles).HasColumnName("nobottles");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.PackageDrinks)
                    .HasForeignKey(d => d.Drinkid)
                    .HasConstraintName("package_drink_drinkid_fkey");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageDrinks)
                    .HasForeignKey(d => d.Packageid)
                    .HasConstraintName("package_drink_packageid_fkey");
            });


            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservation");

                entity.HasIndex(e => new { e.Tableid, e.Userid, e.Reservationdate }, "reservation_tableid_userid_reservationdate_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Numberofpeople).HasColumnName("numberofpeople");

                entity.Property(e => e.Reservationdate)
                    .HasColumnType("date")
                    .HasColumnName("reservationdate");

                entity.Property(e => e.Tableid).HasColumnName("tableid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Tableid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reservation_tableid_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("reservation_userid_fkey");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("review");

                entity.HasIndex(e => new { e.Clubid, e.Userid, e.Date }, "review_clubid_userid_date_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clubid).HasColumnName("clubid");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Desciption)
                    .HasColumnType("character varying")
                    .HasColumnName("desciption");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Clubid)
                    .HasConstraintName("review_clubid_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("review_userid_fkey");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasIndex(e => e.Name, "role_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RoleUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("role_user_pkey");

                entity.ToTable("role_user");

                entity.Property(e => e.UserId).HasColumnName("userid");

                entity.Property(e => e.RoleId).HasColumnName("roleid");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("role_user_roleid_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RoleUsers)
                    .HasPrincipalKey(p => p.Userid)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("role_user_userid_fkey");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("table");

                entity.HasIndex(e => new { e.Number, e.Clubid }, "table_number_clubid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Clubid).HasColumnName("clubid");

                entity.Property(e => e.Minnobottles).HasColumnName("minnobottles");

                entity.Property(e => e.Number)
                    .ValueGeneratedNever()
                    //.ValueGeneratedOnAdd()
                    .HasColumnName("number");

                entity.Property(e => e.Tabletypeid).HasColumnName("tabletypeid");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.Clubid)
                    .HasConstraintName("table_clubid_fkey");

                entity.HasOne(d => d.Tabletype)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.Tabletypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("table_tabletypeid_fkey");
            });

            modelBuilder.Entity<TableType>(entity =>
            {
                entity.ToTable("tableType");

                entity.HasIndex(e => e.Name, "tableType_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email, "user_email_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                //entity.Property(e => e.Password)
                //    .IsRequired()
                //    .HasColumnType("character varying")
                //    .HasColumnName("password");
            });

            modelBuilder.Entity<Userattribue>(entity =>
            {
                entity.ToTable("userattribues");

                entity.HasIndex(e => e.Userid, "userattribues_userid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("firstname");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .HasColumnName("gender");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("lastname");

                entity.Property(e => e.Telephone)
                    .HasColumnType("character varying")
                    .HasColumnName("telephone");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Yearofbirth)
                    .HasColumnType("date")
                    .HasColumnName("yearofbirth");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Userattribue)
                    .HasForeignKey<Userattribue>(d => d.Userid)
                    .HasConstraintName("userattribues_userid_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
