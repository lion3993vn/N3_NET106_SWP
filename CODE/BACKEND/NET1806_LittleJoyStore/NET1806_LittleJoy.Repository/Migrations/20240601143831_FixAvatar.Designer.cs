﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NET1806_LittleJoy.Repository.Entities;

#nullable disable

namespace NET1806_LittleJoy.Repository.Migrations
{
    [DbContext(typeof(LittleJoyContext))]
    [Migration("20240601143831_FixAvatar")]
    partial class FixAvatar
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Address");

                    b.Property<bool?>("IsMainAddress")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Address__3214EC074F7046C4");

                    b.HasIndex("UserId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.AgeGroupProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AgeRange")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id")
                        .HasName("PK__AgeGroup__3214EC07A8D27E3F");

                    b.ToTable("AgeGroupProduct", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrandDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Brand__3214EC079B39557F");

                    b.ToTable("Brand", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id")
                        .HasName("PK__Category__3214EC07644223FC");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Delivery", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("Status")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("OrderId")
                        .HasName("PK__Delivery__C3905BCFBC21537C");

                    b.ToTable("Delivery", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("date");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Feedback__3214EC07E0A2CFC9");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Feedback", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("AmountDiscount")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Order__3214EC077E9989C3");

                    b.HasIndex("PaymentId");

                    b.HasIndex("UserId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__OrderDet__3214EC07BF4BE7FD");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("OriginName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id")
                        .HasName("PK__Origin__3214EC072BFD6020");

                    b.ToTable("Origin", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Method")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id")
                        .HasName("PK__Payment__3214EC072E9667DA");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.PointMoney", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AmountDiscount")
                        .HasColumnType("int");

                    b.Property<int?>("MinPoints")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__PointMon__3214EC076B2C3B19");

                    b.ToTable("PointMoney", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Banner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Post__3214EC0772DC9C94");

                    b.HasIndex("UserId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgeId")
                        .HasColumnType("int");

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("CateId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("OriginId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("UnsignProductName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Product__3214EC07F9237F13");

                    b.HasIndex("AgeId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CateId");

                    b.HasIndex("OriginId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Refund", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Status")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("OrderId")
                        .HasName("PK__Refund__C3905BCF300B2A7A");

                    b.ToTable("Refund", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Role__3214EC070DE1BF62");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Avatar")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Fullname")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("GoogleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("Points")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UnsignName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__User__3214EC0785EC007A");

                    b.HasIndex("RoleId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Address", b =>
                {
                    b.HasOne("NET1806_LittleJoy.Repository.Entities.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Address__UserId__66603565");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Feedback", b =>
                {
                    b.HasOne("NET1806_LittleJoy.Repository.Entities.Product", "Product")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__Feedback__Produc__6754599E");

                    b.HasOne("NET1806_LittleJoy.Repository.Entities.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Feedback__UserId__68487DD7");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Order", b =>
                {
                    b.HasOne("NET1806_LittleJoy.Repository.Entities.Delivery", "IdNavigation")
                        .WithOne("Order")
                        .HasForeignKey("NET1806_LittleJoy.Repository.Entities.Order", "Id")
                        .IsRequired()
                        .HasConstraintName("FK__Order__Id__693CA210");

                    b.HasOne("NET1806_LittleJoy.Repository.Entities.Payment", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("FK__Order__PaymentId__6A30C649");

                    b.HasOne("NET1806_LittleJoy.Repository.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Order__UserId__6B24EA82");

                    b.Navigation("IdNavigation");

                    b.Navigation("Payment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.OrderDetail", b =>
                {
                    b.HasOne("NET1806_LittleJoy.Repository.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__OrderDeta__Order__6C190EBB");

                    b.HasOne("NET1806_LittleJoy.Repository.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__OrderDeta__Produ__6D0D32F4");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Post", b =>
                {
                    b.HasOne("NET1806_LittleJoy.Repository.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Post__UserId__6E01572D");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Product", b =>
                {
                    b.HasOne("NET1806_LittleJoy.Repository.Entities.AgeGroupProduct", "Age")
                        .WithMany("Products")
                        .HasForeignKey("AgeId")
                        .HasConstraintName("FK__Product__AgeId__6EF57B66");

                    b.HasOne("NET1806_LittleJoy.Repository.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK__Product__BrandId__6FE99F9F");

                    b.HasOne("NET1806_LittleJoy.Repository.Entities.Category", "Cate")
                        .WithMany("Products")
                        .HasForeignKey("CateId")
                        .HasConstraintName("FK__Product__CateId__70DDC3D8");

                    b.HasOne("NET1806_LittleJoy.Repository.Entities.Origin", "Origin")
                        .WithMany("Products")
                        .HasForeignKey("OriginId")
                        .HasConstraintName("FK__Product__OriginI__71D1E811");

                    b.Navigation("Age");

                    b.Navigation("Brand");

                    b.Navigation("Cate");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Refund", b =>
                {
                    b.HasOne("NET1806_LittleJoy.Repository.Entities.Order", "Order")
                        .WithOne("Refund")
                        .HasForeignKey("NET1806_LittleJoy.Repository.Entities.Refund", "OrderId")
                        .IsRequired()
                        .HasConstraintName("FK__Refund__OrderId__72C60C4A");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.User", b =>
                {
                    b.HasOne("NET1806_LittleJoy.Repository.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__User__RoleId__73BA3083");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.AgeGroupProduct", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Delivery", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("Refund");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Origin", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Payment", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Product", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("NET1806_LittleJoy.Repository.Entities.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Feedbacks");

                    b.Navigation("Orders");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
