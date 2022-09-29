// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
string connectionString = "Data Source=localhost;Initial Catalog=db_biblioteca;Integrated Security=True";
SqlConnection sqlConnection = new(connectionString);

try
{
    //test in lettura
    sqlConnection.Open();
    string query = $"SELECT * FROM documents";
    SqlCommand cmd = new(query, sqlConnection);
    SqlDataReader dataReader = cmd.ExecuteReader();
    

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    sqlConnection.Close();
}



Biblioteca boolTeca = new Biblioteca("boolTeca");
boolTeca.books.Add(new Book("Moby Dick", 1851, "12345678"));
boolTeca.books.Add(new Book("Le parole sono fineste oppure muri", 1999, "12456789"));
Console.WriteLine(boolTeca.books);


boolTeca.dvds.Add(new Dvd("Big Fish", 2003, "12356"));
boolTeca.dvds.Add(new Dvd("Edward mani di forbici", 2003, "145236"));
Console.WriteLine(boolTeca.Dvds);



boolTeca.users.Add(new User("Ugo", "DeUghi", "ugo@gmail.com", "password1", 389789654));
boolTeca.users.Add(new User("Dudi", "DeDudi", "dudi@gmail.com", "password2", 389789656));
Console.WriteLine(boolTeca.User);



Console.WriteLine("Benvenuto, sei della biblioteca?y-n");
string response = Console.ReadLine().ToLower();

bool start = false;
while (!start)
{

    if (response == "y")
    {
        Console.WriteLine("Inserisci la password");
        string stringToCheck = Console.ReadLine();
        bool getAccess = boolTeca.checkPassword(stringToCheck);
        if (getAccess)
        {
            start = true;
        }
        else
        {
            Console.WriteLine("sei della biblioteca?y-n");
            response = Console.ReadLine().ToLower();
        }
    }
    else if(response == "n")
    {
        start=true;
    }
    else
    {
        Console.WriteLine("risposta non valida");
        
    }
    
}


if (response == "n")
{
    Console.WriteLine("Cosa stai cercando?dvd - libri");
    response = Console.ReadLine().ToLower();
    string userString;
    Product r;
    if(response == "dvd")
    {
        Console.WriteLine("Scrivi 1 per ricerca titolo, 2 per ricerca codice");
        response = Console.ReadLine().ToLower();
        if(response == "1")
        {
            Console.WriteLine("Scrivi il titolo da cercare");
            userString = Console.ReadLine().ToLower();
            r = boolTeca.SetByTitle("Dvd", userString);
            Console.WriteLine($"Titolo:{r.Title}, anno di pubblicazione : {r.Year}");

        }
        else if(response == "2")
        {
            Console.WriteLine("Scrivi il codice da cercare");
            userString = Console.ReadLine().ToLower();
            r = boolTeca.SetByCode("Dvd", userString);
            Console.WriteLine($"Titolo:{r.Title}, anno di pubblicazione : {r.Year}");
        }
        else
        {
            Console.WriteLine("Risposta non valida");
        }

    }
    else if(response == "libri")
    {
        Console.WriteLine("Scrivi 1 per ricerca titolo, 2 per ricerca codice");
        response = Console.ReadLine().ToLower();
        if (response == "1")
        {
            Console.WriteLine("Scrivi il titolo da cercare");
            userString = Console.ReadLine().ToLower();
            r = boolTeca.SetByTitle("libri", userString);
            Console.WriteLine($"Titolo:{r.Title}, anno di pubblicazione : {r.Year}");

        }
        else if (response == "2")
        {
            Console.WriteLine("Scrivi il codice da cercare");
            userString = Console.ReadLine().ToLower();
            r = boolTeca.SetByCode("libri", userString);
            Console.WriteLine($"Titolo:{r.Title}, anno di pubblicazione : {r.Year}");
            setLoan(r);
        }
        else
        {
            Console.WriteLine("Risposta non valida");
        }
    }
    else
    {
        Console.WriteLine("risposta non valida");
    }
}

void setLoan(Product response)
{
    string userString;
    string userName;
    string userSurame;

    if (response.Title != "non trovato")
    {
        Console.WriteLine("Vuoi noleggiare?[1] vuoi restituire?[2]");
        userString = Console.ReadLine().ToLower();
        if (userString == "1")
        {
            Console.WriteLine("Sei un'utente registrato? [y / n]");
            userString = Console.ReadLine().ToLower();
            if(userString == "y")
            {
                Console.WriteLine("Inserisci Il tuo nome");
                userName = Console.ReadLine().ToLower();
                Console.WriteLine("Inserisci Il tuo cognome");
                userSurame = Console.ReadLine().ToLower();
                bool isUser = boolTeca.GetCheckUser(userName, userSurame);
                if (isUser)
                {

                    boolTeca.SetLoan( userName, userSurame, response);
                }

            }
        }

    }
}









