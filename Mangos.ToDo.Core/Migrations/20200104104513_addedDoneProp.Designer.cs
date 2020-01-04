﻿// <auto-generated />
using System;
using Mangos.ToDo.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mangos.ToDo.Core.Migrations
{
    [DbContext(typeof(ToDoContext))]
    [Migration("20200104104513_addedDoneProp")]
    partial class addedDoneProp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Mangos.ToDo.Entities.ToDoItem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnType("char(36)");

                    b.Property<bool>("Deleted");

                    b.Property<bool>("Done");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("ToDoListId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)));

                    b.Property<string>("Todo");

                    b.HasKey("Id");

                    b.HasIndex("ToDoListId");

                    b.ToTable("ToDoItems");
                });

            modelBuilder.Entity("Mangos.ToDo.Entities.ToDoList", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 36)))
                        .HasColumnType("char(36)");

                    b.Property<byte>("Deleted")
                        .HasColumnType("TINYINT(4)");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ToDoLists");
                });

            modelBuilder.Entity("Mangos.ToDo.Entities.ToDoItem", b =>
                {
                    b.HasOne("Mangos.ToDo.Entities.ToDoList")
                        .WithMany("ToDoItems")
                        .HasForeignKey("ToDoListId");
                });
#pragma warning restore 612, 618
        }
    }
}
