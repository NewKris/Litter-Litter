using System;
using System.Threading.Tasks;
using CoffeeBara.Core.Saving;

namespace CoffeeBara.Gameplay {
    public interface ILoadTask {
        public Task Load(Save save);
    }
}
