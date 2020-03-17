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
        List<GoogleSheetRow> rows = new List<GoogleSheetRow>();
        List<GoogleSheetCell> cells;
        Vector white = new Vector();
        public Inventory()
        {
            white.x = 1;
            white.y = 1;
            white.z = 1;
            var gsh = new GoogleSheetsHelper("MTGLibraryProject-0d5d6f0d5bf2.json", "1H-EbfU7mq4Gv2_YAkFpLiMD8tPikqhgUGda1iWvJr3Q");
            var row1 = new GoogleSheetRow();
            cells = new List<GoogleSheetCell>()
            {
            new GoogleSheetCell() { CellValue = "Id", BackgroundColor =white},
            new GoogleSheetCell() { CellValue = "Name", BackgroundColor = white },
            new GoogleSheetCell() { CellValue = "Colors", BackgroundColor = white },
            new GoogleSheetCell() { CellValue = "Set", BackgroundColor = white },
            new GoogleSheetCell() { CellValue = "Cost", BackgroundColor = white },
            new GoogleSheetCell() { CellValue = "Equipable", BackgroundColor = white },
            new GoogleSheetCell() { CellValue = "Cards Types", BackgroundColor = white },
            new GoogleSheetCell() { CellValue = "Keywords", BackgroundColor = white },
            new GoogleSheetCell() { CellValue = "Description", BackgroundColor = white },
            new GoogleSheetCell() { CellValue = "Power", BackgroundColor = white },
            new GoogleSheetCell() { CellValue = "Toughness", BackgroundColor = white }
            };
            row1.Cells.AddRange(cells);
            rows.Add(row1);
            //Add(new string[] { "Prey Upon", "G", "Throne of Eldrain", "G", "false", "Sorcery", "", "Target creature you control fights target creature you don't control", "", "" });
            ////Add(new string[] { "Prey Upon U", "G", "Throne of Eldrain", "G", "false", "Sorcery", "", "Target creature you control fights target creature you don't control", "", "" });
            //Add(new string[] { "Portcullis Vine", "G", "Throne of Eldrain", "G", "false", "Creature,Plant,Wall", "Defender", "[2],Tap,Sacrifice a creature with defender: Draw Card", "0", "3" });
            //Add(new string[] { "Feed the Clan", "[1],G", "Kahns of Tarkir", "G", "false", "Instant", "", "You gain 5 life. Ferocious-You gain 10 life instead if you control a creature with power 4 or greater", "", "" });
            gsh.AddCells(new GoogleSheetParameters() { SheetName = "Sheet1", RangeColumnStart = 1, RangeRowStart = 1 }, rows);
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
            //cards.Add(card.Name, card);
            var row = new GoogleSheetRow();
            cells = new List<GoogleSheetCell>()
            {
            new GoogleSheetCell() { CellValue = card.Id.ToString(), BackgroundColor =white},
            new GoogleSheetCell() { CellValue = card.Name, BackgroundColor = white },
            new GoogleSheetCell() { CellValue = string.Join(", ",card.Colors), BackgroundColor = white },
            new GoogleSheetCell() { CellValue = card.Set, BackgroundColor = white },
            new GoogleSheetCell() { CellValue = string.Join(", ",card.Cost), BackgroundColor = white },
            new GoogleSheetCell() { CellValue = card.Equipable.ToString(), BackgroundColor = white },
            new GoogleSheetCell() { CellValue = string.Join(", ",card.CardTypes), BackgroundColor = white },
            new GoogleSheetCell() { CellValue = string.Join(", ",card.Keywords), BackgroundColor = white },
            new GoogleSheetCell() { CellValue = card.Description, BackgroundColor = white },
            new GoogleSheetCell() { CellValue = card.Power, BackgroundColor = white },
            new GoogleSheetCell() { CellValue = card.Toughness, BackgroundColor = white }
            };
            row.Cells.AddRange(cells);
            rows.Add(row);
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
