using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeBara.Core;
using CoffeeBara.Core.Saving;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoffeeBara.Gameplay {
    public class GameplayManager : MonoBehaviour {
        public DefaultSave defaultSave;
        
        private async void Awake() {
            SceneTransitionController.LockTransition();

            ILoadTask[] tasks = GetComponentsInChildren<ILoadTask>();

            foreach (ILoadTask loadTask in tasks) {
                await loadTask.Load(defaultSave.save);
            }
            
            SceneTransitionController.UnlockTransition();
        }
    }
}