using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private GroundDetector _groundDetector;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _groundDetector = GetComponentInChildren<GroundDetector>();
    }

    void Update()
    {
        Move();
        Jump();

        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(moveInput * _moveSpeed, _rigidbody.velocity.y);

        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void Jump()
    {
        if (_groundDetector != null && _groundDetector.IsGrounded && Input.GetButtonDown("Jump"))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
}