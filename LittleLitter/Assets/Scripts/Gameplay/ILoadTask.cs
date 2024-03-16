using System;
using System.Threading.Tasks;
using CoffeeBara.Core.Saving;

namespace CoffeeBara.Gameplay {
    public interface ILoadTask {
        public static event Action<ILoadTask> OnLoadTaskSpawned;
        public Task Load(Save save);

        public void QueueTask(ILoadTask loadTask) {
            OnLoadTaskSpawned?.Invoke(loadTask);
        }
    }
}
