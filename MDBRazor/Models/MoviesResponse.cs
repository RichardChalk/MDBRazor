namespace MDBRazor.Models
{
    public class MoviesResponse
    {
        public int page { get; set; }
        public string next { get; set; }
        public int entries { get; set; }
        public List<Result> Results { get; set; }
    }
}
