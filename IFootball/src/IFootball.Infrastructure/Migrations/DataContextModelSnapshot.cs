﻿// <auto-generated />
using IFootball.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IFootball.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("IFootball.Domain.Models.Coach", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdClass")
                        .HasColumnType("INTEGER");

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

                    b.HasKey("Id");

                    b.HasIndex("IdClass");

                    b.HasIndex("IdGender");

                    b.HasIndex("IdTeamClass")
                        .IsUnique();

                    b.ToTable("coche", (string)null);
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

                    b.Property<long>("IdClass")
                        .HasColumnType("INTEGER");

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

                    b.HasIndex("IdClass");

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

                    b.Property<long>("IdClass")
                        .HasColumnType("INTEGER");

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

                    b.HasIndex("IdClass");

                    b.HasIndex("IdGender");

                    b.HasIndex("IdTeamClass");

                    b.ToTable("line_player", (string)null);
                });

            modelBuilder.Entity("IFootball.Domain.Models.TeamClass", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdGender")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdGender");

                    b.ToTable("team_class", (string)null);
                });

            modelBuilder.Entity("IFootball.Domain.Models.TeamUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdCoach")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdGender")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdGoalkeeper")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdLinePlayerBackLeft")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdLinePlayerBackRight")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdLinePlayerFrontLeft")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdLinePlayerFrontRight")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdCoach");

                    b.HasIndex("IdGender");

                    b.HasIndex("IdGoalkeeper");

                    b.HasIndex("IdLinePlayerBackLeft");

                    b.HasIndex("IdLinePlayerBackRight");

                    b.HasIndex("IdLinePlayerFrontLeft");

                    b.HasIndex("IdLinePlayerFrontRight");

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
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("IdClass");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("IFootball.Domain.Models.Coach", b =>
                {
                    b.HasOne("IFootball.Domain.Models.Class", "Class")
                        .WithMany("ClassCoches")
                        .HasForeignKey("IdClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_class_coach");

                    b.HasOne("IFootball.Domain.Models.Gender", "Gender")
                        .WithMany("GenderCoaches")
                        .HasForeignKey("IdGender")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_gender_coach");

                    b.HasOne("IFootball.Domain.Models.TeamClass", "TeamClass")
                        .WithOne("TeamClassCoach")
                        .HasForeignKey("IFootball.Domain.Models.Coach", "IdTeamClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_teamclass_coach");

                    b.Navigation("Class");

                    b.Navigation("Gender");

                    b.Navigation("TeamClass");
                });

            modelBuilder.Entity("IFootball.Domain.Models.Goalkeeper", b =>
                {
                    b.HasOne("IFootball.Domain.Models.Class", "Class")
                        .WithMany("ClassGoalkeepers")
                        .HasForeignKey("IdClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_class_goalkeeper");

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

                    b.Navigation("Class");

                    b.Navigation("Gender");

                    b.Navigation("TeamClass");
                });

            modelBuilder.Entity("IFootball.Domain.Models.LinePlayer", b =>
                {
                    b.HasOne("IFootball.Domain.Models.Class", "Class")
                        .WithMany("ClassLinePlayer")
                        .HasForeignKey("IdClass")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_class_lineplayer");

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

                    b.Navigation("Class");

                    b.Navigation("Gender");

                    b.Navigation("TeamClass");
                });

            modelBuilder.Entity("IFootball.Domain.Models.TeamClass", b =>
                {
                    b.HasOne("IFootball.Domain.Models.Gender", "Gender")
                        .WithMany("GenderTeamClasses")
                        .HasForeignKey("IdGender")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_gender_teamclass");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("IFootball.Domain.Models.TeamUser", b =>
                {
                    b.HasOne("IFootball.Domain.Models.Coach", "Coach")
                        .WithMany("TeamUsers")
                        .HasForeignKey("IdCoach")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_coach_teamuser");

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

                    b.HasOne("IFootball.Domain.Models.LinePlayer", "LinePlayerFrontLeft")
                        .WithMany("TeamUsersFrontLeft")
                        .HasForeignKey("IdLinePlayerFrontLeft")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_lineplayerfrontleft_teamuser");

                    b.HasOne("IFootball.Domain.Models.LinePlayer", "LinePlayerFrontRight")
                        .WithMany("TeamUsersFrontRight")
                        .HasForeignKey("IdLinePlayerFrontRight")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_lineplayerfrontright_teamuser");

                    b.HasOne("IFootball.Domain.Models.User", "User")
                        .WithMany("UserTeamsUser")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_user_teamuser");

                    b.Navigation("Coach");

                    b.Navigation("Gender");

                    b.Navigation("Goalkeeper");

                    b.Navigation("LinePlayerBackLeft");

                    b.Navigation("LinePlayerBackRight");

                    b.Navigation("LinePlayerFrontLeft");

                    b.Navigation("LinePlayerFrontRight");

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
                    b.Navigation("ClassCoches");

                    b.Navigation("ClassGoalkeepers");

                    b.Navigation("ClassLinePlayer");

                    b.Navigation("ClassUsers");
                });

            modelBuilder.Entity("IFootball.Domain.Models.Coach", b =>
                {
                    b.Navigation("TeamUsers");
                });

            modelBuilder.Entity("IFootball.Domain.Models.Gender", b =>
                {
                    b.Navigation("GenderCoaches");

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

                    b.Navigation("TeamUsersFrontLeft");

                    b.Navigation("TeamUsersFrontRight");
                });

            modelBuilder.Entity("IFootball.Domain.Models.TeamClass", b =>
                {
                    b.Navigation("TeamClassCoach")
                        .IsRequired();

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
