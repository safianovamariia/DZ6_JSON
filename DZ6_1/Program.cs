using System.Text;
using System.Text.Json;
Console.OutputEncoding = Encoding.UTF8;

string path = "books.json";
List<Book> books;

using (FileStream fs = new FileStream(path, FileMode.Open))
{
    books = await JsonSerializer.DeserializeAsync<List<Book>>(fs);
}

foreach (var book in books)
{
    Console.WriteLine($"{book.PublishingHouseId} - {book.Title} - {book.PublishingHouse.Id} - {book.PublishingHouse.Name} - {book.PublishingHouse.Adress}");
}

class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Adress { get; set; } = "";
}

class Book
{
    public int PublishingHouseId { get; set; }
    public string Title { get; set; } = "";
    public PublishingHouse PublishingHouse { get; set; } = new PublishingHouse();
}