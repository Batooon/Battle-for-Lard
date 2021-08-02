using Data;
using Logic;
using Logic.StateMachine;
using Logic.StateMachine.States;
using Logic.StateMachine.Transitions;
using UnityEngine;
using Utils;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerData _playerData;
    private PlayerUtilities _playerUtilities;
    private StateMachine _playerStateMachine;

    private void Awake()
    {
        var playerMovement = new Movement(_player);
        _playerUtilities = new PlayerUtilities(_groundChecker, playerMovement, _playerData);
        
        var idleState = new IdleState(_playerUtilities, _player);
        var moveState = new MoveState(_playerUtilities, _player);
        var jumpState = new JumpState(_playerUtilities, _player);
        var inAirState = new InAirState(_playerUtilities, _player);
        var landState = new LandState(_playerUtilities, _player);
        
        var jumpTransition = new JumpTransition(jumpState, _playerUtilities);
        var moveTransition = new MoveTransition(moveState, _playerUtilities);
        var idleTransition = new IdleTransition(idleState, _playerUtilities);
        var inAirTransition = new InAirTransition(inAirState, _playerUtilities);
        var landTransition = new LandTransition(landState, _playerUtilities);

        idleState.AddTransition(moveTransition);
        idleState.AddTransition(jumpTransition);
        
        jumpState.AddTransition(inAirTransition);
        
        inAirState.AddTransition(landTransition);
        
        landState.AddTransition(moveTransition);
        landState.AddTransition(idleTransition);
        
        moveState.AddTransition(jumpTransition);
        moveState.AddTransition(idleTransition);

        _playerStateMachine = new StateMachine(idleState);
    }

    private void Update()
    {
        InputHandler.Update();
        
        _playerStateMachine.Update();
    }
}