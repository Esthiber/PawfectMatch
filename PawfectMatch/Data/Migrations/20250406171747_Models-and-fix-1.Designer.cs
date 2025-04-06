﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PawfectMatch.Data;

#nullable disable

namespace PawfectMatch.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250406171747_Models-and-fix-1")]
    partial class Modelsandfix1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PawfectMatch.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PawfectMatch.Models.Adoptantes", b =>
                {
                    b.Property<int>("AdoptanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdoptanteId"));

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ocupacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdoptanteId");

                    b.HasIndex("Id");

                    b.ToTable("Adoptantes");
                });

            modelBuilder.Entity("PawfectMatch.Models.Citas", b =>
                {
                    b.Property<int>("CitaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CitaId"));

                    b.Property<int>("AdoptanteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.HasKey("CitaId");

                    b.HasIndex("AdoptanteId");

                    b.HasIndex("MascotaId");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("PawfectMatch.Models._Mascotas.Categorias", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            Nombre = "Perros"
                        },
                        new
                        {
                            CategoriaId = 2,
                            Nombre = "Gatos"
                        });
                });

            modelBuilder.Entity("PawfectMatch.Models._Mascotas.Estados", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");

                    b.HasData(
                        new
                        {
                            EstadoId = 1,
                            Nombre = "Disponible"
                        },
                        new
                        {
                            EstadoId = 2,
                            Nombre = "Adoptado"
                        },
                        new
                        {
                            EstadoId = 3,
                            Nombre = "No Disponible"
                        });
                });

            modelBuilder.Entity("PawfectMatch.Models._Mascotas.Mascotas", b =>
                {
                    b.Property<int>("MascotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MascotaId"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaNacimieneto")
                        .HasColumnType("date");

                    b.Property<string>("FotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RazaId")
                        .HasColumnType("int");

                    b.Property<int>("RelacionSizeId")
                        .HasColumnType("int");

                    b.Property<double>("Tamano")
                        .HasColumnType("float");

                    b.HasKey("MascotaId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("RelacionSizeId");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("PawfectMatch.Models._Mascotas.Razas", b =>
                {
                    b.Property<int>("RazaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RazaId"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RazaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Razas");

                    b.HasData(
                        new
                        {
                            RazaId = 1,
                            CategoriaId = 1,
                            Nombre = "Labrador"
                        },
                        new
                        {
                            RazaId = 2,
                            CategoriaId = 1,
                            Nombre = "Bulldog"
                        },
                        new
                        {
                            RazaId = 3,
                            CategoriaId = 2,
                            Nombre = "Persa"
                        },
                        new
                        {
                            RazaId = 4,
                            CategoriaId = 2,
                            Nombre = "Siamés"
                        });
                });

            modelBuilder.Entity("PawfectMatch.Models._Mascotas.RelacionSizes", b =>
                {
                    b.Property<int>("RelacionSizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RelacionSizeId"));

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RelacionSizeId");

                    b.ToTable("RelacionSizes");

                    b.HasData(
                        new
                        {
                            RelacionSizeId = 1,
                            Size = "Pequeño"
                        },
                        new
                        {
                            RelacionSizeId = 2,
                            Size = "Mediano"
                        },
                        new
                        {
                            RelacionSizeId = 3,
                            Size = "Grande"
                        });
                });

            modelBuilder.Entity("PawfectMatch.Models._Mascotas.Sexos", b =>
                {
                    b.Property<int>("SexoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SexoId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SexoId");

                    b.ToTable("Sexos");

                    b.HasData(
                        new
                        {
                            SexoId = 1,
                            Nombre = "Macho"
                        },
                        new
                        {
                            SexoId = 2,
                            Nombre = "Hembra"
                        });
                });

            modelBuilder.Entity("PawfectMatch.Models._Solicitudes.EstadoSolicitudes", b =>
                {
                    b.Property<int>("EstadoSolicitudId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoSolicitudId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoSolicitudId");

                    b.ToTable("EstadoSolicitudes");

                    b.HasData(
                        new
                        {
                            EstadoSolicitudId = 1,
                            Nombre = "Pendiente"
                        },
                        new
                        {
                            EstadoSolicitudId = 2,
                            Nombre = "Aprobada"
                        },
                        new
                        {
                            EstadoSolicitudId = 3,
                            Nombre = "Rechazada"
                        });
                });

            modelBuilder.Entity("PawfectMatch.Models._Solicitudes.HistorialAdopciones", b =>
                {
                    b.Property<int>("HistorialAdopcioneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistorialAdopcioneId"));

                    b.Property<int>("AdoptanteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAdopcion")
                        .HasColumnType("datetime2");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.Property<string>("Notas")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HistorialAdopcioneId");

                    b.HasIndex("AdoptanteId");

                    b.HasIndex("MascotaId");

                    b.ToTable("HistorialAdopciones");
                });

            modelBuilder.Entity("PawfectMatch.Models._Solicitudes.SolicitudesAdopciones", b =>
                {
                    b.Property<int>("SolicitudAdopcionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SolicitudAdopcionId"));

                    b.Property<int>("AdoptanteId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoSolicitudId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("MascotaId")
                        .HasColumnType("int");

                    b.HasKey("SolicitudAdopcionId");

                    b.HasIndex("AdoptanteId");

                    b.HasIndex("EstadoSolicitudId");

                    b.HasIndex("MascotaId");

                    b.ToTable("SolicitudesAdopciones");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PawfectMatch.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PawfectMatch.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PawfectMatch.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PawfectMatch.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PawfectMatch.Models.Adoptantes", b =>
                {
                    b.HasOne("PawfectMatch.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("Id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PawfectMatch.Models.Citas", b =>
                {
                    b.HasOne("PawfectMatch.Models.Adoptantes", "Adoptante")
                        .WithMany()
                        .HasForeignKey("AdoptanteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawfectMatch.Models._Mascotas.Mascotas", "Mascota")
                        .WithMany()
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Adoptante");

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("PawfectMatch.Models._Mascotas.Mascotas", b =>
                {
                    b.HasOne("PawfectMatch.Models._Mascotas.Categorias", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawfectMatch.Models._Mascotas.Estados", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawfectMatch.Models._Mascotas.RelacionSizes", "RelacionSize")
                        .WithMany()
                        .HasForeignKey("RelacionSizeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Estado");

                    b.Navigation("RelacionSize");
                });

            modelBuilder.Entity("PawfectMatch.Models._Mascotas.Razas", b =>
                {
                    b.HasOne("PawfectMatch.Models._Mascotas.Categorias", "Categoria")
                        .WithMany("Razas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("PawfectMatch.Models._Solicitudes.HistorialAdopciones", b =>
                {
                    b.HasOne("PawfectMatch.Models.Adoptantes", "Adoptante")
                        .WithMany()
                        .HasForeignKey("AdoptanteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawfectMatch.Models._Mascotas.Mascotas", "Mascota")
                        .WithMany()
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Adoptante");

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("PawfectMatch.Models._Solicitudes.SolicitudesAdopciones", b =>
                {
                    b.HasOne("PawfectMatch.Models.Adoptantes", "Adoptante")
                        .WithMany()
                        .HasForeignKey("AdoptanteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawfectMatch.Models._Solicitudes.EstadoSolicitudes", "EstadoSolicitud")
                        .WithMany()
                        .HasForeignKey("EstadoSolicitudId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("PawfectMatch.Models._Mascotas.Mascotas", "Mascota")
                        .WithMany()
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Adoptante");

                    b.Navigation("EstadoSolicitud");

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("PawfectMatch.Models._Mascotas.Categorias", b =>
                {
                    b.Navigation("Razas");
                });
#pragma warning restore 612, 618
        }
    }
}
