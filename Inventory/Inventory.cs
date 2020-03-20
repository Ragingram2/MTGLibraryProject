using System;
using System.Collections.Generic;
using System.Dynamic;
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
        GoogleSheetsHelper gsh;
        Vector white = new Vector();
        public Inventory()
        {
            white.x = 1;
            white.y = 1;
            white.z = 1;
            Refresh();
        }

        public void Initialize()
        {
            gsh = new GoogleSheetsHelper("MTGLibraryProject-0d5d6f0d5bf2.json", "1H-EbfU7mq4Gv2_YAkFpLiMD8tPikqhgUGda1iWvJr3Q");
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
        }

        public void Refresh()
        {
            Initialize();
            cards.Clear();
            var gsp = new GoogleSheetParameters() { RangeColumnStart = 1, RangeRowStart = 1, RangeColumnEnd = 11, RangeRowEnd = 130, FirstRowIsHeaders = true, SheetName = "Sheet1" };
            var rowValues = gsh.GetDataFromSheet(gsp);
            foreach (ExpandoObject rowValue in rowValues)
            {
                cards.Add(rowValue.ToArray()[1].Value.ToString(), new Card()
                {
                    Id = UInt32.Parse(rowValue.ToArray()[0].Value.ToString()),
                    Name = rowValue.ToArray()[1].Value.ToString(),
                    Colors = rowValue.ToArray()[2].Value.ToString().Split(','),
                    Set = rowValue.ToArray()[3].Value.ToString(),
                    Cost = rowValue.ToArray()[4].Value.ToString().Split(','),
                    Equipable = rowValue.ToArray()[5].Value.ToString(),
                    CardTypes = rowValue.ToArray()[6].Value.ToString().Split(','),
                    Keywords = rowValue.ToArray()[7].Value.ToString().Split(','),
                    Description = rowValue.ToArray()[8].Value.ToString(),
                    Power = rowValue.ToArray()[9].Value.ToString(),
                    Toughness = rowValue.ToArray()[10].Value.ToString()
                });
            }
            gsh.AddCells(new GoogleSheetParameters() { SheetName = "Sheet1", RangeColumnStart = 1, RangeRowStart = 1 }, rows);
        }

        public void Add(object[] args)
        {
            Card card = new Card();
            //card.Id = UInt32.Parse((string)args[0]);
            card.Name = args[0].ToString();
            card.Colors = args[1].ToString().Split(',');
            card.Set = args[2].ToString();
            card.Cost = args[3].ToString().Split(',');
            card.Equipable = args[4].ToString().ToLower();
            card.CardTypes = args[5].ToString().Split(',');
            card.Keywords = args[6].ToString().Split(',');
            card.Description = args[7].ToString();
            card.Power = args[8].ToString();
            card.Toughness = args[9].ToString();
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
            Refresh();
        }
        public string[] ShowAllCards()
        {
            //Console.WriteLine(cards.);
            return cards.Keys.ToArray<string>();
        }
        public string ShowCard(string cardname)
        {
            if(cards.ContainsKey(cardname))
            {
                return cards[cardname].ToString();
            }
            return "This card is not in our library";
        }
        public List<Card> GetByName(string cardname)
        {
            var result = cards.Where(kvp => kvp.Key.Contains(cardname)).Select(kvp => kvp.Value).ToList();
            return result;
        }
        public List<Card> GetByColor(string[] colors)
        {
            List<Card> result = new List<Card>();
            foreach (var item in cards)
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
                if (item.Value.Cost.SequenceEqual(cost))
                {
                    result.Add(item.Value);
                }
            }
            return result;
        }
        public List<Card> GetByEquipable(string equipable)
        {
            var result = cards.Where(kvp => kvp.Value.Equipable.Contains(equipable.ToUpper())).Select(kvp => kvp.Value).ToList();
            return result;
        }
        public List<Card> GetByCardTypes(string[] cardTypes)
        {
            List<Card> result = new List<Card>();
            foreach (var item in cards)
            {
                if (item.Value.CardTypes.SequenceEqual(cardTypes))
                {
                    result.Add(item.Value);
                }
            }
            return result;
        }
        public List<Card> GetByDescription(string description)
        {
            var result = cards.Where(kvp => kvp.Value.Description.Contains(description)).Select(kvp => kvp.Value).ToList();
            return result;
        }
        public List<Card> GetByPower(string power)
        {
            var result = cards.Where(kvp => kvp.Value.Power.Contains(power)).Select(kvp => kvp.Value).ToList();
            return result;
        }
        public List<Card> GetByToughness(string toughness)
        {
            var result = cards.Where(kvp => kvp.Value.Toughness.Contains(toughness)).Select(kvp => kvp.Value).ToList();
            return result;
        }
    }
}
