using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_33_OOP06;

public partial class Cinema
{
    public void PrintAllTickets()
    {
        Console.WriteLine($"\n===== {CinemaName} — Ticket List =====");
        if (_count == 0)
        {
            Console.WriteLine("No tickets available.");
            return;
        }
        for (int i = 0; i < _count; i++)
        {
            Console.Write($"{i + 1}");
            _tickets[i].PrintInfo();
        }
        Console.WriteLine("======================================");


    }

    public Ticket GetTicket(int id)
    {

        foreach (var item in _tickets)
        {
            if (item.TicketId == id)
            {
                return item;
            }
        }
        Console.WriteLine("There is no ticket with this id!");
        return null;
    }

    public static void ProcessTicket(Ticket t)
    {
        if (t == null)
        {
            Console.WriteLine("Invalid ticket.");
            return;
        }
        t.PrintInfo();
    }

    public void PrintTicketsPrices()
    {
        Console.WriteLine("======= Final Price Per Ticket =======");
        foreach (var item in _tickets)
        {
            if (item == null) break;
            Console.WriteLine($"{item.GetType().Name} => Final price: {item.CalcualteFinalPrice():F2} EGP");
        }
    }
}
