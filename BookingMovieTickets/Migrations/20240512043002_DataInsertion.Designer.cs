﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesBooking.DataAccess;

#nullable disable

namespace BookingMovieTickets.Migrations
{
    [DbContext(typeof(BookingMovieTicketsDBContext))]
    [Migration("20240512043002_DataInsertion")]
    partial class DataInsertion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookingMovieTickets.Models.Receipt", b =>
                {
                    b.Property<int>("ReceiptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceiptId"));

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReceiptId");

                    b.HasIndex("UserId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("BookingMovieTickets.Models.ReceiptDetail", b =>
                {
                    b.Property<int>("ReceiptDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceiptDetailId"));

                    b.Property<int>("ReceiptId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("ReceiptDetailId");

                    b.HasIndex("ReceiptId");

                    b.HasIndex("TicketId");

                    b.ToTable("ReceiptDetails");
                });

            modelBuilder.Entity("BookingMovieTickets.Models.TicketCart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CartId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("TicketCarts");
                });

            modelBuilder.Entity("BookingMovieTickets.Models.TicketCartDetail", b =>
                {
                    b.Property<int>("CartDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartDetailId"));

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("FilmScheduleId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("CartDetailId");

                    b.HasIndex("CartId");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketCartDetails");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MoviesBooking.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmId"));

                    b.Property<string>("Actors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FilmCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("FilmDuration")
                        .HasColumnType("int");

                    b.Property<string>("FilmRated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameFilm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PremiereTimeId")
                        .HasColumnType("int");

                    b.Property<string>("TrailerUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FilmId");

                    b.HasIndex("FilmCategoryId");

                    b.HasIndex("PremiereTimeId")
                        .IsUnique();

                    b.ToTable("Films");
                });

            modelBuilder.Entity("MoviesBooking.Models.FilmCategory", b =>
                {
                    b.Property<int>("FilmCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmCategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FilmCategoryId");

                    b.ToTable("FilmCategory");
                });

            modelBuilder.Entity("MoviesBooking.Models.FilmSchedule", b =>
                {
                    b.Property<int>("FilmScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FilmScheduleId"));

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("FilmScheduleDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheatreRoomId")
                        .HasColumnType("int");

                    b.HasKey("FilmScheduleId");

                    b.HasIndex("FilmId");

                    b.HasIndex("TheatreRoomId");

                    b.ToTable("FilmSchedules");
                });

            modelBuilder.Entity("MoviesBooking.Models.PremiereTime", b =>
                {
                    b.Property<int>("PremiereTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PremiereTimeId"));

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("PremiereTimeId");

                    b.ToTable("PremiereTimes");
                });

            modelBuilder.Entity("MoviesBooking.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"));

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SeatPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TheatreRoomId")
                        .HasColumnType("int");

                    b.HasKey("SeatId");

                    b.HasIndex("TheatreRoomId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("MoviesBooking.Models.Theatre", b =>
                {
                    b.Property<int>("TheatreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TheatreId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TheatreId");

                    b.ToTable("Theatres");
                });

            modelBuilder.Entity("MoviesBooking.Models.TheatreRoom", b =>
                {
                    b.Property<int>("TheatreRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TheatreRoomId"));

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheatreId")
                        .HasColumnType("int");

                    b.HasKey("TheatreRoomId");

                    b.HasIndex("TheatreId");

                    b.ToTable("TheatreRooms");
                });

            modelBuilder.Entity("MoviesBooking.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("MoviesBooking.Models.TicketDetail", b =>
                {
                    b.Property<int>("TicketDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketDetailId"));

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("FilmScheduleId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("TicketDetailId");

                    b.HasIndex("FilmScheduleId");

                    b.HasIndex("SeatId");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketDetails");
                });

            modelBuilder.Entity("MoviesBooking.Models.UserInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BookingMovieTickets.Models.Receipt", b =>
                {
                    b.HasOne("MoviesBooking.Models.UserInfo", "User")
                        .WithMany("Receipts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingMovieTickets.Models.ReceiptDetail", b =>
                {
                    b.HasOne("BookingMovieTickets.Models.Receipt", "Receipt")
                        .WithMany("ReceiptDetails")
                        .HasForeignKey("ReceiptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesBooking.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receipt");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("BookingMovieTickets.Models.TicketCart", b =>
                {
                    b.HasOne("MoviesBooking.Models.UserInfo", "UserInfo")
                        .WithOne("TicketCart")
                        .HasForeignKey("BookingMovieTickets.Models.TicketCart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("BookingMovieTickets.Models.TicketCartDetail", b =>
                {
                    b.HasOne("BookingMovieTickets.Models.TicketCart", "TicketCart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesBooking.Models.Ticket", "Ticket")
                        .WithMany("TicketCartDetails")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("TicketCart");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MoviesBooking.Models.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MoviesBooking.Models.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesBooking.Models.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MoviesBooking.Models.UserInfo", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesBooking.Models.Film", b =>
                {
                    b.HasOne("MoviesBooking.Models.FilmCategory", "FilmCategory")
                        .WithMany("Film")
                        .HasForeignKey("FilmCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesBooking.Models.PremiereTime", "PremiereTimes")
                        .WithOne("Film")
                        .HasForeignKey("MoviesBooking.Models.Film", "PremiereTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilmCategory");

                    b.Navigation("PremiereTimes");
                });

            modelBuilder.Entity("MoviesBooking.Models.FilmSchedule", b =>
                {
                    b.HasOne("MoviesBooking.Models.Film", "Film")
                        .WithMany("FilmSchedules")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesBooking.Models.TheatreRoom", "TheatreRoom")
                        .WithMany("FilmSchedules")
                        .HasForeignKey("TheatreRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("TheatreRoom");
                });

            modelBuilder.Entity("MoviesBooking.Models.Seat", b =>
                {
                    b.HasOne("MoviesBooking.Models.TheatreRoom", "TheatreRoom")
                        .WithMany("Seats")
                        .HasForeignKey("TheatreRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TheatreRoom");
                });

            modelBuilder.Entity("MoviesBooking.Models.TheatreRoom", b =>
                {
                    b.HasOne("MoviesBooking.Models.Theatre", "Theatre")
                        .WithMany("TheatreRooms")
                        .HasForeignKey("TheatreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theatre");
                });

            modelBuilder.Entity("MoviesBooking.Models.TicketDetail", b =>
                {
                    b.HasOne("MoviesBooking.Models.FilmSchedule", "FilmSchedule")
                        .WithMany("TicketDetails")
                        .HasForeignKey("FilmScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesBooking.Models.Seat", "Seat")
                        .WithMany("TicketDetails")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesBooking.Models.Ticket", "Ticket")
                        .WithMany("TicketDetails")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilmSchedule");

                    b.Navigation("Seat");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("BookingMovieTickets.Models.Receipt", b =>
                {
                    b.Navigation("ReceiptDetails");
                });

            modelBuilder.Entity("MoviesBooking.Models.Film", b =>
                {
                    b.Navigation("FilmSchedules");
                });

            modelBuilder.Entity("MoviesBooking.Models.FilmCategory", b =>
                {
                    b.Navigation("Film");
                });

            modelBuilder.Entity("MoviesBooking.Models.FilmSchedule", b =>
                {
                    b.Navigation("TicketDetails");
                });

            modelBuilder.Entity("MoviesBooking.Models.PremiereTime", b =>
                {
                    b.Navigation("Film")
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesBooking.Models.Seat", b =>
                {
                    b.Navigation("TicketDetails");
                });

            modelBuilder.Entity("MoviesBooking.Models.Theatre", b =>
                {
                    b.Navigation("TheatreRooms");
                });

            modelBuilder.Entity("MoviesBooking.Models.TheatreRoom", b =>
                {
                    b.Navigation("FilmSchedules");

                    b.Navigation("Seats");
                });

            modelBuilder.Entity("MoviesBooking.Models.Ticket", b =>
                {
                    b.Navigation("TicketCartDetails");

                    b.Navigation("TicketDetails");
                });

            modelBuilder.Entity("MoviesBooking.Models.UserInfo", b =>
                {
                    b.Navigation("Receipts");

                    b.Navigation("TicketCart")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}