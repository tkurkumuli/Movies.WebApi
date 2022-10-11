namespace Core.Application.Models
{
    public class MovieResponseModel
    {
        public string SearchType { get; set; }
        public string Expression { get; set; }
        public List<MovieSearchModel> Results { get; set; }
        public string ErrorMessage { get; set; }


        public MovieResponseModel()
        {
            Results = new List<MovieSearchModel>();
        }
    }
}
