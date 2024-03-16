using System;
using CoffeeBara.Core.Configuration;
using UnityEngine;

namespace CoffeeBara.Gameplay.Scavenge {
    [RequireComponent(typeof(CharacterController))]
    public class PlayerCharacter : MonoBehaviour {
        [Header("Movement")]
        public float moveSpeed;
        public float turnSpeed;
        
        [Header("Jump")]
        public float jumpHeight;
        public float jumpTime;

        private float _gravity;
        private float _jumpVelocity;
        private float _verticalVelocity;
        private float _angularVelocity;
        private CharacterController _characterController;

        private void Awake() {
            float t = jumpTime * 0.5f;
            _gravity = (-2 * jumpHeight) / (t * t);
            _jumpVelocity = (2 * jumpHeight) / t;
            _characterController = GetComponent<CharacterController>();
        }

        private void Update() {
            _verticalVelocity += _gravity * Time.deltaTime;
            
            if (Input.GetKeyDown(KeyCode.Space)) Jump();
            
            Vector2 movementInput = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
            );

            Vector3 velocity = new Vector3(movementInput.x, 0, movementInput.y).normalized * moveSpeed;
            velocity.y = _verticalVelocity;
            
            _characterController.Move(velocity * Time.deltaTime);
            
            if (movementInput == Vector2.zero) return;

            float targetRot = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg;
            float currentRot = transform.rotation.eulerAngles.y;
            float yRot = Mathf.SmoothDampAngle(currentRot, targetRot, ref _angularVelocity, turnSpeed);
            
            transform.rotation = Quaternion.Euler(0, yRot, 0);
        }

        private void Jump() {
            _verticalVelocity = _jumpVelocity;
        }
    }
}