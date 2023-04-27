using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 38f;
    private float jumpingPower = 140f;
    private bool isFacingRight = true;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("h_speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("v_speed", rb.velocity.y);
        animator.SetBool("isgrounded", IsGrounded());

        // Coyote time
        coyoteTimeCounter = IsGrounded() ? coyoteTime : coyoteTimeCounter -= Time.deltaTime;
        // Jump Buffer
        jumpBufferCounter = Input.GetButtonDown("Jump") ? jumpBufferTime : jumpBufferCounter -= Time.deltaTime;

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            coyoteTimeCounter = 0f;
            jumpBufferCounter = 0f;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
            jumpBufferCounter = 0f;
        }

        Flip();

        if (transform.position.x > 90)
        {
            transform.position = new Vector3(-80, transform.position.y, 0);
        }
        
        if (transform.position.x < -90)
        {
            transform.position = new Vector3(80, transform.position.y, 0);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}