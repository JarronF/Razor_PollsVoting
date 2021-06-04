﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Razor_PollsVoting.Data;

namespace Razor_PollsVoting.Migrations
{
    [DbContext(typeof(PollContext))]
    partial class PollContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Razor_PollsVoting.Data.Models.Choice", b =>
                {
                    b.Property<int>("ChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChoiceText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("PollId")
                        .HasColumnType("int");

                    b.HasKey("ChoiceId");

                    b.HasIndex("PollId");

                    b.ToTable("Choice");
                });

            modelBuilder.Entity("Razor_PollsVoting.Data.Models.Poll", b =>
                {
                    b.Property<int>("PollId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEntered")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PollQuestion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PollId");

                    b.ToTable("Poll");
                });

            modelBuilder.Entity("Razor_PollsVoting.Data.Models.Vote", b =>
                {
                    b.Property<int>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChoiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEntered")
                        .HasColumnType("datetime2");

                    b.Property<string>("IPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PollId")
                        .HasColumnType("int");

                    b.HasKey("VoteId");

                    b.ToTable("Vote");
                });

            modelBuilder.Entity("Razor_PollsVoting.Data.Models.Choice", b =>
                {
                    b.HasOne("Razor_PollsVoting.Data.Models.Poll", "Poll")
                        .WithMany("Choices")
                        .HasForeignKey("PollId");

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("Razor_PollsVoting.Data.Models.Poll", b =>
                {
                    b.Navigation("Choices");
                });
#pragma warning restore 612, 618
        }
    }
}
