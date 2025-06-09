using System.ComponentModel.DataAnnotations;

namespace houlala_suggestion;

public class Suggestion
{
    [Key] public int Id { get; set; }
    public string? UserId { get; set; }
    public string? Word { get; set; }
}