using System.Dynamic;
public class SCUITwo
{
    private readonly StreamingContentRepository _repo = new StreamingContentRepository();
    private IConsole _console;

    public SCUITwo(IConsole console)
    {
        _console = console;
    }

    public void Run()
    {
        // Seed some content to test with
        // Seed(); <-- moved to the repo class
        // Show a menu
        RunMenu();
    }

    public void RunMenu()
    {
        bool continueToRun = true;
        do
        {
            _console.Clear();
            _console.WriteLine(
                "Menu:\n" +
                "1. Create Streaming Content Item\n" +
                "2. List All Streaming Content\n" +
                "3. Get Content By Title\n" +
                "4. Update Content Item Maturity Rating\n" +
                "9. Remove Content Item\n" +
                "0. Exit"
            );

            string selection = _console.ReadLine() ?? "";

            switch (selection)
            {
                case "1":
                    CreateStreamingContent();
                    break;
                case "2":
                    ListAllStreamingContent();
                    break;
                case "3":
                    GetContentByTitle();
                    break;
                case "4":
                    UpdateMaturityRatingByTitle();
                    break;
                case "9":
                    RemoveContent();
                    break;
                case "0":
                    continueToRun = false;
                    break;
                default:
                    _console.WriteLine("Please enter a valid selection.");
                    PauseAndWaitForKeypress();
                    break;
            }
        } while (continueToRun);
    }

    public void CreateStreamingContent()
    {
        _console.Clear();
        string title = GetValidStringInput("Title");
        string description = GetValidStringInput("Description");
        // Lazy way
        // string description = _console.ReadLine() ?? "";

        _console.WriteLine(
            "Please select a Maturity Rating:\n" +
            "1. G\n" +
            "2. PG\n" +
            "3. PG-13\n" +
            "4. R\n"
        );
        string maturitySelection = _console.ReadLine() ?? "4";
        MaturityRating maturity = maturitySelection switch
        {
            "1" => MaturityRating.G,
            "2" => MaturityRating.PG,
            "3" => MaturityRating.PG_13,
            "4" => MaturityRating.R,
            _ => MaturityRating.U,
        };

        _console.WriteLine(
            "Please select a Genre:\n" +
            "0. Uncategorized\n" +
            "1. Action\n" +
            "2. Comedy\n" +
            "3. Sci-Fi\n" +
            "4. Romance\n" +
            "5. Bromance\n" +
            "6. Documentary\n" +
            "7. Drama\n"
        );
        string genreSelection = _console.ReadLine() ?? "";
        Genre genre = genreSelection switch
        {
            "1" => Genre.Action,
            "2" => Genre.Comedy,
            "3" => Genre.SciFi,
            "4" => Genre.Romance,
            "5" => Genre.Bromance,
            "6" => Genre.Documentary,
            "7" => Genre.Drama,
            _ => Genre.Uncategorized,
        };

        double starRating;
        bool isNumber;
        bool isValid;
        do
        {
            isValid = false;
            _console.Clear();
            _console.Write("Please enter a valid star rating (0.0-5.0): ");
            string ratingString = _console.ReadLine() ?? "";
            isNumber = double.TryParse(ratingString, out starRating);
            if (isNumber)
            {
                if (starRating >= 0 && starRating <= 5.0)
                {
                    isValid = true;
                }
            }
            if (!isValid)
            {
                _console.WriteLine("Rating must be a valid number between 0 and 5");
                PauseAndWaitForKeypress();
            }
        } while (!isValid);


        StreamingContent newContent = new StreamingContent(
            title, description, maturity, starRating, genre
        );

        _repo.AddContentToDirectory(newContent);
        _console.WriteLine($"{newContent.Title} added to Content Directory");
        _console.WriteLine($"{newContent.StarRating}");
        PauseAndWaitForKeypress();
    }

    private void ListAllStreamingContent()
    {
        _console.Clear();
        List<StreamingContent> allContent = _repo.GetAllStreamingContent();

        int index = 1;
        foreach (StreamingContent item in allContent)
        {
            DisplayContentItem(item, index++);
        }
        PauseAndWaitForKeypress();
    }

    private void GetContentByTitle()
    {
        _console.Clear();

        _console.Write("Please enter a title: ");
        string title = _console.ReadLine() ?? "";

        _console.Clear();

        StreamingContent item = _repo.GetContentByTitle(title);

        if (item == default)
        {
            _console.WriteLine("Item not found :(");
        }
        else
        {
            DisplayContentItem(item);
        }

        PauseAndWaitForKeypress();
    }

    public void UpdateMaturityRatingByTitle()
    {
        _console.Clear();

        _console.Write("Please enter a title: ");
        string title = _console.ReadLine() ?? "";

        _console.Clear();

        StreamingContent item = _repo.GetContentByTitle(title);
        string originalTitle = item.Title;

        if (item == default)
        {
            _console.WriteLine("Item not found :(");
        }
        else
        {
            DisplayContentItem(item);
            _console.WriteLine(
                "Please select a Maturity Rating:\n" +
                "1. G\n" +
                "2. PG\n" +
                "3. PG-13\n" +
                "4. R\n"
            );
            string maturitySelection = _console.ReadLine() ?? "4";
            MaturityRating maturity = maturitySelection switch
            {
                "1" => MaturityRating.G,
                "2" => MaturityRating.PG,
                "3" => MaturityRating.PG_13,
                "4" => MaturityRating.R,
                _ => MaturityRating.U,
            };

            item.MaturityRating = maturity;

            bool wasSuccessful = _repo.UpdateExistingContent(originalTitle, item);

            _console.Clear();

            if (!wasSuccessful)
            {
                _console.WriteLine("Error updating streaming content item :(");
            }
            else
            {
                _console.WriteLine("Streaming content item successfully updated!");
            }
        }

        PauseAndWaitForKeypress();
    }

    public void RemoveContent()
    {
        _console.Clear();

        _console.Write("Please enter the title of the item you wish to delete: ");
        string title = _console.ReadLine() ?? "";

        _console.Clear();

        StreamingContent item = _repo.GetContentByTitle(title);
        string originalTitle = item.Title;

        if (item == default)
        {
            _console.WriteLine("Item not found :(");
        }
        else
        {
            DisplayContentItem(item);
            _console.WriteLine("Are you sure you want to delete this? (y/n): ");
            string response = _console.ReadLine() ?? "";
            if (response.ToLower() == "y" || response.ToLower() == "yes")
            {
                bool wasSuccessful = _repo.DeleteExistingContent(originalTitle);

                _console.Clear();

                if (!wasSuccessful)
                {
                    _console.WriteLine("Error deleting streaming content item :(");
                }
                else
                {
                    _console.WriteLine("Streaming content item successfully removed!");
                }
            }
        }

        PauseAndWaitForKeypress();
    }

    // Helper methods
    private void PauseAndWaitForKeypress()
    {
        // Pause and wait for keypress
        _console.WriteLine("Press any key to continue...");
        _console.ReadKey();
    }

    private void DisplayContentItem(StreamingContent item, int itemIndex)
    {
        _console.WriteLine(
            $"{itemIndex}. {item.Title}\n" +
            $"{item.Description}\n" +
            $"Genre: {item.Genre} Rated: {item.MaturityRating}\n"
        );
    }

    private void DisplayContentItem(StreamingContent item)
    {
        _console.WriteLine(
            $"{item.Title}\n" +
            $"{item.Description}\n" +
            $"Genre: {item.Genre} Rated: {item.MaturityRating}\n"
        );
    }

    private string GetValidStringInput(string name)
    {
        string input;
        do
        {
            _console.Write($"Please enter a(n) {name.ToLower()}: ");
            input = _console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                _console.WriteLine($"{name} cannot be empty.");
                PauseAndWaitForKeypress();
                _console.Clear();
            }
        } while (string.IsNullOrWhiteSpace(name));

        return input;
    }
}
