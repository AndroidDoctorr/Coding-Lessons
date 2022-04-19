using System.Collections.Generic;

public class StreamingContentRepository
{
    private readonly List<StreamingContent> _contentDirectory = new List<StreamingContent>();

    public StreamingContentRepository()
    {
        Seed();
    }

    // CRUD
    // Create
    public bool AddContentToDirectory(StreamingContent content)
    {
        int startingCount = _contentDirectory.Count;

        _contentDirectory.Add(content);

        bool wasAdded = _contentDirectory.Count > startingCount;

        return wasAdded;
    }

    // Read
    public List<StreamingContent> GetAllStreamingContent()
    {
        return _contentDirectory;
    }

    public StreamingContent GetContentByTitle(string title)
    {
        foreach (StreamingContent content in _contentDirectory)
        {
            if (content.Title.ToLower() == title.ToLower())
            {
                return content;
            }
        }

        return default;
    }

    // Get by Rating
    // Get by Genre
    // Get by Family Friendly

    // Update
    public bool UpdateExistingContent(string originalTitle, StreamingContent newContent)
    {
        StreamingContent oldContent = GetContentByTitle(originalTitle);

        if (oldContent != default)
        {
            oldContent.Title = newContent.Title;
            oldContent.Description = newContent.Description;
            oldContent.StarRating = newContent.StarRating;
            oldContent.MaturityRating = newContent.MaturityRating;
            oldContent.Genre = newContent.Genre;

            return true;
        }
        else
        {
            return false;
        }
    }

    // Delete

    public bool DeleteExistingContent(string title)
    {
        StreamingContent contentToDelete = GetContentByTitle(title);

        if (contentToDelete != default)
        {
            bool deleteResult = _contentDirectory.Remove(contentToDelete);
            return deleteResult;
        }
        else
        {
            return false;
        }
    }

    private void Seed()
    {
        StreamingContent contentOne = new StreamingContent(
            "The Big Lebowski",
            "The Dude gets his car back",
            MaturityRating.R,
            5,
            Genre.Comedy
        );

        StreamingContent contentTwo = new StreamingContent(
            "Pi",
            "A mathematician tries to solve the universe, comes up with a 216 digit number",
            MaturityRating.R,
            5,
            Genre.Drama
        );

        StreamingContent contentThree = new StreamingContent(
            "The Room",
            "Everyone betrayed Johnny and he's fed up with this world",
            MaturityRating.R,
            5,
            Genre.Comedy
        );

        AddContentToDirectory(contentOne);
        AddContentToDirectory(contentTwo);
        AddContentToDirectory(contentThree);
    }
}