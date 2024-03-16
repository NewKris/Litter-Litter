using System;
using UnityEngine;

namespace CoffeeBara.Gameplay.Common {
    public class Drone : MonoBehaviour {
        public Transform target;
        public float damping;

        private Vector3 _velocity;
        
        private void Update() {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref _velocity, damping);
        }
    }
}