using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_33_OOP06;

public static class TicketExtension
{
    public static string GenerateReceipt(this Ticket ticket)
    {
        return $"""
                ===================================
                         Cinema Receipt
                ===================================
                Ticket ID   : #{ticket.TicketId}
                Movie       : {ticket.MovieName}
                Type        : {ticket.GetType().Name}
                Base Price  : {ticket.Price:F2} EGP
                Final Price : {ticket.CalcualteFinalPrice():F2} EGP
                Booked      : {(ticket.IsBooked ? "Yes" : "No")}
                Ref         : {ticket.BookingRef}
                ===================================
                """;
    }
    
    public static decimal GetTotalRevenu(this Ticket[] tickets)
    {
        decimal totalRevenu = 0;
        foreach (var item in tickets)
        {
            if (item.IsBooked)
            {
                totalRevenu += item.CalcualteFinalPrice();
            }
        }
        return totalRevenu;
    }
}
