﻿// <auto-generated />
using System;
using LLL.DurableTask.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LLL.DurableTask.EFCore.PostgreSQL.Migrations
{
    [DbContext(typeof(OrchestrationDbContext))]
    partial class OrchestrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.ActivityMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("InstanceId")
                        .IsRequired()
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<string>("LockId")
                        .IsConcurrencyToken()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LockedUntil")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Message")
                        .HasColumnType("text")
                        .HasMaxLength(2147483647);

                    b.Property<string>("Queue")
                        .IsRequired()
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<string>("ReplyQueue")
                        .IsRequired()
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("InstanceId");

                    b.HasIndex("LockedUntil");

                    b.HasIndex("LockedUntil", "Queue");

                    b.ToTable("ActivityMessages");
                });

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasMaxLength(2147483647);

                    b.Property<string>("ExecutionId")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("InstanceId")
                        .IsRequired()
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<int>("SequenceNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExecutionId");

                    b.HasIndex("InstanceId", "ExecutionId", "SequenceNumber")
                        .IsUnique();

                    b.ToTable("Events");
                });

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.Execution", b =>
                {
                    b.Property<string>("ExecutionId")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CompletedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CompressedSize")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CustomStatus")
                        .HasColumnType("text");

                    b.Property<string>("Input")
                        .HasColumnType("text");

                    b.Property<string>("InstanceId")
                        .IsRequired()
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("LastUpdatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Output")
                        .HasColumnType("text");

                    b.Property<string>("ParentInstance")
                        .HasColumnType("character varying(2000)")
                        .HasMaxLength(2000);

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("ExecutionId");

                    b.ToTable("Executions");
                });

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.Instance", b =>
                {
                    b.Property<string>("InstanceId")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<string>("LastExecutionId")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastQueueName")
                        .IsRequired()
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<string>("LockId")
                        .IsConcurrencyToken()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LockedUntil")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("InstanceId");

                    b.HasIndex("LastExecutionId");

                    b.HasIndex("LockedUntil");

                    b.ToTable("Instances");
                });

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.OrchestrationMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AvailableAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ExecutionId")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("InstanceId")
                        .IsRequired()
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Message")
                        .HasColumnType("text")
                        .HasMaxLength(2147483647);

                    b.Property<string>("Queue")
                        .IsRequired()
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<int>("SequenceNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AvailableAt");

                    b.HasIndex("InstanceId");

                    b.HasIndex("AvailableAt", "Queue");

                    b.ToTable("OrchestrationMessages");
                });

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.ActivityMessage", b =>
                {
                    b.HasOne("LLL.DurableTask.EFCore.Entities.Instance", "Instance")
                        .WithMany()
                        .HasForeignKey("InstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.Event", b =>
                {
                    b.HasOne("LLL.DurableTask.EFCore.Entities.Execution", "Execution")
                        .WithMany()
                        .HasForeignKey("ExecutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.Execution", b =>
                {
                    b.OwnsMany("LLL.DurableTask.EFCore.Entities.Tag", "Tags", b1 =>
                        {
                            b1.Property<string>("ExecutionId")
                                .HasColumnType("character varying(100)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("character varying(2000)")
                                .HasMaxLength(2000);

                            b1.HasKey("ExecutionId", "Id");

                            b1.ToTable("ExecutionTags");

                            b1.WithOwner()
                                .HasForeignKey("ExecutionId");
                        });
                });

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.Instance", b =>
                {
                    b.HasOne("LLL.DurableTask.EFCore.Entities.Execution", "LastExecution")
                        .WithMany()
                        .HasForeignKey("LastExecutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.OrchestrationMessage", b =>
                {
                    b.HasOne("LLL.DurableTask.EFCore.Entities.Instance", "Instance")
                        .WithMany()
                        .HasForeignKey("InstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
