using Microsoft.AspNetCore.Mvc;

namespace houlala_suggestion;

public interface ISuggestionRepository
{
    Task<ActionResult<Suggestion>> SaveWord(Suggestion suggestion);

    Task<ActionResult<List<string>>> GetSuggestionsBasedOnSearchTerm(Filter filter);

    Task<ActionResult<List<Suggestion>>> GetTopSuggestions();

    Task<ActionResult<List<Suggestion>>> GetSuggestionsByUserId(string userId);
}