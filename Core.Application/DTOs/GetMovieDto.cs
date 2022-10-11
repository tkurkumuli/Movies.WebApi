namespace Core.Application.DTOs;
public record class GetMovieDto
{
    public string Id { get; set; }
    public string ResultType { get; set; }
    public string ImagePath { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
