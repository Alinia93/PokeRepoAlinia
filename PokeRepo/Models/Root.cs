namespace PokeRepo.Models
{
    public class Root
    {
        public List<Result> Results { get; set; }
    }


    public class Result
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
