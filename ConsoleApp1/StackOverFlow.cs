using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ConsoleApp1
{

    public class LevelItem
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int ChildCount { get; set; }
        public int ParentID { get; set; }
        public int Level { get; set; }
        public List<LevelItem> ItemList;
    }

    public class GetItems
    {
        public List<LevelItem> GetItemList()
        {
            List<LevelItem> items = new List<LevelItem>
            {
                new LevelItem(){ ItemID = 70, Name="Home", ChildCount = 1, Level = 0, ParentID = 0 },
                new LevelItem(){ ItemID = 71, Name="Pages", ChildCount = 1, Level = 0, ParentID = 0 },
                new LevelItem(){ ItemID = 72, Name="Pages II", ChildCount = 1, Level = 0, ParentID = 0 },
                new LevelItem(){ ItemID = 77, Name="My World", ChildCount = 1, Level = -1, ParentID = 0 },
                new LevelItem(){ ItemID = 79, Name="Level 3", ChildCount = 0, Level = 0, ParentID =  0},
                new LevelItem(){ ItemID = 73, Name="Page III", ChildCount = 0, Level = 0, ParentID = 71},
                new LevelItem(){ ItemID = 74, Name="Page IV", ChildCount = 0, Level = 0, ParentID = 70 },
                new LevelItem(){ ItemID = 75, Name="Level 1", ChildCount = 1, Level = 0, ParentID = 72 },
                new LevelItem(){ ItemID = 76, Name="Hello 1", ChildCount = 1, Level = 0, ParentID = 77 },
                new LevelItem(){ ItemID = 78, Name="Level 2", ChildCount = 0, Level = -1, ParentID = 76 }
            };
            return items;
        }

        public LevelItem GetParrent(List<LevelItem> items, int parrentId)
        {
            return items.FirstOrDefault(item => item.ItemID == parrentId);
        }

        public List<LevelItem> ConvertToNestedItems(List<LevelItem> items)
        {
            //Add children to parents
            foreach (var item in items)
            {
                var parrent = GetParrent(items, item.ParentID);

                if (parrent == null)
                {
                    continue;
                }

                if (parrent.ItemList == null)
                {
                    parrent.ItemList = new List<LevelItem>();
                }

                parrent.ItemList.Add(item);
            }

            //Retrive list of root node and return it
            var itemIds = items.Select(item => item.ItemID);
            var rootItems = items.Where(item => !itemIds.Contains(item.ParentID)).ToList();
            return rootItems;
        }

        public List<LevelItem> ConvertToHierarchyItems(List<LevelItem> items)
        {
            foreach (var item in items)
            {
                var children = items.Where(x => x.ParentID == item.ItemID).ToList();

                if (children.Any())
                {
                    item.ItemList = children;
                }
            }

            items.RemoveAt(1);

            var result = new List<LevelItem>();
            var itemProcessed = 0;

            while (itemProcessed < items.Count)
            {

            }

            return result;
        }


    }
}
