using System;
using CoffeeBara.Core;
using UnityEngine;

namespace CoffeeBara.Menu
{
    public class SplashScreenController : MonoBehaviour
    {
        public float waitTime = 2;

        private bool _done = false;
        private float _timer = 0;

        private void Update()
        {
            _timer += Time.deltaTime;
            
            if (_timer < waitTime || _done) return;

            _done = true;
            SceneTransitionController.TransitionToScene(GameScene.MAIN_MENU);

        }
    }
}
