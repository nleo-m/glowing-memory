using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpPower = 5f;
    [SerializeField] int health = 10;
    public bool isFacingRight = true;
    float xInput, yInput;
    bool isGrounded = true;
    bool isCrouched = false;
    bool isShooting = false;
    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if ((xInput < 0 && isFacingRight) || (xInput > 0 && !isFacingRight)) Flip();

        if (yInput < 0 && isGrounded) isCrouched = true;
        else isCrouched = false;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("Jump");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isGrounded = false;
        }

        if (isCrouched)
        {
            speed -= 0.1f;
        } else
        {
            speed = 5f;
        }

        if (Input.GetButton("Fire1")) isShooting = true;
        else isShooting = false;
            
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isCrouched", isCrouched);
        animator.SetBool("isShooting", isShooting);
    }

    private void FixedUpdate()
    {
        if (isCrouched == false)
            rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);

        if (isGrounded == false && yInput < 0)
            rb.AddForce(transform.up * Mathf.Abs(yInput) * 5 * -1);
    }

    void TakeDamage(float damage) { }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
