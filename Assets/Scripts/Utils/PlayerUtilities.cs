using System;
using Data;
using Logic;
using UnityEngine;

namespace Utils
{
    public class PlayerUtilities : IDisposable
    {
        private bool _isAbilityDone;
        public GroundChecker GroundChecker { get; }
        public Movement Movement { get; }
        public PlayerData PlayerData { get; }
        public event Action AbilityDone;

        public bool IsAbilityDone
        {
            get => _isAbilityDone;
            set
            {
                _isAbilityDone = value;
                if (value)
                    AbilityDone?.Invoke();
            }
        }

        public PlayerUtilities(GroundChecker groundChecker, Movement movement, PlayerData playerData)
        {
            GroundChecker = groundChecker;
            PlayerData = playerData;
            Movement = movement;
        }

        public void Dispose()
        {
            Debug.Log("Disposed");
        }
    }
}