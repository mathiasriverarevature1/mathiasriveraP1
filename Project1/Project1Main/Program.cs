using System;
using BusinessLayer;
using Models;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
        
        UserLogic userLogic = new UserLogic();
        Console.WriteLine("Welcome to the ticket reimbursmnent system. \nPlease login with your username and password. \n");
        Console.Write("Username:");
        Console.Write("Password:");


           //User login or register? How does that work?

        Console.WriteLine($"Thank you for logging in UserName. \nAs of now you are classified as a (emp/man) and have these options: ");
           
           //User Actions:

           //SUBORDINATE can view tickets or make new ticket

           //if viewing then display status and info

           //if making then insert creating of new ticker



           //MANAGER can view unsolved tickets or solved tickets

           //if viewing solved then just display ticket along with status

           //if viewing unsolved then display ticket along with choices



        }
    }
}
