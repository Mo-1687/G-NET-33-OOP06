using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_33_OOP06;

public abstract class Ticket
{
    private static int _totalTickets = 0;

    public string MovieName { get; set; }

    public bool IsBooked { get; set; }

    public decimal Price { get; set; }

    public int TicketId { get; }

    protected Ticket(string movieName, decimal price, bool book)
    {
        if (string.IsNullOrEmpty(movieName))
            throw new ArgumentNullException();
        if (price < 0)
            throw new ArgumentOutOfRangeException();
        MovieName = movieName;
        Price = price;
        IsBooked = book;
        TicketId = ++_totalTickets;
    }

    public static int GetTotalTickets() => _totalTickets;

    public decimal SetPrice(decimal price)
    {
        return Price = price;
    }

    public decimal SetPrice(decimal basePrice, decimal multiplier)
    {
        return Price = basePrice * multiplier;
    }

    public string BookingRef
    {
        get { return $"Booking Ref {TicketId}: BK-{TicketId}"; }
    }

    public abstract decimal CalcualteFinalPrice();

    public override string ToString() =>
        $"[Ticket #{TicketId}] Movie: {MovieName} | " +
        $"Price: {Price} | Price After Tax: {CalcualteFinalPrice()}";

    public virtual void PrintInfo()
    {
        Console.Write($"[ Ticket ID: {TicketId}] ");
        Console.Write($"Movie Name: {MovieName} | ");
        Console.Write($"Price: {Price} | ");
        Console.Write($"Total (14% tax): {CalcualteFinalPrice()} | ");
        Console.Write($"Booked: {IsBooked} ");
    }

    public abstract Ticket Clone(string newMovieName);
}

public class StandardTicket : Ticket
{
    public string SeatNumber { get; set; }

    public StandardTicket(string movieName, decimal price, bool book, string seatNumber)
        : base(movieName, price, book)
    {
        SeatNumber = seatNumber;
    }

    public override string ToString() =>
        base.ToString() + $" | Seat: {SeatNumber}";

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($" | Seat: {SeatNumber}");
    }

    public override Ticket Clone(string newMovieName)
    {
        return new StandardTicket(newMovieName, Price, IsBooked, SeatNumber);
    }

    public override decimal CalcualteFinalPrice()
    {
        return Price * 1.14m;
    }
}

public class VIPTicket : Ticket
{
    public bool LoungeAccess { get; set; }
    public decimal ServiceFee { get; } = 50m;

    public VIPTicket(string movieName, decimal price, bool book, bool loungeAccess)
        : base(movieName, price, book)
    {
        LoungeAccess = loungeAccess;
    }

    public override string ToString() =>
        base.ToString() +
        $" | Lounge Access: {LoungeAccess} | Service Fee: {ServiceFee}";

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($" | Lounge Access: {LoungeAccess} | Service Fee: {ServiceFee}");
    }

    public override Ticket Clone(string newMovieName)
    {
        return new VIPTicket(newMovieName, Price, LoungeAccess, IsBooked);
    }

    public override decimal CalcualteFinalPrice()
    {
        return Price * 1.14m;
    }
}


public class IMAXTicket : Ticket
{
    public bool Is3D { get; set; }

    public IMAXTicket(string movieName, decimal price, bool book, bool is3D)
        : base(movieName, is3D ? price + 30 : price, book)
    {
        Is3D = is3D;
    }

    public override string ToString() =>
        base.ToString() + $" | 3D: {Is3D}";

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($" | 3D: {Is3D}");
    }

    public override Ticket Clone(string newMovieName)
    {
        return new IMAXTicket(newMovieName, Price, Is3D, IsBooked);
    }

    public override decimal CalcualteFinalPrice()
    {
        return Price * 1.14m;
    }
}

public partial class Cinema
{
    public string CinemaName { get; set; } = default!;
    private Projector _projector = new Projector();
    private readonly Ticket[] _tickets = new Ticket[20];
    private int _count = 0;
    public Cinema(string cinemaName)
    {
        CinemaName = cinemaName;

    }

    public void AddTicket(Ticket t)
    {
        if (_count >= _tickets.Length)
        {
            Console.WriteLine("Cinema is full — cannot add more tickets.");
            return;
        }
        _tickets[_count++] = t;
        Console.WriteLine($"Ticket added: {t.MovieName} (ID #{t.TicketId})");
    }

    public void CancelTicket(int id)
    {
        foreach (var item in _tickets)
        {
            if (item.TicketId == id)
            {
                item.IsBooked = false;
                item.PrintInfo();
                break;
            }
        }
    }

    public void OpenCinema()
    {
        Console.WriteLine($"\n{CinemaName} is now OPEN");
        _projector.Start();
    }

    public void CloseCinema()
    {
        Console.WriteLine();
        _projector.Stop();
        Console.WriteLine($"\n{CinemaName} is now CLOSED");
    }
}

public class Projector
{
    public bool IsRunning { get; private set; }

    public void Start()
    {
        IsRunning = true;
        Console.WriteLine("Projector started.");
    }

    public void Stop()
    {
        IsRunning = false;
        Console.WriteLine("Projector stopped.");
    }
}


public static class BookingHelper
{
    private static int _counter = 0;
    public static string CalcGroupDiscount(int numberOfTickets, double pricePerTicket)
    {
        double total = numberOfTickets * pricePerTicket;
        if (numberOfTickets >= 5)
        {
            total *= 0.90;
        }

        return $"Group Discount({numberOfTickets} tickets * {pricePerTicket}EGP): {total}EGP " +
            $"{(numberOfTickets >= 5 ? "10% appplied" : "")}";
    }
    public static string GenerateBookingReference()
    {
        _counter++;
        return $"BK-{_counter}";
    }
}
