// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Szarnapomvan.Application;

#nullable disable

namespace Szarnapomvan.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230228134030_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Szarnapomvan.Models.Data.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Budapest"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Baranya megye"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Bács-Kiskun megye"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Békés megye"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Borsod-Abaúj-Zemplén megye"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Csongrád-Csanád megye"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Fejér megye"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Győr-Moson-Sopron megye"
                        },
                        new
                        {
                            Id = 9L,
                            Name = "Hajdú-Bihar megye"
                        },
                        new
                        {
                            Id = 10L,
                            Name = "Heves megye"
                        },
                        new
                        {
                            Id = 11L,
                            Name = "Jász-Nagykun-Szolnok megye"
                        },
                        new
                        {
                            Id = 12L,
                            Name = "Komárom-Esztergom megye"
                        },
                        new
                        {
                            Id = 13L,
                            Name = "Nógrád megye"
                        },
                        new
                        {
                            Id = 14L,
                            Name = "Pest megye"
                        },
                        new
                        {
                            Id = 15L,
                            Name = "Somogy megye"
                        },
                        new
                        {
                            Id = 16L,
                            Name = "Szabolcs-Szatmár-Bereg megye"
                        },
                        new
                        {
                            Id = 17L,
                            Name = "Tolna megye"
                        },
                        new
                        {
                            Id = 18L,
                            Name = "Vas megye"
                        },
                        new
                        {
                            Id = 19L,
                            Name = "Veszprém megye"
                        },
                        new
                        {
                            Id = 20L,
                            Name = "Zala megye"
                        },
                        new
                        {
                            Id = 21L,
                            Name = "Egyéb"
                        },
                        new
                        {
                            Id = 22L,
                            Name = "Külföld"
                        });
                });

            modelBuilder.Entity("Szarnapomvan.Models.Data.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("BadLevel")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<long>("LocationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Szarnapomvan.Models.Data.Post", b =>
                {
                    b.HasOne("Szarnapomvan.Models.Data.Location", "Location")
                        .WithMany("Posts")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Szarnapomvan.Models.Data.Location", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
