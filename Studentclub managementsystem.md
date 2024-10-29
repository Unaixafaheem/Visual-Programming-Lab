# Visual-Programming-Lab
using System;
using System.Collections.Generic;

namespace StudentClubManagementSystem
{
   
    public class ClubRole
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string ContactInfo { get; set; }

        public ClubRole(string name, string role, string contactInfo)
        {
            Name = name;
            Role = role;
            ContactInfo = contactInfo;
        }
    }

   
    public class Society
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public List<string> Events { get; set; } = new List<string>();

        public virtual void AddActivity(string activity)
        {
            Events.Add(activity);
        }

        public virtual void ListEvents()
        {
            Console.WriteLine($"Events for {Name}:");
            foreach (var ev in Events)
            {
                Console.WriteLine($"- {ev}");
            }
        }
    }

    
    public class FundedSociety : Society
    {
        public double FundingAmount { get; set; }

        public FundedSociety(string name, string contact, double fundingAmount)
        {
            Name = name;
            Contact = contact;
            FundingAmount = fundingAmount;
        }
    }

    
    public class NonFundedSociety : Society
    {
        public NonFundedSociety(string name, string contact)
        {
            Name = name;
            Contact = contact;
        }
    }

    
    public class StudentClub
    {
        private double budget;
        public ClubRole President { get; set; }
        public ClubRole VicePresident { get; set; }
        public ClubRole GeneralSecretary { get; set; }
        public ClubRole FinanceSecretary { get; set; }
        public List<Society> Societies { get; set; } = new List<Society>();

        public StudentClub(double initialBudget)
        {
            budget = initialBudget;
        }

        public void RegisterSociety(Society society)
        {
            Societies.Add(society);
            Console.WriteLine($"Society '{society.Name}' registered successfully.");
        }

        public void DispenseFunds()
        {
            foreach (var society in Societies)
            {
                if (society is FundedSociety fundedSociety)
                {
                    Console.WriteLine($"Dispensing ${fundedSociety.FundingAmount} to {fundedSociety.Name}");
                }
                else
                {
                    Console.WriteLine($"{society.Name} is not funded.");
                }
            }
        }

        public void DisplaySocieties()
        {
            Console.WriteLine("List of Societies:");
            Console.WriteLine("1.Techbit Society: ");
            Console.WriteLine("2.Sports Society");
            Console.WriteLine("3.Literary Society");
            foreach (var society in Societies)
            {
                Console.WriteLine($"- {society.Name} (Contact: {society.Contact})");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StudentClub club = new StudentClub(10000);

            Console.Write("Enter President's name: ");
            string presidentName = Console.ReadLine();
            Console.Write("Enter President's contact: ");
            string presidentContact = Console.ReadLine();
            club.President = new ClubRole(presidentName, "President", presidentContact);

            Console.Write("Enter Vice President's name: ");
            string vicePresidentName = Console.ReadLine();
            Console.Write("Enter Vice President's contact: ");
            string vicePresidentContact = Console.ReadLine();
            club.VicePresident = new ClubRole(vicePresidentName, "Vice President", vicePresidentContact);

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Register Society");
                Console.WriteLine("2. Add Event to Society");
                Console.WriteLine("3. Dispense Funds");
                Console.WriteLine("4. Display Societies");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Society name: ");
                        string societyName = Console.ReadLine();
                        Console.Write("Enter Society contact: ");
                        string societyContact = Console.ReadLine();
                        Console.Write("Is this a funded society? (yes/no): ");
                        string funded = Console.ReadLine();
                        if (funded.ToLower() == "yes")
                        {
                            Console.Write("Enter funding amount: ");
                            double fundingAmount = Convert.ToDouble(Console.ReadLine());
                            club.RegisterSociety(new FundedSociety(societyName, societyContact, fundingAmount));
                        }
                        else
                        {
                            club.RegisterSociety(new NonFundedSociety(societyName, societyContact));
                        }
                        break;
                    



                    case 2:
                        club.DisplaySocieties();
                        Console.Write("Enter Society name to add event: ");
                        string societyNameToAddEvent = Console.ReadLine();
                        Society societyToAddEvent = club.Societies.Find(s => s.Name == societyNameToAddEvent);
                        if (societyToAddEvent != null)
                        {
                            Console.Write("Enter event name: ");
                            string eventName = Console.ReadLine();
                            societyToAddEvent.AddActivity(eventName);
                            Console.WriteLine("Event added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Society not found.");
                        }
                        break;
                    case 3:
                        club.DispenseFunds();
                        break;
                    case 4:
                        club.DisplaySocieties();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
