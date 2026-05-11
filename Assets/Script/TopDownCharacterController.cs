using UnityEngine.InputSystem;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Update() {

        movement.x = Keyboard.current.dKey.isPressed ? 1 : (Keyboard.current.aKey.isPressed ? -1 : 0);
        movement.y = Keyboard.current.wKey.isPressed ? 1 : (Keyboard.current.sKey.isPressed ? -1 : 0);
        movement = movement.normalized;

        UpdateAnimations();
    }

    void FixedUpdate() {
        // Move the player using physics
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void UpdateAnimations() {

        float speed = movement.magnitude;
        animator.SetFloat("Speed", speed);

        animator.SetBool("walkingForward", false);
        animator.SetBool("walkingBackwards", false);
        animator.SetBool("walkingSide", false);

        if (speed > 0)
        {
            // Prioritize vertical movement for the "Forward/Backward" animations
            if (Mathf.Abs(movement.y) >= Mathf.Abs(movement.x))
            {
                if (movement.y > 0) 
                    animator.SetBool("walkingBackwards", true); // W key = up/back in top-down
                else 
                    animator.SetBool("walkingForward", true);  // S key = down/forward
            }
            else
            {
                animator.SetBool("walkingSide", true); // A or D keys
                
                // Flip the sprite visually if moving left
                if (movement.x < 0) transform.localScale = new Vector3(1, 1, 1);
                else if (movement.x > 0) transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}