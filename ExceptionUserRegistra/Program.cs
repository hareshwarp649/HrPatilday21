﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionUserRegistra
{
    internal class Program
    {
      
            public static void UserRegisration()
            {
                bool Continue = true;
                while (Continue)
                {
                    Console.WriteLine("\nChoose Option to Validate with their specified Pattern");
                    Console.WriteLine("1 = First Name\n2 = Last Name\n3 = Email ID\n4 = Mobile Number\n5 = Password\n6 = Sample Email Check\n0 = Exit");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            Continue = false;
                            break;
                        case 1:
                            Console.WriteLine("Enter First Name");
                            string firstName = Console.ReadLine();
                            Console.WriteLine(UserRegistration.ValidateFirstName(firstName));
                            break;
                        case 2:
                            Console.WriteLine("Enter Last Name");
                            string lastName = Console.ReadLine();
                            Console.WriteLine(UserRegistration.ValidateLastName(lastName));
                            break;
                        case 3:
                            Console.WriteLine("Enter Email ID");
                            string email = Console.ReadLine();
                            Console.WriteLine(UserRegistration.ValidateEmailID(email));
                            break;
                        case 4:
                            Console.WriteLine("Enter Mobile Number");
                            string mobileNumber = Console.ReadLine();
                            Console.WriteLine(UserRegistration.ValidateMobileNumber(mobileNumber));
                            break;
                        case 5:
                            Console.WriteLine("Enter PassWord");
                            string password = Console.ReadLine();
                            Console.WriteLine(UserRegistration.ValidatePassword(password));
                            break;
                        case 6:
                            UserRegistration.SampleEmail();
                            break;
                        default:
                            Console.WriteLine("Enter Correct Option!");
                            break;
                    }
                }
            }
            
            static void Main(string[] args)
            {
                Console.WriteLine("Welcome to User Registration Program");
                UserRegisration();
                Console.ReadLine();
            }
        
    }
}