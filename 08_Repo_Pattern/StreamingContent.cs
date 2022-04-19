using System.IO;
public enum Genre { Uncategorized, Action, Comedy, SciFi, Romance, Bromance, Documentary, Drama }
// Refactor to use the values in the IsFamilyFriendly getter
public enum MaturityRating { U, PG_13, R, NC_17, TV_14, TV_MA, G = 100, PG, TV_Y, TV_G, TV_PG }

public class StreamingContent
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double StarRating { get; set; }
    public Genre Genre { get; set; }
    public MaturityRating MaturityRating { get; set; }

    public bool IsFamilyFriendly
    {
        get
        {
            switch (MaturityRating)
            {
                case MaturityRating.G:
                case MaturityRating.PG:
                case MaturityRating.TV_Y:
                case MaturityRating.TV_G:
                case MaturityRating.TV_PG:
                    return true;
                case MaturityRating.PG_13:
                case MaturityRating.R:
                case MaturityRating.NC_17:
                case MaturityRating.TV_14:
                case MaturityRating.TV_MA:
                default:
                    return false;
            }

            // This can also be a switch expression
            return MaturityRating switch
            {
                MaturityRating.G or
                MaturityRating.PG or
                MaturityRating.TV_Y => true,
                MaturityRating.PG_13 or
                MaturityRating.R or
                MaturityRating.TV_MA => false,
                // etc
                _ => false
            };

            // We can also make use of the integer values of the enum
            if ((int)MaturityRating >= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    // We can ignore this warning, or make these props nullable, or give them default values
    public StreamingContent() { }

    public StreamingContent(string title, string description, MaturityRating maturityRating, double starRating, Genre genre)
    {
        Title = title;
        Description = description;
        MaturityRating = maturityRating;
        StarRating = starRating;
        Genre = genre;
    }
}