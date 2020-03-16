using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGLibraryProject
{
    public class Inventory
    {
        Dictionary<string, Card> cards = new Dictionary<string, Card>();
        public Inventory()
        {
            Add(new string[] { "Prey Upon", "G", "Throne of Eldrain", "G", "false", "Sorcery", "", "Target creature you control fights target creature you don't control", "", "" });
            //Add(new string[] { "Prey Upon U", "G", "Throne of Eldrain", "G", "false", "Sorcery", "", "Target creature you control fights target creature you don't control", "", "" });
            Add(new string[] { "Portcullis Vine", "G", "Throne of Eldrain", "G", "false", "Creature,Plant,Wall", "Defender", "[2],Tap,Sacrifice a creature with defender: Draw Card", "0", "3" });
            Add(new string[] { "Feed the Clan","[1],G","Kahns of Tarkir","G","false","Instant","","You gain 5 life. Ferocious-You gain 10 life instead if you control a creature with power 4 or greater","",""});
        }

        public void Add(object[] args)
        {
            Card card = new Card();
            //card.Id = UInt32.Parse((string)args[0]);
            card.Name = (string)args[0];
            card.Colors = args[1].ToString().Split(',');
            card.Set = (string)args[2];
            card.Cost = args[3].ToString().Split(',');
            card.Equipable = args[4].ToString().ToLower().Equals("false") ? false : true;
            card.CardTypes = args[5].ToString().Split(',');
            card.Keywords = args[6].ToString().Split(',');
            card.Description = (string)args[7];
            card.Power = (string)args[8];
            card.Toughness = (string)args[9];
            cards.Add(card.Name, card);
        }
        public string ShowCard(string cardname)
        {
            return cards[cardname].ToString();
        }
        public List<Card> GetByName(string cardname)
        {
            var result = cards.Where(kvp => kvp.Key.Contains(cardname)).Select(kvp => kvp.Value).ToList();
            return result;
        }
        public List<Card> GetByColor(string[] colors)
        {
            List<Card> result = new List<Card>();
            foreach(var item in cards)
            {
                if (item.Value.Colors.SequenceEqual(colors))
                {
                    result.Add(item.Value);
                }
            }
            return result;
        }
        public List<Card> GetBySet(string set)
        {
            var result = cards.Where(kvp => kvp.Value.Set.Contains(set)).Select(kvp => kvp.Value).ToList();
            return result;
        }
        public List<Card> GetByCost(string[] cost)
        {
            List<Card> result = new List<Card>();
            foreach (var item in cards)
            {
                if (item.Value.Colors.SequenceEqual(cost))
                {
                    result.Add(item.Value);
                }
            }
            return result;
        }
    }
}
