﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Procoder;

namespace Procoder.Migrations
{
    [DbContext(typeof(ProcoderContext))]
    partial class ProcoderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Procoder.Models.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("map_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cat")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("map_category");

                    b.Property<string>("Category");

                    b.Property<DateTime>("CreateData")
                        .HasColumnName("create_data");

                    b.Property<DateTime>("LastEdit")
                        .HasColumnName("last_edit");

                    b.Property<string>("Name")
                        .HasColumnName("map_name");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("status");

                    b.Property<int>("userId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("maps");
                });

            modelBuilder.Entity("Procoder.Models.Nodes", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("node_id");

                    b.Property<string>("Content")
                        .HasColumnName("node_content");

                    b.Property<int?>("MapId");

                    b.Property<string>("ParentID")
                        .HasColumnName("pre_node_numb");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.ToTable("node_data");
                });

            modelBuilder.Entity("Procoder.Models.Snippet", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("NodesId");

                    b.Property<string>("Snip")
                        .HasColumnName("snippet");

                    b.HasKey("Id");

                    b.HasIndex("NodesId");

                    b.ToTable("Snippets");
                });

            modelBuilder.Entity("Procoder.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarImg")
                        .HasColumnName("avatar_img");

                    b.Property<string>("Email")
                        .HasColumnName("user_mail");

                    b.Property<string>("LastName")
                        .HasColumnName("last_name");

                    b.Property<string>("Name")
                        .HasColumnName("user_name");

                    b.Property<string>("Password")
                        .HasColumnName("password");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Procoder.Models.Nodes", b =>
                {
                    b.HasOne("Procoder.Models.Map")
                        .WithMany("Nodes")
                        .HasForeignKey("MapId");
                });

            modelBuilder.Entity("Procoder.Models.Snippet", b =>
                {
                    b.HasOne("Procoder.Models.Nodes")
                        .WithMany("LargeSnippet")
                        .HasForeignKey("NodesId");
                });
#pragma warning restore 612, 618
        }
    }
}
