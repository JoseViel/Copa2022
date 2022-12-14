// <auto-generated />
using System;
using Copa2022.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Copa2022.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20220922150416_Anotacoes")]
    partial class Anotacoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Copa2022.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("cidade")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<int>("idade")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Copa2022.Models.Conta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("clienteid")
                        .HasColumnType("int");

                    b.Property<int>("figurinhaid")
                        .HasColumnType("int");

                    b.Property<float>("quantidade")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("clienteid");

                    b.HasIndex("figurinhaid");

                    b.ToTable("Contas");
                });

            modelBuilder.Entity("Copa2022.Models.Figurinha", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<float>("compra")
                        .HasColumnType("real");

                    b.Property<int>("pais")
                        .HasColumnType("int");

                    b.Property<int>("posicao")
                        .HasColumnType("int");

                    b.Property<int>("raridade")
                        .HasColumnType("int");

                    b.Property<float>("venda")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("Figurinhas");
                });

            modelBuilder.Entity("Copa2022.Models.Transacao", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("contaid")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<int>("operacao")
                        .HasColumnType("int");

                    b.Property<float>("quantidade")
                        .HasColumnType("real");

                    b.Property<float>("valor")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("contaid");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("Copa2022.Models.Conta", b =>
                {
                    b.HasOne("Copa2022.Models.Cliente", "cliente")
                        .WithMany("contas")
                        .HasForeignKey("clienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Copa2022.Models.Figurinha", "figurinha")
                        .WithMany("contas")
                        .HasForeignKey("figurinhaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("figurinha");
                });

            modelBuilder.Entity("Copa2022.Models.Transacao", b =>
                {
                    b.HasOne("Copa2022.Models.Conta", "conta")
                        .WithMany("transacoes")
                        .HasForeignKey("contaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("conta");
                });

            modelBuilder.Entity("Copa2022.Models.Cliente", b =>
                {
                    b.Navigation("contas");
                });

            modelBuilder.Entity("Copa2022.Models.Conta", b =>
                {
                    b.Navigation("transacoes");
                });

            modelBuilder.Entity("Copa2022.Models.Figurinha", b =>
                {
                    b.Navigation("contas");
                });
#pragma warning restore 612, 618
        }
    }
}
