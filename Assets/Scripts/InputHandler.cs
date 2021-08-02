using System;
using UnityEngine;

public static class InputHandler
{
    public static event Action<float> DirectionChanged;
    public static event Action JumpKeyPressed;
    public static event Action NotMoving;
    public static event Action StartMoving;
    public static bool IsWalkKeysPressed;
    private static float _horizontalAxis;

    public static void Update()
    {
        if (IsWalkKeyPressed())
        {
            IsWalkKeysPressed = true;
            StartMoving?.Invoke();
        }

        _horizontalAxis = Input.GetAxis("Horizontal");
        if (_horizontalAxis != 0)
            DirectionChanged?.Invoke(_horizontalAxis);

        if (Input.GetKeyDown(InputKeys.Jump))
        {
            JumpKeyPressed?.Invoke();
        }

        if (IsWalkKeysUnpressed())
        {
            IsWalkKeysPressed = false;
            NotMoving?.Invoke();
        }
    }

    private static bool IsWalkKeyPressed()
    {
        return Input.GetKeyDown(InputKeys.Left) || Input.GetKeyDown(InputKeys.Right);
    }
    
    private static bool IsWalkKeysUnpressed()
    {
        if (Input.GetKeyUp(InputKeys.Left) == false && Input.GetKeyUp(InputKeys.Right) == false)
            return false;
        return Input.GetKey(InputKeys.Right) == false && Input.GetKey(InputKeys.Left) == false;
    }
}

public static class InputKeys
{
    public const KeyCode Left = KeyCode.A;
    public const KeyCode Right = KeyCode.D;
    public const KeyCode Jump = KeyCode.Space;
}