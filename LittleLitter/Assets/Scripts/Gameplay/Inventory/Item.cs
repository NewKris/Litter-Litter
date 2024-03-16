using UnityEngine;

namespace CoffeeBara.Gameplay.Inventory {
    public class Item : ScriptableObject {
        public Sprite image;
        public string displayName;
        public bool canGive;
        public int foodCount;
        public int joyCount;
    }
}