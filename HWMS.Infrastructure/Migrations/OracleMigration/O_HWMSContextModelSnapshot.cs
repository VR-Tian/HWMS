﻿// <auto-generated />
using System;
using HWMS.Infrastructure.Contexts.OracleContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

namespace HWMS.Infrastructure.Migrations.OracleMigration
{
    [DbContext(typeof(O_HWMSContext))]
    partial class O_HWMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HWMS.DoMain.Models.Access.NavigationMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ControllerName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("ParentMenuId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<bool>("Visible")
                        .HasColumnType("NUMBER(1)");

                    b.HasKey("Id");

                    b.ToTable("NavigationMenus");
                });

            modelBuilder.Entity("HWMS.DoMain.Models.Access.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("ParentId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("RoleCode")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("RoleName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HWMS.DoMain.Models.Access.RoleMenuPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("NavigationMenuId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("RoleId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("NavigationMenuId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleMenuPermissions");
                });

            modelBuilder.Entity("HWMS.DoMain.Models.Access.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Passwork")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HWMS.DoMain.Models.Access.UserRoleMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("RoleId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoleMappings");
                });

            modelBuilder.Entity("HWMS.DoMain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("Datetime");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("HWMS.DoMain.Models.Access.RoleMenuPermission", b =>
                {
                    b.HasOne("HWMS.DoMain.Models.Access.NavigationMenu", "NavigationMenu")
                        .WithMany()
                        .HasForeignKey("NavigationMenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HWMS.DoMain.Models.Access.Role", null)
                        .WithMany("RoleMenuPermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NavigationMenu");
                });

            modelBuilder.Entity("HWMS.DoMain.Models.Access.UserRoleMapping", b =>
                {
                    b.HasOne("HWMS.DoMain.Models.Access.User", null)
                        .WithMany("RoleMappings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HWMS.DoMain.Models.Order", b =>
                {
                    b.OwnsOne("HWMS.DoMain.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("NUMBER(10)")
                                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnType("varchar(50)")
                                .HasColumnName("City");

                            b1.Property<string>("County")
                                .HasColumnType("varchar(50)")
                                .HasColumnName("County");

                            b1.Property<string>("Province")
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Province");

                            b1.Property<string>("Street")
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Street");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("HWMS.DoMain.Models.Access.Role", b =>
                {
                    b.Navigation("RoleMenuPermissions");
                });

            modelBuilder.Entity("HWMS.DoMain.Models.Access.User", b =>
                {
                    b.Navigation("RoleMappings");
                });
#pragma warning restore 612, 618
        }
    }
}
