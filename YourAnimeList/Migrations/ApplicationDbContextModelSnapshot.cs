﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YourAnimeList.Models;

namespace YourAnimeList.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YourAnimeList.Models.Anime", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnimeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AnimeEpisodes")
                        .HasColumnType("int");

                    b.Property<string>("AnimeGenere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnimeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("AnimeRating")
                        .HasColumnType("real");

                    b.Property<string>("AnimeReleaseDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnimeStudio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnimeURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Animes");
                });
#pragma warning restore 612, 618
        }
    }
}
