using System;
using System.Collections;
using System.Threading.Tasks;
using CoffeeBara.Core.Saving;
using CoffeeBara.Util;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoffeeBara.Gameplay {
    public class LevelLoader : MonoBehaviour, ILoadTask {
        public BlackScreen blackScreen;

        private Level _currentLevel;
        
        public async Task Load(Save save) {
            AsyncOperation loadLevel = SceneManager.LoadSceneAsync((int)save.level);
            while (!loadLevel.isDone) await Task.Delay(100);
        }
        
        private void Awake() {
            (this as ILoadTask).QueueTask(this);
            LevelSkip.OnLoadLevel += LoadLevel;
        }

        private void OnDestroy() {
            LevelSkip.OnLoadLevel -= LoadLevel;
        }

        private void LoadLevel(Level level) {
            StartCoroutine(LoadLevelAsync(level));
        }

        private IEnumerator LoadLevelAsync(Level level) {
            yield return blackScreen.FadeOut(0.5f, 0.1f);

            
            
            yield return blackScreen.FadeIn(0.5f, 0.1f);
        }
    }
}