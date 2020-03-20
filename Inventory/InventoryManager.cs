using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGLibraryProject
{
    public class InventoryManager
    {
        Inventory inventory;
        public InventoryManager()
        {
            inventory = new Inventory();
        }

        public string[] Search(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].Equals("-n"))
                {
                    List<string> output = new List<string>();
                    var cards = inventory.GetByName(args[1]);
                    for (int i = 0; i < cards.Count; i++)
                    {
                        output.Add(cards[i].Name);
                    }
                    return output.ToArray();
                }
                else if (args[0].Equals("-c"))
                {
                    List<string> output = new List<string>();
                    var cards = inventory.GetByColor(args[1].Split(','));
                    for (int i = 0; i < cards.Count; i++)
                    {
                        output.Add(cards[i].Name);
                    }
                    return output.ToArray();
                }
                else if (args[0].Equals("-s"))
                {
                    List<string> output = new List<string>();
                    var cards = inventory.GetBySet(args[1]);
                    for (int i = 0; i < cards.Count; i++)
                    {
                        output.Add(cards[i].Name);
                    }
                    return output.ToArray();
                }
                else
                {
                    string name = "";
                    for (int i = 0; i < args.Length; i++)
                    {
                        if (i != args.Length - 1)
                        {
                            name += args[i] + " ";
                        }
                        else
                        {
                            name += args[i];
                        }
                    }
                    List<string> output = new List<string>();
                    output.Add(inventory.ShowCard(name));
                    return output.ToArray();
                }

            }
            return new string[0];
        }

        public void Add(string cardname)
        {
            List<string> cardProperties = new List<string>();
            string input;
            cardProperties.Add(cardname);

            Console.Write("Colors: ");
            input = Console.ReadLine();
            cardProperties.Add(input);

            Console.Write("Set: ");
            input = Console.ReadLine();
            cardProperties.Add(input);

            Console.Write("Cost: ");
            input = Console.ReadLine();
            cardProperties.Add(input);

            Console.Write("Equipable?: ");
            input = Console.ReadLine();
            cardProperties.Add(input);

            Console.Write("CardTypes: ");
            input = Console.ReadLine();
            cardProperties.Add(input);

            Console.Write("Keywords: ");
            input = Console.ReadLine();
            cardProperties.Add(input);

            Console.Write("Description: ");
            input = Console.ReadLine();
            cardProperties.Add(input);

            inventory.Add(cardProperties.ToArray());
        }

        public void Remove(string args)
        {

        }

        public string[] ShowAllCards()
        {
            return inventory.ShowAllCards();
        }
    }
}
