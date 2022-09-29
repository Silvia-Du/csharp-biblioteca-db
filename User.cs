// See https://aka.ms/new-console-template for more information
public class User
{

    //costruttore
    public User(string name, string surname, string eMail, string password, int telephone)
    {
        this.Name = name.ToLower();
        this.Surname = surname.ToLower();
        this.EMail = eMail;
        this.Password = password;
        this.Telephone = telephone;
    }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string EMail { get; set;  }

    public int Telephone { get; set; }

    public string Password { get; set; }
}


