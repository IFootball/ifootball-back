﻿// <auto-generated />
using System;
using IFootball.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IFootball.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230824181724_imageNullMigration")]
    partial class imageNullMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.18");

            modelBuilder.Entity("IFootball.Domain.Models.Class", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("class", (string)null);
                });

            modelBuilder.Entity("IFootball.Domain.Models.Gender", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Name")
                        .HasColumnType("INT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("gender", (string)null);
                });

            modelBuilder.Entity("IFootball.Domain.Models.Goalkeeper", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdPlayer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PenaltySaves")
                        .HasColumnType("INT")
                        .HasColumnName("penalty_saves");

                    b.Property<int>("Saves")
                        .HasColumnType("INT")
                        .HasColumnName("saves");

                    b.Property<int>("TakenGols")
                        .HasColumnType("INT")
                        .HasColumnName("taken_gols");

                    b.HasKey("Id");

                    b.HasIndex("IdPlayer")
                        .IsUnique();

                    b.ToTable("goalkeeper", (string)null);
                });

            modelBuilder.Entity("IFootball.Domain.Models.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Assists")
                        .HasColumnType("INT")
                        .HasColumnName("assists");

                    b.Property<int>("Fouls")
                        .HasColumnType("INT")
                        .HasColumnName("fouls");

                    b.Property<int>("Goals")
                        .HasColumnType("INT")
                        .HasColumnName("goals");

                    b.Property<long>("IdGender")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdTeamClass")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasMaxLength(512)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("name");

                    b.Property<int>("PlayerType")
                        .HasColumnType("INT")
                        .HasColumnName("player_type");

                    b.Property<int>("RedCard")
                        .HasColumnType("INT")
                        .HasColumnName("red_card");

                    b.Property<int>("Wins")
                        .HasColumnType("INT")
                        .HasColumnName("wins");

                    b.Property<int>("YellowCard")
                        .HasColumnType("INT")
                        .HasColumnName("yellow_card");

                    b.HasKey("Id");

                    b.HasIndex("IdGender");

                    b.HasIndex("IdTeamClass");

                    b.ToTable("player", (string)null);
                });

            modelBuilder.Entity("IFootball.Domain.Models.StartDate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDateOfMatches")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("start_date_of_matches");

                    b.HasKey("Id");

                    b.ToTable("start_date", (string)null);
                });

            modelBuilder.Entity("IFootball.Domain.Models.TeamClass", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdClass")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdGender")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdClass");

                    b.HasIndex("IdGender");

                    b.ToTable("team_class", (string)null);
                });

            modelBuilder.Entity("IFootball.Domain.Models.TeamUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdCaptain")
                        .HasColumnType("INT")
                        .HasColumnName("id_captain");

                    b.Property<long>("IdGender")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdGoalkeeper")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdPlayerFour")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdPlayerOne")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdPlayerThree")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdPlayerTwo")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdReservePlayerOne")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdReservePlayerTwo")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdGender");

                    b.HasIndex("IdGoalkeeper");

                    b.HasIndex("IdPlayerFour");

                    b.HasIndex("IdPlayerOne");

                    b.HasIndex("IdPlayerThree");

                    b.HasIndex("IdPlayerTwo");

                    b.HasIndex("IdReservePlayerOne");

                    b.HasIndex("IdReservePlayerTwo");

                    b.HasIndex("IdUser");

                    b.ToTable("team_user", (string)null);
                });

            modelBuilder.Entity("IFootball.Domain.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("email");

                    b.Property<long>("IdClass")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("password");

                    b.Property<int>("Role")
                        .HasColumnType("INT")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.HasIndex("IdClass");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("IFootball.Domain.Models.Goalkeeper", b =>
                {
                    b.HasOne("IFootball.Domain.Models.Player", "Player")
                        .WithOne("Goalkeeper")
                        .HasForeignKey("IFootball.Domain.Models.Goalkeeper", "IdPlayer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_player_goalkeeper");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("IFootball.Domain.Models.Player", b =>
                {
                    b.HasOne("IFootball.Domain.Models.Gender", "Gender")
                        .WithMany("GenderPlayers")
                        .HasForeignKey("IdGender")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_gender_lineplayer");

                    b.HasOne("IFootball.Domain.Models.TeamClass", "TeamClass")
                        .WithMany("TeamClassPlayers")
                        .HasForeignKey("IdTeamClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_teamclass_lineplayer");

                    b.Navigation("Gender");

                    b.Navigation("TeamClass");
                });

            modelBuilder.Entity("IFootball.Domain.Models.TeamClass", b =>
                {
                    b.HasOne("IFootball.Domain.Models.Class", "Class")
                        .WithMany("TeamClasses")
                        .HasForeignKey("IdClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_class_teamclass");

                    b.HasOne("IFootball.Domain.Models.Gender", "Gender")
                        .WithMany("GenderTeamClasses")
                        .HasForeignKey("IdGender")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_gender_teamclass");

                    b.Navigation("Class");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("IFootball.Domain.Models.TeamUser", b =>
                {
                    b.HasOne("IFootball.Domain.Models.Gender", "Gender")
                        .WithMany("GenderTeamUsers")
                        .HasForeignKey("IdGender")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_gender_teamuser");

                    b.HasOne("IFootball.Domain.Models.Player", "Goalkeeper")
                        .WithMany("TeamUsersGoalkeeper")
                        .HasForeignKey("IdGoalkeeper")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_goalkeeper_teamuser");

                    b.HasOne("IFootball.Domain.Models.Player", "PlayerFour")
                        .WithMany("TeamUsersFour")
                        .HasForeignKey("IdPlayerFour")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_playerFour_teamuser");

                    b.HasOne("IFootball.Domain.Models.Player", "PlayerOne")
                        .WithMany("TeamUsersOne")
                        .HasForeignKey("IdPlayerOne")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_playerOne_teamuser");

                    b.HasOne("IFootball.Domain.Models.Player", "PlayerThree")
                        .WithMany("TeamUsersThree")
                        .HasForeignKey("IdPlayerThree")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_playerThree_teamuser");

                    b.HasOne("IFootball.Domain.Models.Player", "PlayerTwo")
                        .WithMany("TeamUsersTwo")
                        .HasForeignKey("IdPlayerTwo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_playerTwo_teamuser");

                    b.HasOne("IFootball.Domain.Models.Player", "ReservePlayerOne")
                        .WithMany("TeamUsersReserveOne")
                        .HasForeignKey("IdReservePlayerOne")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_reserveplayerone_teamuser");

                    b.HasOne("IFootball.Domain.Models.Player", "ReservePlayerTwo")
                        .WithMany("TeamUsersReserveTwo")
                        .HasForeignKey("IdReservePlayerTwo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_reserveplayertwo_teamuser");

                    b.HasOne("IFootball.Domain.Models.User", "User")
                        .WithMany("UserTeamsUser")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_user_teamuser");

                    b.Navigation("Gender");

                    b.Navigation("Goalkeeper");

                    b.Navigation("PlayerFour");

                    b.Navigation("PlayerOne");

                    b.Navigation("PlayerThree");

                    b.Navigation("PlayerTwo");

                    b.Navigation("ReservePlayerOne");

                    b.Navigation("ReservePlayerTwo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("IFootball.Domain.Models.User", b =>
                {
                    b.HasOne("IFootball.Domain.Models.Class", "Class")
                        .WithMany("ClassUsers")
                        .HasForeignKey("IdClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_class_user");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("IFootball.Domain.Models.Class", b =>
                {
                    b.Navigation("ClassUsers");

                    b.Navigation("TeamClasses");
                });

            modelBuilder.Entity("IFootball.Domain.Models.Gender", b =>
                {
                    b.Navigation("GenderPlayers");

                    b.Navigation("GenderTeamClasses");

                    b.Navigation("GenderTeamUsers");
                });

            modelBuilder.Entity("IFootball.Domain.Models.Player", b =>
                {
                    b.Navigation("Goalkeeper");

                    b.Navigation("TeamUsersFour");

                    b.Navigation("TeamUsersGoalkeeper");

                    b.Navigation("TeamUsersOne");

                    b.Navigation("TeamUsersReserveOne");

                    b.Navigation("TeamUsersReserveTwo");

                    b.Navigation("TeamUsersThree");

                    b.Navigation("TeamUsersTwo");
                });

            modelBuilder.Entity("IFootball.Domain.Models.TeamClass", b =>
                {
                    b.Navigation("TeamClassPlayers");
                });

            modelBuilder.Entity("IFootball.Domain.Models.User", b =>
                {
                    b.Navigation("UserTeamsUser");
                });
#pragma warning restore 612, 618
        }
    }
}
