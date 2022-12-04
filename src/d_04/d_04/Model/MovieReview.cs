using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace d_04.Model
{
    public class MoveReview : ISearchable
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonIgnore]
        public bool IsBest => CriticsPick;

        [JsonPropertyName("mpaa_rating")]
        public string MpaaRating { get; set; }
        
        [JsonConverter(typeof(BoolConverter))]
        [JsonPropertyName("critics_pick")]
        public bool CriticsPick { get; set; }

        [JsonPropertyName("byline")]
        public string Byline { get; set; }

        [JsonPropertyName("headline")]
        public string Headline { get; set; }

        [JsonPropertyName("summary_short")]
        public string SummaryShort { get; set; }

        [JsonPropertyName("publication_date")]
        public string PublicationDate { get; set; }

        [JsonPropertyName("opening_date")]
        public string OpeningDate { get; set; }

        [JsonPropertyName("date_updated")]
        public string DateUpdated { get; set; }

        [JsonPropertyName("link")]
        public Link Link { get; set; }

        [JsonPropertyName("multimedia")]
        public Multimedia Multimedia { get; set; }

        public override string ToString()
        {
            var ret = $@"- {Title.ToUpper()} {(CriticsPick ? "[NYT critic’s pick]" : "")}{Environment.NewLine}" + 
                      $"{SummaryShort}{Environment.NewLine}" +
                      $"{Link.Url}";
            return ret;
        }
    }
    
    public class Link
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("suggested_link_text")]
        public string SuggestedLinkText { get; set; }
    }

    public class Multimedia
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("src")]
        public string Src { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
    

    public class MoveReviewsJson
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }

        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }

        [JsonPropertyName("num_results")]
        public int NumResults { get; set; }

        [JsonPropertyName("results")]
        public List<MoveReview> MoveReviews { get; set; }
    }

    public class BoolConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            reader.GetInt32() != 0;

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) =>
            writer.WriteNumberValue(value ? 1 : 0);
    }
}