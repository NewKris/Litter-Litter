using System;
using UnityEngine;

namespace CoffeeBara.Gameplay.Inventory {
    [CreateAssetMenu(menuName = "Recipe")]
    public class Recipe : ScriptableObject {
        public Ingredient[] ingredients;
    }

    [Serializable]
    public struct Ingredient {
        public Item item;
        public int count;
    }
}