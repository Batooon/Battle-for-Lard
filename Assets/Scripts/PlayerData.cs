using UnityEngine;

[CreateAssetMenu(menuName = "Create PlayerData", fileName = "PlayerData", order = 0)]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float _maxSpeed = 8f;
    [SerializeField] private bool _canMoveInTheAir = true;
    [SerializeField] private float _jumpVelocity = 5f;
    [SerializeField] private float _fallMultiplier = 2.5f;
    [SerializeField] private float _lowJumpMultiplier = 2f;

    public float MaxSpeed => _maxSpeed;

    public bool CanMoveInTheAir => _canMoveInTheAir;

    public float JumpVelocity => _jumpVelocity;

    public float FallMultiplier => _fallMultiplier;

    public float LowJumpMultiplier => _lowJumpMultiplier;
}