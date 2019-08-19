﻿// <auto-generated />
using System;
using LInst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LInst.Migrations
{
    [DbContext(typeof(LInstContext))]
    [Migration("20181221093641_calref_idx")]
    partial class calref_idx
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LInst.CalibrationFile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CalibrationReportID");

                    b.Property<string>("Path");

                    b.HasKey("ID");

                    b.HasIndex("CalibrationReportID");

                    b.ToTable("CalibrationFiles");
                });

            modelBuilder.Entity("LInst.CalibrationReport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CalibrationResultID");

                    b.Property<DateTime>("Date");

                    b.Property<int>("InstrumentID");

                    b.Property<int>("LaboratoryID");

                    b.Property<string>("Notes");

                    b.Property<int>("Number");

                    b.Property<int?>("TechID");

                    b.Property<int>("Year");

                    b.HasKey("ID");

                    b.HasIndex("CalibrationResultID");

                    b.HasIndex("InstrumentID");

                    b.HasIndex("LaboratoryID");

                    b.HasIndex("TechID");

                    b.ToTable("CalibrationReports");
                });

            modelBuilder.Entity("LInst.CalibrationReportProperty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CalibrationReportID");

                    b.Property<double>("LowerLimit");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentPropertyID");

                    b.Property<double>("TargetValue");

                    b.Property<string>("UM");

                    b.Property<double>("UpperLimit");

                    b.Property<double>("Value");

                    b.HasKey("ID");

                    b.HasIndex("CalibrationReportID");

                    b.HasIndex("ParentPropertyID");

                    b.ToTable("CalibrationReportProperties");
                });

            modelBuilder.Entity("LInst.CalibrationReportReference", b =>
                {
                    b.Property<int>("CalibrationReportID");

                    b.Property<int>("InstrumentID");

                    b.HasKey("CalibrationReportID", "InstrumentID");

                    b.HasIndex("InstrumentID");

                    b.ToTable("CalibrationReportReferences");
                });

            modelBuilder.Entity("LInst.CalibrationResult", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("CalibrationResults");
                });

            modelBuilder.Entity("LInst.Instrument", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CalibrationDueDate");

                    b.Property<int?>("CalibrationInterval");

                    b.Property<int?>("CalibrationResponsibleID");

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<int>("InstrumentTypeID");

                    b.Property<bool>("IsInService")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<bool>("IsUnderControl")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int?>("ManufacturerID");

                    b.Property<string>("Model");

                    b.Property<string>("SerialNumber");

                    b.Property<int?>("SupplierID");

                    b.Property<int>("UtilizationAreaID");

                    b.HasKey("ID");

                    b.HasIndex("CalibrationResponsibleID");

                    b.HasIndex("Code");

                    b.HasIndex("InstrumentTypeID");

                    b.HasIndex("ManufacturerID");

                    b.HasIndex("SupplierID");

                    b.HasIndex("UtilizationAreaID");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("LInst.InstrumentFile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InstrumentID");

                    b.Property<string>("Path");

                    b.HasKey("ID");

                    b.HasIndex("InstrumentID");

                    b.ToTable("InstrumentFiles");
                });

            modelBuilder.Entity("LInst.InstrumentMaintenanceEvent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("InstrumentID");

                    b.Property<int?>("TechID");

                    b.HasKey("ID");

                    b.HasIndex("InstrumentID");

                    b.HasIndex("TechID");

                    b.ToTable("InstrumentMaintenanceEvents");
                });

            modelBuilder.Entity("LInst.InstrumentProperty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InstrumentID");

                    b.Property<bool>("IsCalibrationProperty")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<double>("LowerLimit");

                    b.Property<string>("Name");

                    b.Property<double>("TargetValue");

                    b.Property<string>("UM");

                    b.Property<double>("UpperLimit");

                    b.Property<double>("Value")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0.0);

                    b.HasKey("ID");

                    b.HasIndex("InstrumentID");

                    b.ToTable("InstrumentProperties");
                });

            modelBuilder.Entity("LInst.InstrumentType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("InstrumentTypes");
                });

            modelBuilder.Entity("LInst.InstrumentUtilizationArea", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Plant");

                    b.HasKey("ID");

                    b.ToTable("InstrumentUtilizationAreas");
                });

            modelBuilder.Entity("LInst.Organization", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("LInst.OrganizationRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("OrganizationRoles");
                });

            modelBuilder.Entity("LInst.OrganizationRoleMapping", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsSelected");

                    b.Property<int>("OrganizationID");

                    b.Property<int>("OrganizationRoleID");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.HasIndex("OrganizationRoleID");

                    b.ToTable("OrganizationRoleMappings");
                });

            modelBuilder.Entity("LInst.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("LInst.PersonRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("PersonRoles");
                });

            modelBuilder.Entity("LInst.PersonRoleMapping", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsSelected");

                    b.Property<int>("PersonID");

                    b.Property<int>("RoleID");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.HasIndex("RoleID");

                    b.ToTable("PersonRoleMappings");
                });

            modelBuilder.Entity("LInst.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FullName");

                    b.Property<string>("HashedPassword");

                    b.Property<int>("PersonID");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LInst.UserRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("LInst.UserRoleMapping", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsSelected");

                    b.Property<int>("UserID");

                    b.Property<int>("UserRoleID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.HasIndex("UserRoleID");

                    b.ToTable("UserRoleMappings");
                });

            modelBuilder.Entity("LInst.CalibrationFile", b =>
                {
                    b.HasOne("LInst.CalibrationReport", "CalibrationReport")
                        .WithMany()
                        .HasForeignKey("CalibrationReportID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LInst.CalibrationReport", b =>
                {
                    b.HasOne("LInst.CalibrationResult", "CalibrationResult")
                        .WithMany()
                        .HasForeignKey("CalibrationResultID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LInst.Instrument", "Instrument")
                        .WithMany("CalibrationReports")
                        .HasForeignKey("InstrumentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LInst.Organization", "Laboratory")
                        .WithMany()
                        .HasForeignKey("LaboratoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LInst.Person", "Tech")
                        .WithMany()
                        .HasForeignKey("TechID");
                });

            modelBuilder.Entity("LInst.CalibrationReportProperty", b =>
                {
                    b.HasOne("LInst.CalibrationReport", "CalibrationReport")
                        .WithMany("CalibrationReportProperties")
                        .HasForeignKey("CalibrationReportID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LInst.InstrumentProperty", "ParentProperty")
                        .WithMany()
                        .HasForeignKey("ParentPropertyID");
                });

            modelBuilder.Entity("LInst.CalibrationReportReference", b =>
                {
                    b.HasOne("LInst.CalibrationReport", "CalibrationReport")
                        .WithMany("CalibrationReportReferences")
                        .HasForeignKey("CalibrationReportID")
                        .HasConstraintName("FK_CalibrationReportReference_CalRep_CalRepID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LInst.Instrument", "Instrument")
                        .WithMany("CalibrationsAsReference")
                        .HasForeignKey("InstrumentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LInst.Instrument", b =>
                {
                    b.HasOne("LInst.Organization", "CalibrationResponsible")
                        .WithMany()
                        .HasForeignKey("CalibrationResponsibleID");

                    b.HasOne("LInst.InstrumentType", "InstrumentType")
                        .WithMany()
                        .HasForeignKey("InstrumentTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LInst.Organization", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerID");

                    b.HasOne("LInst.Organization", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierID");

                    b.HasOne("LInst.InstrumentUtilizationArea", "UtilizationArea")
                        .WithMany()
                        .HasForeignKey("UtilizationAreaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LInst.InstrumentFile", b =>
                {
                    b.HasOne("LInst.Instrument", "Instrument")
                        .WithMany("InstrumentFiles")
                        .HasForeignKey("InstrumentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LInst.InstrumentMaintenanceEvent", b =>
                {
                    b.HasOne("LInst.Instrument", "Instrument")
                        .WithMany("MaintenanceEvents")
                        .HasForeignKey("InstrumentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LInst.Person", "Tech")
                        .WithMany()
                        .HasForeignKey("TechID");
                });

            modelBuilder.Entity("LInst.InstrumentProperty", b =>
                {
                    b.HasOne("LInst.Instrument", "Instrument")
                        .WithMany("InstrumentProperties")
                        .HasForeignKey("InstrumentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LInst.OrganizationRoleMapping", b =>
                {
                    b.HasOne("LInst.Organization", "Organization")
                        .WithMany("RoleMappings")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LInst.OrganizationRole", "OrganizationRole")
                        .WithMany("OrganizationRoleMappings")
                        .HasForeignKey("OrganizationRoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LInst.PersonRoleMapping", b =>
                {
                    b.HasOne("LInst.Person", "Person")
                        .WithMany("RoleMappings")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LInst.PersonRole", "Role")
                        .WithMany("RoleMappings")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LInst.User", b =>
                {
                    b.HasOne("LInst.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LInst.UserRoleMapping", b =>
                {
                    b.HasOne("LInst.User", "User")
                        .WithMany("RoleMappings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LInst.UserRole", "UserRole")
                        .WithMany("UserMappings")
                        .HasForeignKey("UserRoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}