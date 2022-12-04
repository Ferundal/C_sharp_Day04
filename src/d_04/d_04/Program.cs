using System;
using System.IO;
using System.Text.Json;
using d_04.Model;

using Microsoft.Extensions.Configuration;

IConfigurationBuilder builder =
    new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
IConfigurationRoot root = builder.Build();

string jsonString =
    File.ReadAllText(root["book_reviews_path"]);
BookReviewsJson bookReviewsJson = JsonSerializer.Deserialize<BookReviewsJson>(jsonString);

jsonString =
    File.ReadAllText(root["movie_reviews_path"]);
MoveReviewsJson movieReviewsJson = JsonSerializer.Deserialize<MoveReviewsJson>(jsonString);

if (args.Length > 1)
{
    Console.WriteLine("Wrong arguments amount.");
    return;
}

if (args.Length == 1)
{
    if (args[0] != "best")
    {
        Console.WriteLine("Wrong argument.");
        return;
    }
    ISearchable best = bookReviewsJson.BookReviews.Best();
    if (best != default)
        Console.WriteLine($"{Environment.NewLine}Best in books:{Environment.NewLine}{best}");
    best = movieReviewsJson.MoveReviews.Best();
    if (best != default)
        Console.WriteLine($"{Environment.NewLine}Best in movies:{Environment.NewLine}{best}");
    return;
}

Console.WriteLine("Input search text:");
var search = Console.ReadLine();

var bookRes = bookReviewsJson.BookReviews.Search(search);
var movieRes = movieReviewsJson.MoveReviews.Search(search);
var length = bookRes.Length + movieRes.Length;
if (length == 0)
{
    Console.WriteLine($"There are no \"{search}\" in media today.");
    return;
}

Console.WriteLine($"Items found: {length}");
if (bookRes.Length > 0)
{
    Console.WriteLine($"{Environment.NewLine}" +
                      $"Book search result [{bookRes.Length}]:{Environment.NewLine}");
    foreach (var book in bookRes)
        Console.WriteLine(book);
}
if (movieRes.Length > 0)
{
    Console.WriteLine($"{Environment.NewLine}" +
                      $"Movie search result [{movieRes.Length}]:{Environment.NewLine}");
    foreach (var movie in movieRes)
        Console.WriteLine(movie);
}