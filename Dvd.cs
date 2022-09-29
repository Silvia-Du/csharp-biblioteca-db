// See https://aka.ms/new-console-template for more information
public class Dvd : Product
{
    string serialNumber;
    int totMinutes;
    public Dvd(string title, int year, string serialNumber) : base(title, year)
    {
        this.serialNumber = serialNumber;
    }


    public string SerialNumber { get; set; }

    public int Timers { get; set; }
}


