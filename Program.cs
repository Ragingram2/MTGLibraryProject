using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Sheets.v4.Data;

namespace MTGLibraryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            bool running = true;
            Controller controller = new Controller();
            controller.Initialize();
            Console.WriteLine("Welcome to the MTG Library Application, please enter a command");
            while (running)
            {
                input = Console.ReadLine();
                if (input.ToLower().Equals("exit"))
                {
                    running = false;
                    break;
                }
                controller.ProcessInput(input);
            }
        }
    }
}
