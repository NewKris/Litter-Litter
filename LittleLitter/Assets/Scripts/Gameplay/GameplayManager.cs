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
            AsyncOperation loadLevel = SceneManager.LoadSceneAsync((int)defaultSave.save.level, LoadSceneMode.Additive);
            while (!loadLevel.isDone) await Task.Delay(100);

            while (PendingLoadTasks.Count > 0) {
                await PendingLoadTasks.Dequeue().Load();
            }
            
            ILoadTask.OnLoadTaskSpawned -= QueueLoadTask;
            
            SceneTransitionController.UnlockTransition();
        }
        
        public void QueueLoadTask(ILoadTask task) {
            PendingLoadTasks.Enqueue(task);
        }
    }
}