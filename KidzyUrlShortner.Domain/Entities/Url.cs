namespace VazirUrlShortner.Domain.Entities
{
    public record Url
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Link { get; set; }
        public int TimesVisited { get; set; }
        public DateTime CreationDate { get; set; }

        public Url()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}