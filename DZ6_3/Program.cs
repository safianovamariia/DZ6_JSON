using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
Console.OutputEncoding = Encoding.UTF8;

string path = "books.json";
List<Book> books;

using (FileStream fs = new FileStream(path, FileMode.Open))
{
    books = await JsonSerializer.DeserializeAsync<List<Book>>(fs);
}

var options = new JsonSerializerOptions
{
    WriteIndented = true,
    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
};

Console.WriteLine(JsonSerializer.Serialize(books, options));

class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Adress { get; set; } = "";
}

class Book
{
    public int PublishingHouseId { get; set; }

    [JsonPropertyName("Name")]
    public string Title { get; set; } = "";

    public PublishingHouse PublishingHouse { get; set; } = new PublishingHouse();
}