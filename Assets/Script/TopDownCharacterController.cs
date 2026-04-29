using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        private Vector2 moveInput;
        private Vector2 lookInput; 
        private Rigidbody2D rigi;

        void FixedUpdate() {
            if (moveInput.magnitude > 0.1f)
            {
                Vector2 moveForward = moveInput.y * this.transform.up;
                Vector2 moveRight = moveInput.x * this.transform.right;
                Vector2 moveVector = moveForward + moveRight;
    
                rigi.AddForce(moveVector * speed * Time.deltaTime);
            }
        }
    }
