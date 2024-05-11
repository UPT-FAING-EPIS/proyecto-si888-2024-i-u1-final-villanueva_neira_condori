using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float longIdleTime = 5f;
    public float speed = 2.5f;
    public float jumpForce = 2.5f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _facingRight = true;
    private bool _isGrounded;
    private bool _isAttacking;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_isAttacking == false)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            Vector2 movement = new Vector2(horizontalInput, 0f);

            if (horizontalInput < 0f && _facingRight == true)
            {
                Flip();
            }
            else if (horizontalInput > 0f && _facingRight == false)
            {
                Flip();
            }

            _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            if (Input.GetButtonDown("Jump") && _isGrounded == true && _isAttacking == false)
            {
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            if (Input.GetButtonDown("Fire1") && _isGrounded == true && _isAttacking == false)
            {
                _animator.SetTrigger("Attack");
            }
        }
    }

    void FixedUpdate()
    {
        if (_isAttacking == false)
        {
            float horizontalVelocity = Input.GetAxisRaw("Horizontal") * speed;
            _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
        }
    }

    void LateUpdate()
    {
        _animator.SetBool("Idle", _rigidbody.velocity == Vector2.zero);
        _animator.SetBool("IsGrounded", _isGrounded);
        _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);

        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            _isAttacking = true;
        }
        else
        {
            _isAttacking = false;
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
