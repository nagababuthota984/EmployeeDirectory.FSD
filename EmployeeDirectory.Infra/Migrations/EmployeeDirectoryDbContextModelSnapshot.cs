﻿// <auto-generated />
using System;
using EmployeeDirectory.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmployeeDirectory.Infra.Migrations
{
    [DbContext(typeof(EmployeeDirectoryDbContext))]
    partial class EmployeeDirectoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EmployeeDirectory.Concerns.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("dept_type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Department");

                    b.HasDiscriminator<string>("dept_type").HasValue("Department");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EmployeeDirectory.Concerns.JobTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("jobtitle_type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("JobTitle");

                    b.HasDiscriminator<string>("jobtitle_type").HasValue("JobTitle");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EmployeeDirectory.Concerns.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("office_type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Office");

                    b.HasDiscriminator<string>("office_type").HasValue("Office");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EmployeeDirectory.Data.DataConcerns.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OfficeId")
                        .HasColumnType("integer");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PreferredName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("JobTitleId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "System",
                            CreatedOn = new DateTime(2023, 10, 29, 6, 17, 13, 339, DateTimeKind.Utc).AddTicks(6849),
                            DepartmentId = 1,
                            Email = "nagababuthota593@gmail.com",
                            FirstName = "Nagababu",
                            IsDeleted = false,
                            JobTitleId = 1,
                            LastName = "Thota",
                            ModifiedBy = "System",
                            ModifiedOn = new DateTime(2023, 10, 29, 6, 17, 13, 339, DateTimeKind.Utc).AddTicks(6850),
                            OfficeId = 1,
                            Phone = "8464832529",
                            PreferredName = "Nagababu Thota",
                            Salary = 59900m
                        });
                });

            modelBuilder.Entity("EmployeeDirectory.Data.DataConcerns.Department", b =>
                {
                    b.HasBaseType("EmployeeDirectory.Concerns.Department");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasDiscriminator().HasValue("dept_data_concern");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Product Engineering",
                            Name = "Product Engineering",
                            CreatedBy = "System",
                            CreatedOn = new DateTime(2023, 10, 29, 6, 17, 13, 339, DateTimeKind.Utc).AddTicks(6797),
                            ModifiedBy = "System",
                            ModifiedOn = new DateTime(2023, 10, 29, 6, 17, 13, 339, DateTimeKind.Utc).AddTicks(6798)
                        });
                });

            modelBuilder.Entity("EmployeeDirectory.Data.DataConcerns.JobTitle", b =>
                {
                    b.HasBaseType("EmployeeDirectory.Concerns.JobTitle");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasDiscriminator().HasValue("jobtitle_data_concern");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Software developer with more than 1 year of experience.",
                            Name = "Software Developer",
                            CreatedBy = "System",
                            CreatedOn = new DateTime(2023, 10, 29, 6, 17, 13, 339, DateTimeKind.Utc).AddTicks(6615),
                            ModifiedBy = "System",
                            ModifiedOn = new DateTime(2023, 10, 29, 6, 17, 13, 339, DateTimeKind.Utc).AddTicks(6619)
                        });
                });

            modelBuilder.Entity("EmployeeDirectory.Data.DataConcerns.Office", b =>
                {
                    b.HasBaseType("EmployeeDirectory.Concerns.Office");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasDiscriminator().HasValue("office_data_concernt");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Tezo digital office. Hyderabad, India.",
                            Location = "India",
                            Name = "India",
                            CreatedBy = "System",
                            CreatedOn = new DateTime(2023, 10, 29, 6, 17, 13, 339, DateTimeKind.Utc).AddTicks(6815),
                            ModifiedBy = "System",
                            ModifiedOn = new DateTime(2023, 10, 29, 6, 17, 13, 339, DateTimeKind.Utc).AddTicks(6816)
                        });
                });

            modelBuilder.Entity("EmployeeDirectory.Data.DataConcerns.Employee", b =>
                {
                    b.HasOne("EmployeeDirectory.Concerns.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeDirectory.Concerns.JobTitle", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeDirectory.Concerns.Office", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("JobTitle");

                    b.Navigation("Office");
                });
#pragma warning restore 612, 618
        }
    }
}
