﻿// <auto-generated />
using System;
using Dictionary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dictionary.Migrations
{
    [DbContext(typeof(DictionaryDbContext))]
    [Migration("20190710151223_TranslationToMeaning")]
    partial class TranslationToMeaning
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dictionary.Models.Term", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Meaning");

                    b.Property<string>("OriginalLanguage");

                    b.Property<string>("Text");

                    b.Property<string>("ToLanguage");

                    b.HasKey("Id");

                    b.ToTable("Terms");
                });
#pragma warning restore 612, 618
        }
    }
}
