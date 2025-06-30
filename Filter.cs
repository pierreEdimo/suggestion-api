namespace houlala_suggestion;

public class Filter
{
    public string? UserId { get; set; }
    public string? Term { get; set; }
    public string? SearchCategory { get; set; }
    public string? SortBy { get; set; } = "Word";
    private string _sortOrder = "asc";

    public string SortOrder
    {
        get => _sortOrder;
        set
        {
            if (value is "asc" or "desc")
            {
                _sortOrder = value;
            }
        }
    }
}