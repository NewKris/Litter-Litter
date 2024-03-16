using System;
using CoffeeBara.Core;
using UnityEngine;

namespace CoffeeBara.Menu {
    public class ExitGame : MonoBehaviour {
        private void Start() {
            GameManager.ExitGame();
        }
    }
}