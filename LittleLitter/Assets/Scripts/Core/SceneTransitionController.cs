using System.Collections;
using CoffeeBara.Util;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CoffeeBara.Core
{
    public class SceneTransitionController : MonoBehaviour, IPersistentComponent
    {
        private static SceneTransitionController Instance;
        private static bool IsLocked;

        public BlackScreen blackScreen;

        public static void TransitionToScene(GameScene scene)
        {
            Instance?.StartCoroutine(Instance.TransitionToSceneAsync(scene));
        }

        public static void LockTransition() {
            IsLocked = true;
        }

        public static void UnlockTransition() {
            IsLocked = false;
        }
        
        public void Init()
        {
            Instance = this;
            IsLocked = false;
            StartCoroutine(blackScreen.FadeIn());
        }

        private IEnumerator TransitionToSceneAsync(GameScene scene) {
            yield return blackScreen.FadeOut(0.5f, 0.1f);

            AsyncOperation loadScene = SceneManager.LoadSceneAsync((int)scene);
            while (!loadScene.isDone) yield return null;
            while (IsLocked) yield return null;

            yield return blackScreen.FadeIn(0.5f, 0.1f);
        }
    }
}