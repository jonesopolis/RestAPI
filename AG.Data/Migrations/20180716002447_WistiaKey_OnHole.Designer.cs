﻿// <auto-generated />
using AG.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AG.Data.Migrations
{
    [DbContext(typeof(AgContext))]
    [Migration("20180716002447_WistiaKey_OnHole")]
    partial class WistiaKey_OnHole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AG.Data.Model.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LogoUrl")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("AG.Data.Model.CourseAddress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<long>("CourseId");

                    b.Property<string>("State")
                        .HasMaxLength(2);

                    b.Property<string>("Street")
                        .HasMaxLength(100);

                    b.Property<string>("Zip")
                        .HasMaxLength(5);

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("CourseAddresses");
                });

            modelBuilder.Entity("AG.Data.Model.CourseContactInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(100);

                    b.Property<string>("ContactPhone")
                        .HasMaxLength(25);

                    b.Property<long>("CourseId");

                    b.Property<string>("Website")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("CourseContactInfo");
                });

            modelBuilder.Entity("AG.Data.Model.CourseTextContent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About");

                    b.Property<long>("CourseId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("CourseTexts");
                });

            modelBuilder.Entity("AG.Data.Model.Hole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CourseId");

                    b.Property<int>("Number");

                    b.Property<int>("Par");

                    b.Property<string>("WistiaKey")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Holes");
                });

            modelBuilder.Entity("AG.Data.Model.CourseAddress", b =>
                {
                    b.HasOne("AG.Data.Model.Course", "Course")
                        .WithOne("Address")
                        .HasForeignKey("AG.Data.Model.CourseAddress", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AG.Data.Model.CourseContactInfo", b =>
                {
                    b.HasOne("AG.Data.Model.Course", "Course")
                        .WithOne("ContactInfo")
                        .HasForeignKey("AG.Data.Model.CourseContactInfo", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AG.Data.Model.CourseTextContent", b =>
                {
                    b.HasOne("AG.Data.Model.Course", "Course")
                        .WithOne("TextContent")
                        .HasForeignKey("AG.Data.Model.CourseTextContent", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AG.Data.Model.Hole", b =>
                {
                    b.HasOne("AG.Data.Model.Course", "Course")
                        .WithMany("Holes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}