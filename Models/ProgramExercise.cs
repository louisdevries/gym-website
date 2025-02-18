namespace GymWebsite.Models;

public class ProgramExercise
{
    public int ProgramId { get; set; }
    public required FitnessProgram Program { get; set; }

    public int ExerciseId { get; set; }
    public required Exercise Exercise { get; set; }
}