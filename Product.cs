// See https://aka.ms/new-console-template for more information
public class Product
{
    
    bool isAvailable = true;
    

    public Product(string title, int year)
    {
        this.Title = title.ToLower();
        this.Year = year;
    
    }

    public string Title{ get; set; }

    public int Year{ get; set; }

    public string Sector{ get; set; }

    public string Shelf { get; set; }

    public string AuthorName{ get; set; }

    public string AuthorSurname { get; set; }



}


