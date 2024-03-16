using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeBara.Core;
using CoffeeBara.Core.Saving;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoffeeBara.Gameplay {
    public class GameplayManager : MonoBehaviour {
        private static Queue<ILoadTask> PendingLoadTasks;

        public DefaultSave defaultSave;
        
        private async void Awake() {
            SceneTransitionController.LockTransition();

            ILoadTask.OnLoadTaskSpawned += QueueLoadTask;
            PendingLoadTasks = new Queue<ILoadTask>();

            while (PendingLoadTasks.Count > 0) {
                await PendingLoadTasks.Dequeue().Load(defaultSave.save);
            }
            
            ILoadTask.OnLoadTaskSpawned -= QueueLoadTask;
            
            SceneTransitionController.UnlockTransition();
        }
        
        public void QueueLoadTask(ILoadTask task) {
            PendingLoadTasks.Enqueue(task);
        }
    }
}