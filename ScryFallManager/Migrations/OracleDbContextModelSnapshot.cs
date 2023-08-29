﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using ScryFallManager.Data;

#nullable disable

namespace ScryFallManager.Migrations
{
    [DbContext(typeof(OracleDbContext))]
    partial class OracleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScryFallManager.Entities.Carta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ColecaoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("CustoMana")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime?>("DataLancamento")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("Raridade")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Texto")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("ColecaoId");

                    b.ToTable("Cartas");
                });

            modelBuilder.Entity("ScryFallManager.Entities.Colecao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataLancamento")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Nome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Colecao");
                });

            modelBuilder.Entity("ScryFallManager.Entities.Habilidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("CartaId");

                    b.ToTable("Habilidades");
                });

            modelBuilder.Entity("ScryFallManager.Entities.Idioma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ColecaoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)");

                    b.HasKey("Id");

                    b.HasIndex("CartaId");

                    b.HasIndex("ColecaoId");

                    b.ToTable("Idiomas");
                });

            modelBuilder.Entity("ScryFallManager.Entities.Legalidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CartaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Formato")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.HasKey("Id");

                    b.HasIndex("CartaId");

                    b.ToTable("Legalidade");
                });

            modelBuilder.Entity("ScryFallManager.Entities.Carta", b =>
                {
                    b.HasOne("ScryFallManager.Entities.Colecao", "Colecao")
                        .WithMany("Cartas")
                        .HasForeignKey("ColecaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colecao");
                });

            modelBuilder.Entity("ScryFallManager.Entities.Habilidade", b =>
                {
                    b.HasOne("ScryFallManager.Entities.Carta", "Carta")
                        .WithMany("Habilidades")
                        .HasForeignKey("CartaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carta");
                });

            modelBuilder.Entity("ScryFallManager.Entities.Idioma", b =>
                {
                    b.HasOne("ScryFallManager.Entities.Carta", "Carta")
                        .WithMany("Idiomas")
                        .HasForeignKey("CartaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScryFallManager.Entities.Colecao", "Colecao")
                        .WithMany("Idiomas")
                        .HasForeignKey("ColecaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carta");

                    b.Navigation("Colecao");
                });

            modelBuilder.Entity("ScryFallManager.Entities.Legalidade", b =>
                {
                    b.HasOne("ScryFallManager.Entities.Carta", "Carta")
                        .WithMany("Legalidades")
                        .HasForeignKey("CartaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carta");
                });

            modelBuilder.Entity("ScryFallManager.Entities.Carta", b =>
                {
                    b.Navigation("Habilidades");

                    b.Navigation("Idiomas");

                    b.Navigation("Legalidades");
                });

            modelBuilder.Entity("ScryFallManager.Entities.Colecao", b =>
                {
                    b.Navigation("Cartas");

                    b.Navigation("Idiomas");
                });
#pragma warning restore 612, 618
        }
    }
}
