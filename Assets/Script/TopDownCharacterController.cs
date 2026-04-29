using UnityEngine.InputSystem;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    void Update() {

            // Replace movement.x = Input.GetAxisRaw("Horizontal");
            movement.x = Keyboard.current.dKey.isPressed ? 1 : (Keyboard.current.aKey.isPressed ? -1 : 0);

            // Replace movement.y = Input.GetAxisRaw("Vertical");
            movement.y = Keyboard.current.wKey.isPressed ? 1 : (Keyboard.current.sKey.isPressed ? -1 : 0);
       
        // Normalize the vector so diagonal movement isn't faster
        movement = movement.normalized;
    }

    void FixedUpdate() {
        // Move the player using physics
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}