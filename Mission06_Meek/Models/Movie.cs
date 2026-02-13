using System.ComponentModel.DataAnnotations;

namespace Mission06_Meek.Models;

public class Movie
{
    public int MovieId { get; set; }

    [Required]
    public string Category { get; set; } = string.Empty;

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Range(1888, 2100)]
    public int Year { get; set; }

    [Required]
    public string Director { get; set; } = string.Empty;

    [Required]
    [RegularExpression("^(G|PG|PG-13|R)$", ErrorMessage = "Rating must be G, PG, PG-13, or R.")]
    public string Rating { get; set; } = string.Empty;

    public bool? Edited { get; set; }

    public string? LentTo { get; set; }

    [StringLength(25)]
    public string? Notes { get; set; }
}
