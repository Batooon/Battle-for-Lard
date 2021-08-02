using System;
using UnityEngine;

public class Movement
{
    public Rigidbody2D Rigidbody { get; }
    private readonly Transform _transform;
    private Vector2 _velocity;

    private float _previousDirection = 1f;

    public Movement(Rigidbody2D rigidbody)
    {
        Rigidbody = rigidbody;
        _transform = Rigidbody.transform;
    }
    
    public void ChangeDirectionX(float direction, float maxSpeed)
    {
        _velocity.Set(direction * maxSpeed, Rigidbody.velocity.y);
        Rigidbody.velocity = _velocity;
        TryFlipCharacter(direction);
    }

    private void TryFlipCharacter(float direction)
    {
        if (Math.Abs(Mathf.Sign(_previousDirection) - Mathf.Sign(direction)) >= 2)
        {
            _transform.localEulerAngles += new Vector3(0, 180 * Mathf.Sign(direction));
        }
        _previousDirection = direction;
    }
}