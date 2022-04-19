public class Show : StreamingContent
{
    public int SeasonCount { get; set; }
    public int EpisodeCount { get; set; }
    public double AverageRunTime { get; set; }

    public List<Episode> Episodes { get; set; } = new List<Episode>();
}

public class Episode
{
    public string Title { get; set; } = "Untitled Episode";
    public double RunTime { get; set; }
    public int SeasonNumber { get; set; }
}