using System;
using System.IO;
using System.Text.Json;
using d_04.Model;

string jsonString =
    File.ReadAllText(@"C:\Users\ferun\RiderProjects\C_sharp\C_sharp_Day04-0\src\d_04\d_04\book_reviews.json");
BookReviewsJson bookReviewsJson = JsonSerializer.Deserialize<BookReviewsJson>(jsonString);
foreach (var bookReview in bookReviewsJson.Results)
{
    Console.WriteLine(bookReview);
}