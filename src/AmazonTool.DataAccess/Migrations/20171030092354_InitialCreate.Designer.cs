﻿// <auto-generated />
using AmazonTool.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AmazonTool.DataAccess.Migrations
{
    [DbContext(typeof(AmazonToolContext))]
    [Migration("20171030092354_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AmazonTool.Core.Entities.Application.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Exception");

                    b.Property<string>("Level")
                        .HasMaxLength(128);

                    b.Property<string>("Message");

                    b.Property<string>("MessageTemplate");

                    b.Property<string>("RequestId")
                        .HasMaxLength(50);

                    b.Property<DateTimeOffset>("TimeStamp");

                    b.Property<string>("UserName")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Log");
                });
#pragma warning restore 612, 618
        }
    }
}
