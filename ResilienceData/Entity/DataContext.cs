
using Microsoft.EntityFrameworkCore;
using ResilienceData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResilienceData.Entity
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateCalculatedResult> CalculatedResults { get; set; }
        public DbSet<CandidateScore> CandidateScores { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<QuestionnaireQuestion> Questions { get; set; }
        public DbSet<QuestionnaireType> QuestionnaireTypes { get; set; }
        public DbSet<ScoreType> ScoreTypes { get; set; }
        public DbSet<Team> Teams { get; set; }

       

    }
}
