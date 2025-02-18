namespace GymWebsite.Models;

public class FitnessProgram
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool IsForMen { get; set; }
    public bool IsForWomen { get; set; }
    public required ICollection<ProgramExercise> ProgramExercises { get; set; }
}