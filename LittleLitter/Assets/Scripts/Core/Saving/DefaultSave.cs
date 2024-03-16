using UnityEngine;

namespace CoffeeBara.Core.Saving {
    [CreateAssetMenu(menuName = "Default Save")]
    public class DefaultSave : ScriptableObject {
        public Save save;
    }
}