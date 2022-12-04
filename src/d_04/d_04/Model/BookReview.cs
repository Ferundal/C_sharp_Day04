using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace d_04.Model
{
    public class BookReview : ISearchable
    {
        [JsonIgnore] public string Title => Books[0].Title;
        [JsonIgnore] public bool IsBest => Rank == 1;
        
        [JsonPropertyName("list_name")]
        public string ListName { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("bestsellers_date")]
        public string BestsellersDate { get; set; }

        [JsonPropertyName("published_date")]
        public string PublishedDate { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("rank_last_week")]
        public int RankLastWeek { get; set; }

        [JsonPropertyName("weeks_on_list")]
        public int WeeksOnList { get; set; }

        [JsonPropertyName("asterisk")]
        public int Asterisk { get; set; }

        [JsonPropertyName("dagger")]
        public int Dagger { get; set; }

        [JsonPropertyName("amazon_product_url")]
        public string AmazonProductUrl { get; set; }

        [JsonPropertyName("isbns")]
        public List<Isbn> Isbns { get; set; }

        [JsonPropertyName("book_details")]
        public List<Book> Books { get; set; }

        [JsonPropertyName("reviews")]
        public List<Review> Reviews { get; set; }

        public override string ToString()
        {
            var res = $"{Books[0].Title} by {Books[0].Author} [{Rank} on NYT's {ListName}]{Environment.NewLine}" +
                      $"{Books[0].Description}{Environment.NewLine}" +
                      $"{AmazonProductUrl}";
            return res;
        }
    }
    
    
    public class Book
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("contributor")]
        public string Contributor { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("contributor_note")]
        public string ContributorNote { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("age_group")]
        public string AgeGroup { get; set; }

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        [JsonPropertyName("primary_isbn13")]
        public string PrimaryIsbn13 { get; set; }

        [JsonPropertyName("primary_isbn10")]
        public string PrimaryIsbn10 { get; set; }
    }

    public class Isbn
    {
        [JsonPropertyName("isbn10")]
        public string Isbn10 { get; set; }

        [JsonPropertyName("isbn13")]
        public string Isbn13 { get; set; }
    }

    public class Review
    {
        [JsonPropertyName("book_review_link")]
        public string BookReviewLink { get; set; }

        [JsonPropertyName("first_chapter_link")]
        public string FirstChapterLink { get; set; }

        [JsonPropertyName("sunday_review_link")]
        public string SundayReviewLink { get; set; }

        [JsonPropertyName("article_chapter_link")]
        public string ArticleChapterLink { get; set; }
    }

    public class BookReviewsJson
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }

        [JsonPropertyName("num_results")]
        public int NumResults { get; set; }

        [JsonPropertyName("last_modified")]
        public DateTime LastModified { get; set; }

        [JsonPropertyName("results")]
        public List<BookReview> BookReviews { get; set; }
    }

}