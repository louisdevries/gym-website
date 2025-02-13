using Microsoft.EntityFrameworkCore;

public class WarriorWisdomContext : DbContext
{
    public WarriorWisdomContext(DbContextOptions<WarriorWisdomContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Program> Programs { get; set; }
    public DbSet<ProgramExercise> ProgramExercises { get; set; }
    public DbSet<ProgressLog> ProgressLogs { get; set; }
}