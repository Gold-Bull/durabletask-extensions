﻿// <auto-generated />
using System;
using LLL.DurableTask.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LLL.DurableTask.EFCore.SqlServer.Migrations
{
    [DbContext(typeof(OrchestrationDbContext))]
    partial class OrchestrationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.ActivityMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstanceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("LockId")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LockedUntil")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(2147483647);

                    b.Property<string>("Queue")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("ReplyQueue")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
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
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(2147483647);

                    b.Property<string>("ExecutionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("InstanceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("SequenceNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExecutionId");

                    b.HasIndex("InstanceId", "ExecutionId", "SequenceNumber")
                        .IsUnique();

                    b.ToTable("Events");
                });

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.Execution", b =>
                {
                    b.Property<string>("ExecutionId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CompletedTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("CompressedSize")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Input")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstanceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("LastUpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Output")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentInstance")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ExecutionId");

                    b.ToTable("Executions");
                });

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.Instance", b =>
                {
                    b.Property<string>("InstanceId")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("LastExecutionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastQueueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("LockId")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LockedUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("InstanceId");

                    b.HasIndex("LastExecutionId");

                    b.HasIndex("LockedUntil");

                    b.ToTable("Instances");
                });

            modelBuilder.Entity("LLL.DurableTask.EFCore.Entities.OrchestrationMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AvailableAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExecutionId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("InstanceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(2147483647);

                    b.Property<string>("Queue")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("SequenceNumber")
                        .HasColumnType("int");

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
                                .HasColumnType("nvarchar(100)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(2000)")
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
