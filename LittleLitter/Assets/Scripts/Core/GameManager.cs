using System;
using UnityEngine;

namespace CoffeeBara.Core
{
    public class GameManager : MonoBehaviour {
        private static GameManager Instance;

        public static void ExitGame() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        
        private void Awake() {
            if (Instance) {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start() {
            IPersistentComponent[] persistentComponents = GetComponentsInChildren<IPersistentComponent>();
            foreach (IPersistentComponent component in persistentComponents) {
                component.Init();
            }
        }
    }
}
