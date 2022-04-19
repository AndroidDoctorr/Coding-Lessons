public class Movie : StreamingContent
{
    public double RunTime { get; set; }

    public Movie() { }

    public Movie(
        string title,
        string description,
        MaturityRating maturityRating,
        Genre genre,
        double starRating,
        double runTime
    ) : base(title, description, maturityRating, starRating, genre)
    {
        RunTime = runTime;
    }
}