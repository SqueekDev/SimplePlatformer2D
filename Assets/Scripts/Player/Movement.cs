using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody2D;
    private float _horizontalInputValue = 0f;
    private bool _isGrounded = false;
    private bool _isJumped = false;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalInputValue = Input.GetAxis("Horizontal");
        _animator.SetFloat("Run", Mathf.Abs(_horizontalInputValue));

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            _isJumped = true;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_horizontalInputValue * _speed * Time.fixedDeltaTime, _rigidbody2D.velocity.y);

        if (_isJumped)
        {
            _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            _isJumped = false;
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
            _isGrounded = true;
    }
}
