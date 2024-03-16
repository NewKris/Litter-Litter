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
            _currentLevel = save.level;
            AsyncOperation loadLevel = SceneManager.LoadSceneAsync((int)save.level, LoadSceneMode.Additive);
            while (!loadLevel.isDone) await Task.Delay(100);
        }

        private void Awake() {
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

            AsyncOperation unloadLevel = SceneManager.UnloadSceneAsync((int)_currentLevel);
            while (!unloadLevel.isDone) yield return null;

            AsyncOperation loadLevel = SceneManager.LoadSceneAsync((int)level, LoadSceneMode.Additive);
            while (!loadLevel.isDone) yield return null;

            _currentLevel = level;
            
            yield return blackScreen.FadeIn(0.5f, 0.1f);
        }
    }
}