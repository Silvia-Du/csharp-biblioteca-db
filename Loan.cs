// See https://aka.ms/new-console-template for more information
public class Loan
{
    DateTime startDate;
    int duration;
    string name;
    string surname;
    Product product;

    public Loan( int duration, string name, string surname, Product product)
    {
        this.startDate = new DateTime();
        this.duration = duration;
        this.name = name;
        this.surname = surname;
        this.product = product;
    }

    public string Name { get { return name; } }

    public string Surname { get { return surname; } }

    public DateTime StartDate { get { return startDate; } }

    public int Duration { get { return duration; } }

    public Product Product { get { return product; } }


}


