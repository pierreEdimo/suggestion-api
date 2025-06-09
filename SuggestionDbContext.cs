using Microsoft.EntityFrameworkCore;

namespace houlala_suggestion;

public class SuggestionDbContext : DbContext
{
    public SuggestionDbContext(DbContextOptions<SuggestionDbContext> options) : base(options)
    {
    }

    public DbSet<Suggestion> Suggestions { get; set; }
}