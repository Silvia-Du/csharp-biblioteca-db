// See https://aka.ms/new-console-template for more information


using System.ComponentModel;

public class Biblioteca
{
    string name;
    string password = "passwordB";
    public List<Book> books;
    public List<Dvd> dvds;
    public List<Loan> loans;
    public List<User> users;
    Product productNull = new Product("non trovato", 00000);


    public Biblioteca(string name)
    {
        this.name = name;
        books = new List<Book>();
        dvds = new List<Dvd>();
        loans = new List<Loan>();
        users = new List<User>();
    }

    public bool checkPassword(string password)
    {
        return this.password.Equals(password);
    }

    public List<Book> Books { get; set; }
        
    public List<Dvd> Dvds { get; }

    public List<Loan> Loans { get; }

    public List<User> User { get; }


    public Product SetByTitle(string type, string title)
    {

        //correz
        Product research = null;
        if (type == "dvd")
        {
            foreach (Dvd dvd in dvds)
            {
                if (dvd.Title == title)
                {
                    research = dvd;
                    break;
                }

            }
        }
        else if (type == "libri")
        {
            foreach (Book book in books)
            {
                if (book.Title == title)
                {

                    research = book;
                    break;
                }

            }
        }

        return research;
    }

    public Product SetByCode(string type, string code)
    {
        //correz
        Product research = null;
        if (type == "dvd")
        {
            foreach (Dvd dvd in dvds)
            {
                if (dvd.SerialNumber == code)
                {
                    research = dvd;
                    break;
                }
               

            }
        }
        else if (type == "libri")
        {
            foreach (Book book in books)
            {
                if (book.Isbn == code)
                {

                    research = book;
                    break;
                }

            }
        }
        
        return research;
    }

    public string SetLoan(string userName, string userSurname, Product product)
    {
        loans.Add(new Loan(5, userName, userSurname, product));
        return "prenotazione avvenuta con successo";
    }


    public void SetAddBook(Book prodotto)
    {
        books.Add(prodotto);
        Console.WriteLine(books);
    }

    //get

    public bool GetCheckUser(string userName, string UserSurname)
    {
        bool isUser = false;
        foreach(User user in users)
        {
            if (UserSurname == user.Surname && userName == user.Name)
            {
                isUser = true;
                break;
;           }
            
        }
        return isUser;
    }

    





}


