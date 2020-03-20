using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGLibraryProject
{
    public class Controller
    {
        private delegate void Command(params string[] args);
        private Dictionary<string, Command> commands;
        private InventoryManager inventoryManager;

        public Controller()
        {

        }

        public void Initialize()
        {
            commands = new Dictionary<string, Command>();
            inventoryManager = new InventoryManager();
            bindFuncToDel();
        }

        public void ProcessInput(string input)
        {
            input.ToLower();

            if (input.Length > 0 && input[0].Equals('/'))
            {
                input = input.Substring(1);
                string[] inputSplit = input.Split(' ');
                if (commands.ContainsKey(inputSplit[0]))
                {
                    List<string> args = new List<string>();
                    for (int i = 0; i < inputSplit.Length - 1; i++)
                    {
                        args.Add(inputSplit[1 + i]);
                    }
                    commands[inputSplit[0]](args.ToArray());
                }
                else
                {
                    Console.WriteLine("This command does not exist");
                }
            }
        }

        private void search(string[] args)
        {
            string[] searchList = inventoryManager.Search(args);
            Console.WriteLine("Here are your search results:");
            if (searchList.Length > 0)
            {
                if (searchList[0].Equals("This card is not in our library"))
                {
                    Console.WriteLine(searchList[0]);
                }
                else if (!searchList[0].StartsWith("Name:"))
                {
                    for (int i = 0; i < searchList.Length; i++)
                    {
                        Console.WriteLine("\t-" + searchList[i]);
                    }
                } 
                else
                {
                    for (int i = 0; i < searchList.Length; i++)
                    {
                        Console.WriteLine(searchList[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }

        private void add(string[] args)
        {
            inventoryManager.Add(args[0]);
        }

        private void remove(object[] args)
        {
            Console.WriteLine("Remove has not been implemented yet");
            Console.WriteLine("Here is your param {0}", args[0]);
        }

        private void showAllCards(object[] args)
        {
            string[] array = inventoryManager.ShowAllCards();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("\t-" + array[i]);
            }
        }

        private void bindFuncToDel()
        {
            //bind manualy for now
            Command cmd = search;
            mapFuncToString("search", cmd);
            cmd = add;
            mapFuncToString("add", cmd);
            cmd = remove;
            mapFuncToString("remove", cmd);
            cmd = showAllCards;
            mapFuncToString("list", cmd);
        }

        private void mapFuncToString(string key, Command command)
        {
            commands[key] = command;
        }
    }
}
