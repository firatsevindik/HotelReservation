using System;
using System.Collections.Generic;
using System.Text;
using HotelReservation.Entity;
using HotelReservation.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.DataAccess
{
    public class HotelDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-PFP4HQC\\SQLEXPRESS; Database=HotelDB;Trusted_Connection=true;");
        }

        //public HotelDbContext(DbContextOptions<HotelDbContext> options)
        //    : base(options)
        //{
        //}

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelAddress> HotelAddress { get; set; }
        public DbSet<HotelComment> HotelComment { get; set; }
        public DbSet<HotelContact> HotelContact { get; set; }
        public DbSet<HotelContactType> HotelContactType { get; set; }
        public DbSet<HotelImage> HotelImage { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }
        public DbSet<HotelRoomPrice> HotelRoomPrice { get; set; }
        public DbSet<HotelScore> HotelScore { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HotelAddress>(entity =>
            {
                entity.Property(e => e.AddressText)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LocationLatitude)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LocationLongtitude)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hotel)
                    .WithOne(p => p.HotelAddress)
                    //.HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelAddress_Hotel");
            });

            modelBuilder.Entity<HotelComment>(entity =>
            {
                entity.Property(e => e.Comment)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelComment)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelComment_Hotel");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HotelComment)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_HotelComment_User");
            });

            modelBuilder.Entity<HotelContact>(entity =>
            {
                entity.Property(e => e.ContactValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.HotelContactType)
                    .WithMany(p => p.HotelContact)
                    .HasForeignKey(d => d.HotelContactTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HotelContact_HotelContactType");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelContact)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HotelContact_Hotel");
            });

            modelBuilder.Entity<HotelContactType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HotelImage>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelImage)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelImage_Hotel");
            });

            modelBuilder.Entity<HotelRoom>(entity =>
            {
                entity.Property(e => e.RoomDetail).IsUnicode(false);

                entity.Property(e => e.RoomSummary)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelRoom)
                    .HasForeignKey(d => d.HotelId)
                    .HasConstraintName("FK_HotelRoom_Hotel");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.HotelRoom)
                    .HasForeignKey(d => d.RoomTypeId)
                    .HasConstraintName("FK_HotelRoom_RoomType");
            });

            modelBuilder.Entity<HotelRoomPrice>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.HotelRoom)
                    .WithMany(p => p.HotelRoomPrice)
                    .HasForeignKey(d => d.HotelRoomId)
                    .HasConstraintName("FK_HotelRoomPrice_HotelRoom");
            });

            modelBuilder.Entity<HotelScore>(entity =>
            {
                entity.HasOne(d => d.Hotel)
                    .WithOne(p => p.HotelScore)
                    .HasConstraintName("FK_HotelScore_Hotel");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }

    }
}

