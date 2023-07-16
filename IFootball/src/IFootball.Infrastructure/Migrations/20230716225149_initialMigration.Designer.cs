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
    [Migration("20230716225149_initialMigration")]
    partial class initialMigration
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
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("name");

                    b.Property<int>("PenaltySaves")
                        .HasColumnType("INT")
                        .HasColumnName("penalty_saves");

                    b.Property<int>("RedCard")
                        .HasColumnType("INT")
                        .HasColumnName("red_card");

                    b.Property<int>("Saves")
                        .HasColumnType("INT")
                        .HasColumnName("saves");

                    b.Property<int>("TakenGols")
                        .HasColumnType("INT")
                        .HasColumnName("taken_gols");

                    b.Property<int>("Wins")
                        .HasColumnType("INT")
                        .HasColumnName("wins");

                    b.Property<int>("YellowCard")
                        .HasColumnType("INT")
                        .HasColumnName("yellow_card");

                    b.HasKey("Id");

                    b.HasIndex("IdGender");

                    b.HasIndex("IdTeamClass");

                    b.ToTable("goalkeeper", (string)null);
                });

            modelBuilder.Entity("IFootball.Domain.Models.LinePlayer", b =>
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
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("name");

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

                    b.ToTable("line_player", (string)null);
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

                    b.Property<long?>("IdCaptain")
                        .HasColumnType("INT")
                        .HasColumnName("id_captain");

                    b.Property<long>("IdGender")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdGoalkeeper")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdLinePlayerBackLeft")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdLinePlayerBackRight")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdLinePlayerFront")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdLinePlayerMiddle")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("IdReservePlayerOne")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("IdReservePlayerTwo")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdGender");

                    b.HasIndex("IdGoalkeeper");

                    b.HasIndex("IdLinePlayerBackLeft");

                    b.HasIndex("IdLinePlayerBackRight");

                    b.HasIndex("IdLinePlayerFront");

                    b.HasIndex("IdLinePlayerMiddle");

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
                    b.HasOne("IFootball.Domain.Models.Gender", "Gender")
                        .WithMany("GenderGoalkeepers")
                        .HasForeignKey("IdGender")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_gender_goalkepper");

                    b.HasOne("IFootball.Domain.Models.TeamClass", "TeamClass")
                        .WithMany("TeamClassGoalkeepers")
                        .HasForeignKey("IdTeamClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_teamclass_goalkeeper");

                    b.Navigation("Gender");

                    b.Navigation("TeamClass");
                });

            modelBuilder.Entity("IFootball.Domain.Models.LinePlayer", b =>
                {
                    b.HasOne("IFootball.Domain.Models.Gender", "Gender")
                        .WithMany("GenderLinePlayers")
                        .HasForeignKey("IdGender")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_gender_lineplayer");

                    b.HasOne("IFootball.Domain.Models.TeamClass", "TeamClass")
                        .WithMany("TeamClassLinePlayers")
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

                    b.HasOne("IFootball.Domain.Models.Goalkeeper", "Goalkeeper")
                        .WithMany("TeamUsers")
                        .HasForeignKey("IdGoalkeeper")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_goalkeeper_teamuser");

                    b.HasOne("IFootball.Domain.Models.LinePlayer", "LinePlayerBackLeft")
                        .WithMany("TeamUsersBackLeft")
                        .HasForeignKey("IdLinePlayerBackLeft")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_lineplayerbackleft_teamuser");

                    b.HasOne("IFootball.Domain.Models.LinePlayer", "LinePlayerBackRight")
                        .WithMany("TeamUsersBackRight")
                        .HasForeignKey("IdLinePlayerBackRight")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_lineplayerbackright_teamuser");

                    b.HasOne("IFootball.Domain.Models.LinePlayer", "LinePlayerFront")
                        .WithMany("TeamUsersFront")
                        .HasForeignKey("IdLinePlayerFront")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_lineplayerfront_teamuser");

                    b.HasOne("IFootball.Domain.Models.LinePlayer", "LinePlayerMiddle")
                        .WithMany("TeamUsersMiddle")
                        .HasForeignKey("IdLinePlayerMiddle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_lineplayermiddle_teamuser");

                    b.HasOne("IFootball.Domain.Models.LinePlayer", "ReservePlayerOne")
                        .WithMany("TeamUsersReserveOne")
                        .HasForeignKey("IdReservePlayerOne")
                        .HasConstraintName("FK_reserveplayerone_teamuser");

                    b.HasOne("IFootball.Domain.Models.LinePlayer", "ReservePlayerTwo")
                        .WithMany("TeamUsersReserveTwo")
                        .HasForeignKey("IdReservePlayerTwo")
                        .HasConstraintName("FK_reserveplayertwo_teamuser");

                    b.HasOne("IFootball.Domain.Models.User", "User")
                        .WithMany("UserTeamsUser")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_user_teamuser");

                    b.Navigation("Gender");

                    b.Navigation("Goalkeeper");

                    b.Navigation("LinePlayerBackLeft");

                    b.Navigation("LinePlayerBackRight");

                    b.Navigation("LinePlayerFront");

                    b.Navigation("LinePlayerMiddle");

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
                    b.Navigation("GenderGoalkeepers");

                    b.Navigation("GenderLinePlayers");

                    b.Navigation("GenderTeamClasses");

                    b.Navigation("GenderTeamUsers");
                });

            modelBuilder.Entity("IFootball.Domain.Models.Goalkeeper", b =>
                {
                    b.Navigation("TeamUsers");
                });

            modelBuilder.Entity("IFootball.Domain.Models.LinePlayer", b =>
                {
                    b.Navigation("TeamUsersBackLeft");

                    b.Navigation("TeamUsersBackRight");

                    b.Navigation("TeamUsersFront");

                    b.Navigation("TeamUsersMiddle");

                    b.Navigation("TeamUsersReserveOne");

                    b.Navigation("TeamUsersReserveTwo");
                });

            modelBuilder.Entity("IFootball.Domain.Models.TeamClass", b =>
                {
                    b.Navigation("TeamClassGoalkeepers");

                    b.Navigation("TeamClassLinePlayers");
                });

            modelBuilder.Entity("IFootball.Domain.Models.User", b =>
                {
                    b.Navigation("UserTeamsUser");
                });
#pragma warning restore 612, 618
        }
    }
}
