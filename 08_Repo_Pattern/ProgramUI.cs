using System.Dynamic;
public class ProgramUI
{
    private readonly StreamingContentRepository _repo = new StreamingContentRepository();
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
            Console.Clear();
            double x;
            bool isNumber = double.TryParse("3.5", out x);

            Console.WriteLine(x);
            Console.WriteLine(
                "Menu:\n" +
                "1. Create Streaming Content Item\n" +
                "2. List All Streaming Content\n" +
                "3. Get Content By Title\n" +
                "4. Update Content Item\n" +
                "5. Remove Content Item\n" +
                "6. Exit"
            );

            string selection = Console.ReadLine() ?? "";

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
                    // UpdateContent();
                    break;
                case "5":
                    // RemoveContent();
                    break;
                case "6":
                    continueToRun = false;
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection.");
                    PauseAndWaitForKeypress();
                    break;
            }
        } while (continueToRun);
    }

    public void CreateStreamingContent()
    {
        Console.Clear();
        string title = GetValidStringInput("Title");
        string description = GetValidStringInput("Description");
        // Lazy way
        // string description = Console.ReadLine() ?? "";

        Console.WriteLine(
            "Please select a Maturity Rating:\n" +
            "1. G\n" +
            "2. PG\n" +
            "3. PG-13\n" +
            "4. R\n"
        );
        string maturitySelection = Console.ReadLine() ?? "4";
        MaturityRating maturity = maturitySelection switch
        {
            "1" => MaturityRating.G,
            "2" => MaturityRating.PG,
            "3" => MaturityRating.PG_13,
            "4" => MaturityRating.R,
            _ => MaturityRating.U,
        };

        Console.WriteLine(
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
        string genreSelection = Console.ReadLine() ?? "";
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
            Console.Clear();
            Console.Write("Please enter a valid star rating (0.0-5.0): ");
            string ratingString = Console.ReadLine() ?? "";
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
                Console.WriteLine("Rating must be a valid number between 0 and 5");
                PauseAndWaitForKeypress();
            }
        } while (!isValid);


        StreamingContent newContent = new StreamingContent(
            title, description, maturity, starRating, genre
        );

        _repo.AddContentToDirectory(newContent);
        Console.WriteLine($"{newContent.Title} added to Content Directory");
        Console.WriteLine($"{newContent.StarRating}");
        PauseAndWaitForKeypress();
    }

    private void ListAllStreamingContent()
    {
        Console.Clear();
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
        Console.Clear();

        Console.Write("Please enter a title: ");
        string title = Console.ReadLine() ?? "";

        Console.Clear();

        StreamingContent item = _repo.GetContentByTitle(title);

        if (item == default)
        {
            Console.WriteLine("Item not found :(");
        }
        else
        {
            DisplayContentItem(item);
        }

        PauseAndWaitForKeypress();
    }

    // Helper methods
    private void PauseAndWaitForKeypress()
    {
        // Pause and wait for keypress
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void DisplayContentItem(StreamingContent item, int itemIndex)
    {
        Console.WriteLine(
            $"{itemIndex}. {item.Title}\n" +
            $"{item.Description}\n" +
            $"Genre: {item.Genre} Rated: {item.MaturityRating}\n"
        );
    }

    private void DisplayContentItem(StreamingContent item)
    {
        Console.WriteLine(
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
            Console.Write($"Please enter a(n) {name.ToLower()}: ");
            input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine($"{name} cannot be empty.");
                PauseAndWaitForKeypress();
                Console.Clear();
            }
        } while (string.IsNullOrWhiteSpace(name));

        return input;
    }
}
