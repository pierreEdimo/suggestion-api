using houlala_suggestion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<SuggestionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("database")));
builder.Services.AddTransient<ISuggestionRepository, SuggestionRepository>();

builder.Services.AddCors(options => options.AddPolicy("EnableAll", cors =>
{
    cors.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.MapPost("/api/suggestions", (ISuggestionRepository suggestionRepository, Suggestion suggestion) =>
{
    var createdSuggestion =  suggestionRepository.SaveWord(suggestion).Result.Value;

    return Results.Created("", createdSuggestion);
});

app.MapGet("/api/suggestions", ([AsParameters] Filter filter, ISuggestionRepository suggestionRepository) =>
{
    var words = suggestionRepository.GetSuggestionsBasedOnSearchTerm(filter).Result.Value;

    var suggestionResult = new SuggestionResult()
    {
        Query = filter.Term, 
        Suggestions = words ?? []
    }; 

    return Results.Ok(suggestionResult);
}); 

app.MapGet("/suggestions", () => { return "Hello World"; }).WithName("GetSuggestions");

app.Run();