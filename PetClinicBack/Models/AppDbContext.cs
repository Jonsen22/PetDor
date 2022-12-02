using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using PetShopBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using PetClinicBack.Models;

namespace PetClinicBack.Models
{

    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        //mapeamento da entidade para a tabela
        //o provedor e a string de conexão
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Veterinario> Veterinario { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Tutor> Tutor { get; set; }
        public DbSet<Vacina> Vacina { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<TipoVacina> TipoVacina { get; set; }
        public DbSet<Especialidades> Especialidade { get; set; }
        public DbSet<PetClinicBack.Models.VetEspecialidades> VetEspecialidades { get; set; }
        public ICollection<VetEspecialidades> VetEspecialidade { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Consulta>()
                .Property(a => a.Duracao)
                .HasDefaultValue(30);

            //mb.Entity<Appointment>()
            //    .Property(a => a.AgendaMedic)
            //    .IsRequired();

            mb.Entity<Consulta>()
                .Property(a => a.Data)
                .IsRequired()
                .HasColumnType("DateTime");

            mb.Entity<Veterinario>()
                .Property(m => m.Nome)
                .HasMaxLength(80)
                .IsRequired();

            mb.Entity<Veterinario>()
               .Property(m => m.Nascimento)
               .IsRequired()
               .HasColumnType("Date");

            mb.Entity<Veterinario>()
               .Property(m => m.CPF)
               .HasMaxLength(25)
               .IsRequired();

            mb.Entity<Veterinario>()
               .Property(m => m.Email)
               .IsRequired();

            mb.Entity<Veterinario>()
               .Property(m => m.Celular)
               .HasMaxLength(25)
               .IsRequired();

            mb.Entity<Veterinario>()
               .Property(m => m.CEP)
               .HasMaxLength(25)
               .IsRequired();

            mb.Entity<Tutor>()
                .Property(u => u.Nome)
                .HasMaxLength(80)
                .IsRequired();

            mb.Entity<Tutor>()
               .Property(u => u.Aniversario)
               .IsRequired()
               .HasColumnType("Date");

            mb.Entity<Tutor>()
               .Property(u => u.CPF)
               .HasMaxLength(25)
               .IsRequired();

            mb.Entity<Tutor>()
               .Property(u => u.Email)
               .IsRequired();

            mb.Entity<Tutor>()
               .Property(u => u.Celular)
               .HasMaxLength(25)
               .IsRequired();

            mb.Entity<Tutor>()
               .Property(u => u.CEP)
               .HasMaxLength(25)
               .IsRequired();

            //mb.Entity<User>()
            //   .Property(u => u.Pets)
            //   .IsRequired();

            mb.Entity<Pet>()
                .Property(p => p.Nome)
                .HasMaxLength(80)
                .IsRequired();

            mb.Entity<Pet>()
               .Property(p => p.Nascimento)
               .IsRequired()
               .HasColumnType("Date");

            mb.Entity<Pet>()
                .Property(p => p.Animal)
                .HasMaxLength(25)
                .IsRequired();

            mb.Entity<Pet>()
                .Property(p => p.Raca)
                .HasMaxLength(80)
                .IsRequired();

            //mb.Entity<Vacine>()
            //    .Property(v => v.Pet)
            //    .IsRequired();

            mb.Entity<Vacina>()
                .Property(v => v.DiaAplicacao)
                .IsRequired()
                .HasColumnType("DateTime");

            mb.Entity<Especialidades>()
                .HasKey(sc => new { sc.EspecialidadesId });

            mb.Entity<Especialidades>()
                .Property(s => s.EspecialidadesNome)
                .IsRequired();

            mb.Entity<TipoVacina>()
                .HasKey(sc => new { sc.TipoVacinaId });

            mb.Entity<TipoVacina>()
               .Property(v => v.Nome)
               .IsRequired();

            mb.Entity<TipoVacina>()
              .Property(v => v.Iniciais)
              .IsRequired();

            mb.Entity<VetEspecialidades>().HasKey(sc =>
            new { sc.VeterinarioId, sc.EspecialidadesId });
        }


        

    }

    
}