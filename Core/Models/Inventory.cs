using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Inventory
    {
        private readonly int id; // idk how to implement this, do i even want it here?

        public string Name { get; private set; }
        public Item[] Items;

        public Inventory()
        {
            Name = string.Empty;
            Items = new Item[6]; // would need a special constructor for diff size
        }

        public bool MoveItem(int from, int to)
        {
            if (from == to || from < 0 || from > 5 || to < 0 || to > 5) return false;
            
            if (Items[from] != null)
            {
                Item item = Items[from];
                if (Items[to] == null)
                {
                    Items[to] = item;
                    Items[from] = null;
                }
                else
                {
                    Item item2 = Items[to];
                    Items[to] = item;
                    Items[from] = item2;
                }
                return true;
            }
            else { return false; }
        }
        public bool AddItem(Item item)
        {
            int stack = 0;
            int itemCount = 0;
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] != null)
                {
                    itemCount++;
                    if (Items[i] == item) { stack++; }
                }
            }

            if (stack < item.MaxStack && itemCount < 6)
            {
                for (int i = 0; i < Items.Length; i++)
                {
                    if (Items[i] == null)
                    {
                        Items[i] = item; return true;
                    }
                }
                Console.WriteLine("Error: system thought there was space but item wasn't added");
                return false;
            }
            else { return false; }
        }
        public bool RemoveItem(int index)
        {
            if (Items[index] == null)
            {
                Console.WriteLine("Error: tried to remove non-existent item");
                return false;
            }
            
            Items[index] = null;
            return true;
        }
        public void ClearItems()
        {
            Items = new Item[6];
        }

        // can create copy-paste export and import functions here
    }
}
