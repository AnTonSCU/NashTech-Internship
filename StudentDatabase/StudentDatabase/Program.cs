using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace StudentDatabase
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Birthplace { get; set; }
        public bool IsGraduated { get; set; }
        public int Age => DateTime.Now.Year - DateOfBirth.Year;

        public Member(string firstName, string lastName, string gender, string dob, string phoneNumber, string birthplace, bool isGraduated)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = DateTime.Parse(dob);
            PhoneNumber = phoneNumber;
            Birthplace = birthplace;
            IsGraduated = isGraduated;
        }

        public string FullName => $"{LastName} {FirstName}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Member> members = new List<Member>
            {
                new Member("John", "Doe", "Male", "1990-01-01", "1234567890", "New York", true),
                new Member("Jane", "Smith", "Female", "2000-05-12", "0987654321", "Los Angeles", false),
                new Member("Mike", "Brown", "Male", "1998-07-23", "1122334455", "Chicago", true),
                new Member("Anna", "White", "Female", "2002-08-14", "2233445566", "Ha Noi", false),
                new Member("Tom", "Green", "Male", "2001-09-15", "3344556677", "Houston", false),
                new Member("Kate", "Johnson", "Female", "1999-10-10", "4455667788", "San Francisco", true)
            };

            // 1. List of members who are Male
            //var males = members.Where(m => m.Gender == "Male").ToList();
            //Console.WriteLine("List of male members:");
            //males.ForEach(m => Console.WriteLine($"{m.FirstName} {m.LastName}"));
            List<Member> males = new List<Member>();
            Console.WriteLine("List of male members:");
            foreach (var member in members)
            {
                if (member.Gender == "Male")
                {
                    //males.Add(member)
                    Console.WriteLine($"{member.FirstName} {member.LastName}");
                }
            }

            // 2. The oldest member
            var oldest = members.OrderBy(m => m.DateOfBirth).First();
            Console.WriteLine($"\nThe oldest member is: {oldest.FirstName} {oldest.LastName}, Age: {oldest.Age}");

            // 3. List of full names
            var fullNames = members.Select(m => m.FullName).ToList();
            Console.WriteLine("\nList of full names:");
            fullNames.ForEach(name => Console.WriteLine(name));

            // 4. Lists based on birth year
            List<Member> born2000 = new List<Member>();
            List<Member> before2000 = new List<Member>();
            List<Member> after2000 = new List<Member>();

            foreach (var member in members)
            {
                switch (member.DateOfBirth.Year)
                {
                    case 2000:
                        born2000.Add(member);
                        break;
                    case <2000:
                        before2000.Add(member);
                        break;
                    case >2000:
                        after2000.Add(member);
                        break;
                }
            }
            
            void PrintMembers(string title, List<Member> members)
            {
                Console.WriteLine($"\n{title}");
                foreach (var member in members)
                {
                    Console.WriteLine($"{member.FirstName} {member.LastName}");
                }
            }

            PrintMembers("Members born in the year 2000:", born2000);
            PrintMembers("Members born before the year 2000:", before2000);
            PrintMembers("Members born after the year 2000:", after2000);
            
            
            // 5. First person born in Ha Noi
            var firstInHanoi = members.FirstOrDefault(m => m.Birthplace == "Ha Noi");
            if (firstInHanoi != null)
            {
                Console.WriteLine($"\nThe first person born in Ha Noi is: {firstInHanoi.FirstName} {firstInHanoi.LastName}");
            }
            else
            {
                Console.WriteLine("\nNo members were born in Ha Noi.");
            }
        }
    }
}