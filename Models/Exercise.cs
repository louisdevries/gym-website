namespace GymWebsite.Models;

public class Exercise
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Sets { get; set; }
    public required string Duration { get; set; } // e.g., "30 seconds" or "15 reps"
    public required string CoachingCues { get; set; }
    public required string MediaUrl { get; set; } // Image or video URL
}