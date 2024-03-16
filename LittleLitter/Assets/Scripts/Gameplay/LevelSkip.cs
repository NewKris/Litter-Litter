using System;
using UnityEngine;

namespace CoffeeBara.Gameplay {
    public class LevelSkip : MonoBehaviour {
        public static event Action<Level> OnLoadLevel; 
        
        public void SkipLevel(int level) {
            OnLoadLevel?.Invoke((Level)level);
        }
    }
}