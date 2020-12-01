using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TK_ExamPrac
{

    class Program
    {
        public enum BookGuestHouse
        {
            BookRoom = 1,
            ViewCustomerTotals,
            ViewBookingsMade,
            ViewCustomerThatWantBreafastService,
            ViewGrandTotallOfAllBookings,
            ViewCustomerFromExpensiveAndLeastExpensive,
            Exit

        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Please choose an option");
            Console.WriteLine("1.Book a room");
            Console.WriteLine("2.View all customer individual totals ");
            Console.WriteLine("3.View how many bookings have been made");
            Console.WriteLine("4.View how many customers that want breakfast service");
            Console.WriteLine("5.View grand total of all bookings added together");
            Console.WriteLine("6.View all total for inividual customer from most expensive to least expensive");
        }

        public enum BookingType
        {
            BasicRoom = 1,
            Luxaurious

        }

        class Booking
        {
            public readonly BookingType bookingType;
            public readonly uint NumOfNights;
            public readonly bool BrealfastInTheMorning;
            public readonly double total;

            public Booking(BookingType bookingType, uint numOfNights, bool brealfastInTheMorning)
            {
                this.bookingType = bookingType;
                NumOfNights = numOfNights;
                BrealfastInTheMorning = brealfastInTheMorning;
                total = CalculateTotal();
            }

            public double CalculateTotal()
            {
                var breakfastamount = (BrealfastInTheMorning == true) ? 60 * NumOfNights : 0;
                if (bookingType == BookingType.BasicRoom)
                {

                    return (140 * NumOfNights) + breakfastamount;
                }
                else if (bookingType == BookingType.Luxaurious)
                {
                    return (400 * NumOfNights) + breakfastamount;
                }
                return 0;
            }


            public override string ToString()
            {
                return $"Booking [ Booking Type: {bookingType}, Number Of Nights: {NumOfNights}, Breakfast in the Morning Option: {BrealfastInTheMorning}, Total: {total}]";
            }
        }
        static void Main(string[] args)
        {

            Booking[] bookings = new Booking[15];
            int currentNumberOfElements = 0;


            int proceed = 1;
            while (proceed != 0)
            {
                DisplayMenu();
                BookGuestHouse displayer = (BookGuestHouse)int.Parse(Console.ReadLine());


                switch (displayer)
                {
                    case BookGuestHouse.BookRoom:
                        {
                            Console.WriteLine("Enter YES if you would like to make a booking or No if you do not");
                            string Input = Console.ReadLine();
                            if (Input.ToLower() == "yes")
                            {

                                Booking currentBooking;
                                for (int i = currentNumberOfElements; i < bookings.Length; i++)
                                {
                                    Console.WriteLine("Please choose a type of room to book");
                                    Console.WriteLine("1. Basic Room (R140)");
                                    Console.WriteLine("2. Luxaurious (R400)");
                                    string EnterInput = Console.ReadLine();
                                    BookingType bookingType = BookingType.BasicRoom;
                                    if (EnterInput == "Basic Room" || EnterInput == "1")
                                    {
                                        bookingType = BookingType.BasicRoom;
                                    }
                                    else if (EnterInput == "Luxaurious" || EnterInput == "2")
                                    {
                                        bookingType = BookingType.Luxaurious;
                                    }

                                    Console.WriteLine("How many nights?(Enter numeral)");
                                    uint numberOfNights = uint.Parse(Console.ReadLine());



                                    Console.WriteLine("Would you like to recieve breakfast each morning Y/N");
                                    string UserResponse = Console.ReadLine();
                                    bool BreakfastFlag = false;
                                    if (UserResponse == "Y" || UserResponse == "y")
                                    {
                                        BreakfastFlag = true;
                                    }
                                    else if (UserResponse == "N" || UserResponse == "n")
                                    {
                                        BreakfastFlag = true;
                                    }
                                    bookings[i] = new Booking(bookingType, numberOfNights, BreakfastFlag);
                                    currentNumberOfElements++;
                                    Console.WriteLine("Would you like to continue Y/N");
                                    string Response = Console.ReadLine();

                                    if (Response == "N" || Response == "n")
                                    {
                                        break;

                                    }

                                }
                                if (currentNumberOfElements >= 14)
                                {
                                    Console.WriteLine("All rooms are filled, try again later");
                                    break;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Room not booked");
                            }
                        }

                        break;
                    case BookGuestHouse.ViewCustomerTotals:
                        {
                            for (int i = 0; i < bookings.Length; i++)
                            {
                                if (bookings[i] == null) continue;
                                else
                                    Console.WriteLine("Booking: " + (i + 1) + " Total:" + bookings[i].total);
                            }
                        }
                        break;
                    case BookGuestHouse.ViewBookingsMade:
                        for (int i = 0; i < bookings.Length; i++)
                        {
                            if (bookings[i] == null) continue;
                            else
                                Console.WriteLine("Booking: " + (i + 1) + "With Booking Data: " + bookings[i].ToString());
                        }
                        break;
                    case BookGuestHouse.ViewCustomerThatWantBreafastService:
                        for (int i = 0; i < bookings.Length; i++)
                        {
                            if (bookings[i] == null) continue;
                            else
                                if (bookings[i].BrealfastInTheMorning == true)
                                Console.WriteLine(bookings[i].ToString());
                        }
                        break;
                    case BookGuestHouse.ViewGrandTotallOfAllBookings:
                        double grandTotal = 0;
                        foreach (var item in bookings)
                        {
                            if (item == null) continue;
                            grandTotal += item.total;
                        }
                        break;
                    case BookGuestHouse.ViewCustomerFromExpensiveAndLeastExpensive:
                        Booking temp;
                        for (int i = 0; i < bookings.Length; i++)
                        {
                            if (bookings[i] == null) continue;
                            for (int j = 0; j < bookings.Length - 1; j++)
                            {
                                if (bookings[j] == null || bookings[j + 1] == null) continue;
                                if (bookings[j].total > bookings[j + 1].total)
                                {
                                    temp = bookings[j];
                                    bookings[j] = bookings[j + 1];
                                    bookings[j + 1] = temp;
                                }
                            }
                        }
                        break;
                    case BookGuestHouse.Exit:
                        Environment.Exit(0);

                        break;
                    default:
                        break;

                }
                Console.WriteLine("would You like to contine press any number to continue and 0 to end");
                proceed = int.Parse(Console.ReadLine());

            }
            Console.ReadLine();
        }



    }
}
