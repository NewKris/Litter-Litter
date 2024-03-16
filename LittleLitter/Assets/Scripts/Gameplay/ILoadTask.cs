using System;
using System.Threading.Tasks;

namespace CoffeeBara.Gameplay {
    public interface ILoadTask {
        public static event Action<ILoadTask> OnLoadTaskSpawned;
        public Task Load();
    }
}