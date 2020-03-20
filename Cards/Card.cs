using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGLibraryProject
{
    public class Card
    {
        private uint id;
        private string name;
        private string[] colors;
        private string set;
        private string[] cost;
        private string equipable;
        private string[] cardTypes;
        private string[] keywords;
        private string description;
        private string power;
        private string toughness;
        public Card()
        {

        }

        public Card(uint _id,string _name,string[] _colors,string set,string[] cost,string equipable,string[] _cardTypes,string[] keywords,string description,string power, string toughness)
        {

        }

        public uint Id { set { id = value; } get { return id; } }
        public string Name { set { name = value; } get { return name; } }
        public string[] Colors { set { colors = value; } get { return colors; } }
        public string Set { set { set = value; } get { return set; } }
        public string[] Cost { set { cost= value; } get { return cost; } }
        public string Equipable { set { equipable = value; } get { return equipable; } }
        public string[] CardTypes { set { cardTypes = value; } get { return cardTypes; } }
        public string[] Keywords { set { keywords = value; } get { return keywords; } }
        public string Description { set { description = value; } get { return description; } }
        public string Power { set { power = value; }get { return power; } }
        public string Toughness { set { toughness = value; } get { return toughness; } }

        public new string ToString()
        {
            return "Name:" + Name + "\n" +
                       "Colors:" + string.Join(", ",Colors) + "\n" +
                       "Set:" + Set + "\n" +
                       "Cost:" + string.Join(", ", Cost) + "\n" +
                       "Equipable:" + Equipable + "\n" +
                       "CardTypes:" + string.Join(", ", CardTypes) + "\n" +
                       "Keywords:" + string.Join(", ", Keywords) + "\n" +
                       "Description:" + Description + "\n" +
                       "Power:" + Power + "\n" +
                       "Toughness:" + Toughness;
        }

    }
}
