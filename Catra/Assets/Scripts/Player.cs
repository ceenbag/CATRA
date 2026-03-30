using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player Component References")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;

    [Header("Player Settings")]
    [SerializeField] float speed;
    [SerializeField] float jumpingPower;
    [SerializeField] int extraJumpsValue;

    [Header("Gounding")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;



    private float horizontal;
    private int extraJumps;

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(IsGrounded())
        {
            extraJumps = extraJumpsValue;
        }
        if(context.performed)
        {
            if(IsGrounded())
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            }
            else if(extraJumps > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
                extraJumps--;
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1f, 0.1f), CapsuleDirection2D.Horizontal, 0.2f, groundLayer);
    }
}
