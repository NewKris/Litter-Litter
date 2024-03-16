using System;
using CoffeeBara.Core.Configuration;
using UnityEngine;

namespace CoffeeBara.Gameplay.Scavenge {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerCharacter : MonoBehaviour {
        [Header("Movement")]
        public float moveSpeed;
        
        private Rigidbody2D _rigidBody;
        private PlayerControls _controls;

        private void Awake() {
            _rigidBody = GetComponent<Rigidbody2D>();
            _controls = new PlayerControls();
            _controls.Locomotion.Enable();
        }

        private void Update() {
            Vector2 velocity = _controls.Locomotion.Move.ReadValue<Vector2>() * moveSpeed;

            _rigidBody.velocity = velocity;
        }
    }
}