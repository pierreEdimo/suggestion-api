using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace houlala_suggestion;

public class SuggestionRepository(SuggestionDbContext dbContext) : ISuggestionRepository
{
    public async Task<ActionResult<Suggestion>> SaveWord(Suggestion suggestion)
    {
        dbContext.Suggestions.Add(suggestion);

        await dbContext.SaveChangesAsync();

        return suggestion; 
    }

    public async Task<ActionResult<List<string>>> GetSuggestionsBasedOnSearchTerm(Filter filter)
    {
        var queryable = dbContext.Suggestions.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.UserId))
        {
            queryable = queryable.Where(s => s.UserId == filter.UserId);
        }

        if (!string.IsNullOrWhiteSpace(filter.Term))
        {
            queryable = queryable.Where(s => s.Word!.Contains(filter.Term)); 
        }

        if (!string.IsNullOrWhiteSpace(filter.SortBy))
        {
            if (typeof(Suggestion).GetProperty(filter.SortBy) != null)
            {
                queryable = queryable.OrderByCustom(filter.SortBy, filter.SortOrder);
            }
        }

        var words = await queryable.Select((x) => x.Word)
            .Distinct()
            .ToListAsync();

        return words!;
    }

    public Task<ActionResult<List<Suggestion>>> GetTopSuggestions()
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<List<Suggestion>>> GetSuggestionsByUserId(string userId)
    {
        throw new NotImplementedException();
    }
}