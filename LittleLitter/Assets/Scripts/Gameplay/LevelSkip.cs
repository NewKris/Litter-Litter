using System;
using UnityEngine;

namespace CoffeeBara.Gameplay {
    public class LevelSkip : MonoBehaviour {
        public static event Action<Level> OnLoadLevel; 
        
        public void SkipLevel(Level level) {
            OnLoadLevel?.Invoke(level);
        }
    }
}