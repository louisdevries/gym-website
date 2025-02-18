namespace GymWebsite.Models;

public class PaidUserDetails
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Experience { get; set; } = string.Empty; // Beginner, Intermediate, Advanced
    public string Goals { get; set; } = string.Empty;
    public string FitnessType { get; set; } = string.Empty; // Cycling, Running, Swimming, etc.
    public string Injuries { get; set; } = string.Empty; // Any injuries or "None"

    // Navigation Property
    public User User { get; set; } = null!;
}
