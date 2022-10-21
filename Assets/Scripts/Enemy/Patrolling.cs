using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;

    private Vector3 _leftBorderPosition;
    private Vector3 _rightBorderPosition;
    private Vector3 _targetPosition;

    private void Start()
    {
        _leftBorderPosition = transform.position;
        _rightBorderPosition = _leftBorderPosition + Vector3.right * _distance;
        _targetPosition = _rightBorderPosition;
    }

    private void Update()
    {
        Moving(_targetPosition);

        if (transform.position == _rightBorderPosition)
        {
            Flip();
            _targetPosition = _leftBorderPosition;
        }
        else if (transform.position == _leftBorderPosition)
        {
            Flip();
            _targetPosition = _rightBorderPosition;
        }
    }

    private void Moving(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private void Flip()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
}
