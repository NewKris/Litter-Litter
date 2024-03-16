using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeBara.Core.Saving;
using UnityEngine;

namespace CoffeeBara.Gameplay.Inventory
{
    public class Inventory : MonoBehaviour, ILoadTask {
        private List<InventoryItem> _items;
        
        public async Task Load(Save save) {
        }
    }

    public struct InventoryItem {
        public Item item;
        public int count;
    }
}
