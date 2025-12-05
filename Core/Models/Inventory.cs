using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Items;

namespace Core.Models
{
    public class Inventory
    {
        private readonly int max_items = 6;
        private readonly int id; // idk how to implement this, do i even want it here?

        public string Name { get; private set; }
        public IReadOnlyList<Item> Items 
        { 
            get
            {
                return items; 
            } 
        }
        private Item[] items;

        public Inventory()
        {
            Name = string.Empty;
            items = new Item[max_items];
        }

        public bool MoveItem(int from, int to)
        {
            int max_index = max_items - 1;
            if (from == to || from < 0 || from > max_index || to < 0 || to > max_index) return false;
            
            if (Items[from] != null)
            {
                Item item = Items[from];
                if (Items[to] == null)
                {
                    items[to] = item;
                    items[from] = null;
                }
                else
                {
                    Item item2 = Items[to];
                    items[to] = item;
                    items[from] = item2;
                }
                return true;
            }
            else { return false; }
        }
        public bool AddItem(Item item)
        {
            int stack = 0;
            int itemCount = 0;
            for (int i = 0; i < max_items; i++)
            {
                if (items[i] != null)
                {
                    itemCount++;
                    if (items[i] == item) { stack++; }
                }
            }

            if (stack < item.MaxStack && itemCount < 6)
            {
                for (int i = 0; i < max_items; i++)
                {
                    if (items[i] == null)
                    {
                        items[i] = item; return true;
                    }
                }
                Console.WriteLine("Error: system thought there was space but item wasn't added");
                return false;
            }
            else { return false; }
        }
        public bool RemoveItem(int index)
        {
            if (items[index] == null)
            {
                Console.WriteLine("Error: tried to remove non-existent item");
                return false;
            }
            
            items[index] = null;
            return true;
        }
        public void ClearItems()
        {
            items = new Item[max_items];
        }

        // can create copy-paste export and import functions here
    }
}
