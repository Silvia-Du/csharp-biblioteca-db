// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
string connectionString = "Data Source=localhost;Initial Catalog=db_biblioteca;Integrated Security=True";
SqlConnection sqlConnection = new(connectionString);


Console.WriteLine("inserisci un nuovo prodotto[1], Inserisci un nuovo utente[2]");
string resp = Console.ReadLine();

switch (resp)
{
    case "1":
        setNewDocuments();
        break;

    case "2":
        setNewUser();
        break;

}
Console.WriteLine("vuoi stampare tutta la lista degli articoli?[y/n]");
string resp2 = Console.ReadLine();
switch (resp2)
{
    case "y":
        printAllDocuments();
        break;

    case "n":
        //setNewUser();
        Console.WriteLine("cerca un libro per titolo");
        //implementazione
        break;

}

void printAllDocuments()
{
    try
    {
        sqlConnection.Open();
        string queryReader = $"SELECT * FROM documents";
        SqlCommand cmd = new(queryReader, sqlConnection);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string code = reader.GetString(1);
            string title = reader.GetString(2);
            int year = reader.GetInt32(3);
            Book newBook = new(title, year, code);
            Console.WriteLine($"Titolo: {newBook.Title}, Anno d'uscita:{newBook.Year}, isbn:{newBook.Isbn}");
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        sqlConnection.Close();

    }
}



Biblioteca boolTeca = new Biblioteca("boolTeca");
boolTeca.books.Add(new Book("Moby Dick", 1851, "12345678"));
boolTeca.books.Add(new Book("Le parole sono fineste oppure muri", 1999, "12456789"));
Console.WriteLine(boolTeca.books);


//boolTeca.dvds.Add(new Dvd("Big Fish", 2003, "12356"));
//boolTeca.dvds.Add(new Dvd("Edward mani di forbici", 2003, "145236"));
//Console.WriteLine(boolTeca.Dvds);



//boolTeca.users.Add(new User("Ugo", "DeUghi", "ugo@gmail.com", "password1", 389789654));
//boolTeca.users.Add(new User("Dudi", "DeDudi", "dudi@gmail.com", "password2", 389789656));
//Console.WriteLine(boolTeca.User);



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

//GENERARE NUOVO UTENTE
void setNewUser()
{
    try
    {
        sqlConnection.Open();
        Console.WriteLine("Inserisci il nome");
        string? name = Console.ReadLine();
        Console.WriteLine("Inserisci il cognome");
        string? surname = Console.ReadLine();
        Console.WriteLine("Inserisci l'email");
        string? email = Console.ReadLine();
        Console.WriteLine("Inserisci la password");
        string? password = Console.ReadLine();
        Console.WriteLine("Inserisci il numero di telefono");
        string? telephone = Console.ReadLine();

        string queryNewUser = $"INSERT INTO users (name, surname, email, password, telephone) VALUES (@name, @surname, @email, @password, @telephone);";
        SqlCommand cmd2 = new(queryNewUser, sqlConnection);

        cmd2.Parameters.Add(new SqlParameter("@name", name));
        cmd2.Parameters.Add(new SqlParameter("@surname", surname));
        cmd2.Parameters.Add(new SqlParameter("@email", email));
        cmd2.Parameters.Add(new SqlParameter("@password", password));
        cmd2.Parameters.Add(new SqlParameter("@telephone", telephone));

        int affectedRows2 = cmd2.ExecuteNonQuery();
        Console.WriteLine(" user salvato nel db");

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        //throw;
    }
    finally
    {
        sqlConnection.Close();
    }
}

//GENERARE NUOVO prodotto
void setNewDocuments()
{
    try
    {
        sqlConnection.Open();
        Console.WriteLine("Inserisci il codice");
        string? code = Console.ReadLine();
        Console.WriteLine("Inserisci il titolo");
        string? title = Console.ReadLine();
        Console.WriteLine("Inserisci l'anno d'uscita");
        int year = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Inserisci l'autore");
        string? author = Console.ReadLine();
        Console.WriteLine("Inserisci il tipo");
        string? type = Console.ReadLine();

        string queryInsert = $"INSERT INTO documents (code, title, year, author, type) VALUES (@code, @title, @year, @author, @type);";
        SqlCommand cmd = new(queryInsert, sqlConnection);

        cmd.Parameters.Add(new SqlParameter("@code", code));
        cmd.Parameters.Add(new SqlParameter("@title", title));
        cmd.Parameters.Add(new SqlParameter("@year", year));
        cmd.Parameters.Add(new SqlParameter("@author", author));
        cmd.Parameters.Add(new SqlParameter("@type", type));

        int affectedRows = cmd.ExecuteNonQuery();
        Console.WriteLine("salvato nel db");

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        //throw;
    }
    finally
    {
        sqlConnection.Close();
    }
}











