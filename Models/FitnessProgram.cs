public class FitnessProgram
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsForMen { get; set; }
    public bool IsForWomen { get; set; }
    public ICollection<ProgramExercise> ProgramExercises { get; set; }
}