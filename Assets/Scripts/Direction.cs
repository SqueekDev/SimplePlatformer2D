using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private float _inputValue = 0f;
    private bool _isFacingRight = true;

    private void Update()
    {
        _inputValue = Input.GetAxis("Horizontal");

        if (_inputValue > 0f && _isFacingRight == false)
        {
            Flip();
        }
        else if (_inputValue < 0f && _isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }
}
