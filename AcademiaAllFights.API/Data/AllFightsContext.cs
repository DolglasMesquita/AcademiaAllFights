using System;
using System.Collections.Generic;
using System.Globalization;
using AcademiaAllFights.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiaAllFights.API.Data
{
    public class AllFightsContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<ArteMarcial> ArtesMarciais { get; set; }
        public DbSet<AlunoArteMarcial> AlunosArtesMarciais { get; set; }

        public AllFightsContext(DbContextOptions<AllFightsContext> options) : base(options) 
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoArteMarcial>().HasKey(am => new {am.AlunoId, am.ArteMarcialId});

            builder.Entity<Professor>().HasData(new List<Professor>()
            {
                new Professor(1, "Lauro", "25496857488"),
                new Professor(2, "Roberto", "36587456914"),
                new Professor(3, "Ronaldo", "54879652147"),
                new Professor(4, "Rodrigo", "16587412599"),
                new Professor(5, "Alexandre", "12569854211"),
            });

            builder.Entity<ArteMarcial>().HasData(new List<ArteMarcial>
            {
                new ArteMarcial(1, "Karatê", 1),
                new ArteMarcial(2, "Judô", 1),
                new ArteMarcial(3, "Jiujitsu", 2),
                new ArteMarcial(4, "Morganti Ju-jitsu", 3),
                new ArteMarcial(5, "Boxe", 4),
            });

            builder.Entity<Aluno>().HasData(new List<Aluno>()
            {
                new Aluno(1, "Marta", "16598745688", "332255553", DateTime.Parse("02/27/2000", CultureInfo.InvariantCulture)),
                new Aluno(2, "Paula", "36925814755", "335428866", DateTime.Parse("01/21/2005", CultureInfo.InvariantCulture)),
                new Aluno(3, "Laura", "96385274166", "556688994", DateTime.Parse("09/23/1993", CultureInfo.InvariantCulture)),
                new Aluno(4, "Luiza", "12345678988", "656565923", DateTime.Parse("07/18/1997", CultureInfo.InvariantCulture)),
                new Aluno(5, "Lucas", "98765432100", "565685415", DateTime.Parse("12/11/2002", CultureInfo.InvariantCulture)),
                new Aluno(6, "Pedro", "01203225455", "456454545", DateTime.Parse("11/08/2005", CultureInfo.InvariantCulture)),
                new Aluno(7, "Paulo", "99988877700", "987451265", DateTime.Parse("06/01/1994", CultureInfo.InvariantCulture))
            });


            builder.Entity<AlunoArteMarcial>().HasData(new List<AlunoArteMarcial>() 
            {
                new AlunoArteMarcial() {AlunoId = 1, ArteMarcialId = 2 },
                new AlunoArteMarcial() {AlunoId = 1, ArteMarcialId = 4 },
                new AlunoArteMarcial() {AlunoId = 1, ArteMarcialId = 5 },
                new AlunoArteMarcial() {AlunoId = 2, ArteMarcialId = 1 },
                new AlunoArteMarcial() {AlunoId = 2, ArteMarcialId = 2 },
                new AlunoArteMarcial() {AlunoId = 2, ArteMarcialId = 5 },
                new AlunoArteMarcial() {AlunoId = 3, ArteMarcialId = 1 },
                new AlunoArteMarcial() {AlunoId = 3, ArteMarcialId = 2 },
                new AlunoArteMarcial() {AlunoId = 3, ArteMarcialId = 3 },
                new AlunoArteMarcial() {AlunoId = 4, ArteMarcialId = 1 },
                new AlunoArteMarcial() {AlunoId = 4, ArteMarcialId = 4 },
                new AlunoArteMarcial() {AlunoId = 4, ArteMarcialId = 5 },
                new AlunoArteMarcial() {AlunoId = 5, ArteMarcialId = 4 },
                new AlunoArteMarcial() {AlunoId = 5, ArteMarcialId = 5 },
                new AlunoArteMarcial() {AlunoId = 6, ArteMarcialId = 1 },
                new AlunoArteMarcial() {AlunoId = 6, ArteMarcialId = 2 },
                new AlunoArteMarcial() {AlunoId = 6, ArteMarcialId = 3 },
                new AlunoArteMarcial() {AlunoId = 6, ArteMarcialId = 4 },
                new AlunoArteMarcial() {AlunoId = 7, ArteMarcialId = 1 },
                new AlunoArteMarcial() {AlunoId = 7, ArteMarcialId = 2 },
                new AlunoArteMarcial() {AlunoId = 7, ArteMarcialId = 3 },
                new AlunoArteMarcial() {AlunoId = 7, ArteMarcialId = 4 },
                new AlunoArteMarcial() {AlunoId = 7, ArteMarcialId = 5 }
            });
        }
    }
}