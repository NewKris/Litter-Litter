using CoffeeBara.Core;
using UnityEngine;

namespace CoffeeBara.Menu {
    public class MainMenuController : MonoBehaviour {
        public void StartGame() {
            SceneTransitionController.TransitionToScene(GameScene.GAMEPLAY);
        }
        
        public void ExitGame() {
            SceneTransitionController.TransitionToScene(GameScene.EXIT_GAME);
        }
    }
}