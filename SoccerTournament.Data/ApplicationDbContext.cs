namespace SoccerTournament.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SoccerTournament.Data.Models;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Competition> Competitions { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Referee> Referees { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

                builder.Entity<Game>()
               .HasOne(e => e.HomeTeam)
               .WithMany(m=>m.HomeGames)
               .HasForeignKey(e => e.HomeTeamId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
               .HasOne(a => a.AwayTeam)
               .WithMany(m => m.AwayGames)
               .HasForeignKey(e => e.AwayTeamId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
               .HasOne(a => a.WinnerTeam)
               .WithMany(m => m.GamesWin)
               .HasForeignKey(e => e.WinnnerTeamId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Coach>()
               .HasOne(a => a.Team)
               .WithOne(m => m.Coach)
               .OnDelete(DeleteBehavior.Restrict);

           
        }
    }
}