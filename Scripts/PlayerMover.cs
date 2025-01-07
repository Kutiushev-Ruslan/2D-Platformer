using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";

    [SerializeField] private float moveSpeed = 5.5f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private KeyCode _jumpButton = KeyCode.Space;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private GroundDetector _groundDetector;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _groundDetector = GetComponentInChildren<GroundDetector>();
    }

    private void Update()
    {
        Move();
        Jump();

        _animator.SetFloat("PlayerCurrentSpeed", Mathf.Abs(_rigidbody.velocity.x));
    }

    private void Move()
    {
        float moveInput = Input.GetAxis(HorizontalAxis);
        _rigidbody.velocity = new Vector2(moveInput * moveSpeed, _rigidbody.velocity.y);

        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void Jump()
    {
        if (_groundDetector != null && _groundDetector.IsGrounded && Input.GetKeyDown(_jumpButton))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        }
    }
}
