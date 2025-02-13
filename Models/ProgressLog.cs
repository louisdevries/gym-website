public class ProgressLog
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }

    public int SetsCompleted { get; set; }
    public int RepsCompleted { get; set; } // Actual reps or duration completed
    public DateTime Date { get; set; }
}
