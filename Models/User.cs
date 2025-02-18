namespace GymWebsite.Models;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public string? PasswordHash { get; set; }
    public bool IsPaidUser { get; set; } = false; // Indicates if the user is a paid user

    // Navigation Property
    public PaidUserDetails? PaidUserDetails { get; set; } 
}

