using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGLibraryProject
{
    public class Controller
    {
        private delegate void Command(params object[] args);
        private Dictionary<string, Command> commands;

        public Controller()
        {

        }
        public void Initialize()
        {
            commands = new Dictionary<string, Command>();
            bindFuncToDel();
        }
        public void ProcessInput(string input)
        {
            input.ToLower();
            if (input[0].Equals('/'))
            {
                input = input.Substring(1);
                string[] inputSplit = input.Split(' ');
                if (commands.ContainsKey(inputSplit[0]))
                {
                    List<object> args = new List<object>();
                    for(int i =0;i<inputSplit.Length-1;i++)
                    {
                        args.Add(inputSplit[1+i]);
                    }
                    commands[inputSplit[0]](args.ToArray());
                }
            }
        }
        private static void search(object[] args)
        {
            Console.WriteLine("Search has not been implemented yet");
            Console.WriteLine("Here is your param {0}", args[0]);
        }
        private void add(object[] args)
        {
            Console.WriteLine("Add has not been implemented yet");
            Console.WriteLine("Here is your param {0}", args[0]);
        }
        private void remove(object[] args)
        {
            Console.WriteLine("Remove has not been implemented yet");
            Console.WriteLine("Here is your param {0}", args[0]);
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

        }
        private void mapFuncToString(string key,Command command)
        {
            commands[key] = command;
        }
    }
}
