﻿// <auto-generated />
using System;
using EduSchedu.Modules.Schools.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EduSchedu.Modules.Schools.Infrastructure.Database.Migrations
{
    [DbContext(typeof(SchoolsDbContext))]
    partial class SchoolsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("schools")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Schools.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("SchoolId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Classes", "schools");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Schools.LanguageProficiency", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lvl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LanguageProficiencies", "schools");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Schools.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AssignedTeacher")
                        .HasColumnType("uuid")
                        .HasColumnName("AssignedTeacherId");

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.ToTable("Lesson", "schools");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Schools.School", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("HeadmasterId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("Schools", "schools");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Users.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId")
                        .IsUnique();

                    b.ToTable("Schedules", "schools");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Users.SchoolUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SchoolUsers", "schools");

                    b.HasDiscriminator<string>("Role").IsComplete(false);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Users.BackOfficeUser", b =>
                {
                    b.HasBaseType("EduSchedu.Modules.Schools.Domain.Users.SchoolUser");

                    b.HasDiscriminator().HasValue("BackOffice");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Users.Headmaster", b =>
                {
                    b.HasBaseType("EduSchedu.Modules.Schools.Domain.Users.SchoolUser");

                    b.HasDiscriminator().HasValue("HeadMaster");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Users.Teacher", b =>
                {
                    b.HasBaseType("EduSchedu.Modules.Schools.Domain.Users.SchoolUser");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Schools.Class", b =>
                {
                    b.HasOne("EduSchedu.Modules.Schools.Domain.Schools.School", null)
                        .WithMany("Classes")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsMany("EduSchedu.Modules.Schools.Domain.Schools.Ids.LanguageProficiencyId", "LanguageProficiencyIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("ClassId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid")
                                .HasColumnName("LanguageProficiencyId");

                            b1.HasKey("Id");

                            b1.HasIndex("ClassId");

                            b1.ToTable("ClassLanguageProficiencyIds", "schools");

                            b1.WithOwner()
                                .HasForeignKey("ClassId");
                        });

                    b.Navigation("LanguageProficiencyIds");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Schools.Lesson", b =>
                {
                    b.OwnsMany("EduSchedu.Modules.Schools.Domain.Schools.Ids.ClassId", "ClassIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("LessonId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid")
                                .HasColumnName("ClassId");

                            b1.HasKey("Id");

                            b1.HasIndex("LessonId");

                            b1.ToTable("LessonClassIds", "schools");

                            b1.WithOwner()
                                .HasForeignKey("LessonId");
                        });

                    b.Navigation("ClassIds");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Schools.School", b =>
                {
                    b.OwnsOne("EduSchedu.Shared.Abstractions.Kernel.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("SchoolId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("City");

                            b1.Property<string>("MapCoordinates")
                                .HasColumnType("text")
                                .HasColumnName("MapCoordinates");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("ZipCode");

                            b1.HasKey("SchoolId");

                            b1.ToTable("Schools", "schools");

                            b1.WithOwner()
                                .HasForeignKey("SchoolId");
                        });

                    b.OwnsMany("EduSchedu.Shared.Abstractions.Kernel.ValueObjects.UserId", "TeacherIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("SchoolId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid")
                                .HasColumnName("TeacherId");

                            b1.HasKey("Id");

                            b1.HasIndex("SchoolId");

                            b1.ToTable("SchoolTeacherIds", "schools");

                            b1.WithOwner()
                                .HasForeignKey("SchoolId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("TeacherIds");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Users.Schedule", b =>
                {
                    b.HasOne("EduSchedu.Modules.Schools.Domain.Users.Teacher", "Teacher")
                        .WithOne("Schedule")
                        .HasForeignKey("EduSchedu.Modules.Schools.Domain.Users.Schedule", "TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Users.Teacher", b =>
                {
                    b.OwnsMany("EduSchedu.Modules.Schools.Domain.Schools.Ids.LanguageProficiencyId", "LanguageProficiencyIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("TeacherId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid")
                                .HasColumnName("LanguageProficiencyId");

                            b1.HasKey("Id");

                            b1.HasIndex("TeacherId");

                            b1.ToTable("TeacherLanguageProficiencyIds", "schools");

                            b1.WithOwner()
                                .HasForeignKey("TeacherId");
                        });

                    b.Navigation("LanguageProficiencyIds");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Schools.School", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("EduSchedu.Modules.Schools.Domain.Users.Teacher", b =>
                {
                    b.Navigation("Schedule")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
