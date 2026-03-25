namespace G_NET_33_OOP06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part1
            #region A1
            /*
             1-Abstraction means hiding complexity 
               and show only the features of the object.

            2-Encapsulation means protect data by controlling 
              who can access and modify it.

            3-When you play video game like Battle royal you shoot, move, reload
              but you don't know how bullet are calculated or 
              how the player move this is Abstraction 
            4-The player have heal, and number of bullets you can't change it 
              directly you only need to do an action to change it 
             */
            #endregion
            #region A2
            /*
             1-                 Abstraction                         Interface
            constructor          Yes                                No
            Inheritance         only one abstract class             Yes 
            Methods             Can have abstract +                 Usually only method declarations
                                concrete (implemented) methods
            Access Modifiers    Can use private, protected, public   Only public

            When to use Abstraction over Interface
            1-Classes share common state (fields)
            2-You want to provide default behavior
            3-There is a clear base class relationship
             */
            #endregion
            #region A3
            /*
             a-No,because abstract class can't have instantiated 
               because it meant to be base classes only.

             b-         PowerConsumption            Status              Label
             Override   must be overridden      Optional overriding    Forbidden

             Reason     every appliance has     Most appliances may    The logic is common  
                       different power usage    have special states.   for all appliances

            c-The output will be Standby because it didn't override it.
                        
             */
            #endregion
            #region A4
            /*
             a-It means splitting single class definition across multiple files
               Code organizing, Team work, Auto generated class.
             b-
               1- Partial method is a method that is declared in one part 
                  of partial class and can optional implemented in the other part.
               2-Yes, because it isn't implemented the compiler will remove it.
            c-
                1-Extension method is to add new method to existing
                type without modifying it.
              Rules: 1- must be static class. 2- must be static method.
                     3-The first parameter must use this.

            d-It will print 20.
             */
            #endregion
            #endregion

            #region Part2
            #region Error 
            //var ticket = new Ticket(); Cannot create an instance
            //of the abstract type or interface 'Ticket'
            #endregion

            var cinema = new Cinema("Hell");
            #region Report 
            var standard = new StandardTicket("Inception", 150, true, "A2");
            var vip = new VIPTicket("Avengers", 200, true, true);
            var imax = new IMAXTicket("Dune", 300, true, true);
            cinema.AddTicket(standard);
            cinema.AddTicket(vip);
            cinema.AddTicket(imax);
            cinema.PrintAllTickets();
            cinema.PrintTicketsPrices();
            #endregion

            #region Receipt
            Console.WriteLine("==== Extension Method: Receipt ====");
            Console.WriteLine(standard.GenerateReceipt());
            
            #endregion

            //Total Revenue 
            Console.WriteLine("==== Extension Method: Total Revenue ====");
            Ticket[] tickets = { vip, standard, imax };
            Console.WriteLine($"Total Revenue: {tickets.GetTotalRevenu()}");
            #endregion
        }
    }
}
