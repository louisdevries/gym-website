using Microsoft.EntityFrameworkCore;

namespace GymWebsite.Models;
public class WarriorWisdomContext : DbContext
{
    public WarriorWisdomContext(DbContextOptions<WarriorWisdomContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<PaidUserDetails> PaidUserDetails { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<FitnessProgram> FitnessPrograms { get; set; }
    public DbSet<ProgramExercise> ProgramExercises { get; set; }
    public DbSet<ProgressLog> ProgressLogs { get; set; }


     protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Define composite key for ProgramExercise
    modelBuilder.Entity<ProgramExercise>()
        .HasKey(pe => new { pe.ProgramId, pe.ExerciseId });  // Composite primary key

    // Configure relationships for ProgramExercise
    modelBuilder.Entity<ProgramExercise>()
        .HasOne(pe => pe.Program)
        .WithMany()  // No navigation property back from FitnessProgram
        .HasForeignKey(pe => pe.ProgramId)
        .OnDelete(DeleteBehavior.Cascade);  // Cascade delete if needed

    modelBuilder.Entity<ProgramExercise>()
        .HasOne(pe => pe.Exercise)
        .WithMany()  // No navigation property back from Exercise
        .HasForeignKey(pe => pe.ExerciseId)
        .OnDelete(DeleteBehavior.Cascade);  // Cascade delete if needed

    // Existing relationship for PaidUserDetails
    modelBuilder.Entity<PaidUserDetails>()
        .HasOne(p => p.User)
        .WithOne(u => u.PaidUserDetails)
        .HasForeignKey<PaidUserDetails>(p => p.UserId)
        .OnDelete(DeleteBehavior.Cascade);
}

}