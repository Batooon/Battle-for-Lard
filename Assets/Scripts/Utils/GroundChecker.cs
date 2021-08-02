using System;
using Logic;
using UnityEngine;

namespace Utils
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private LayerMask _groundLayer;
        public event Action LandedOnGround;
        public event Action GetOffGround;

        public bool IsOnGround { get; private set; }

        private void OnCollisionEnter2D(Collision2D other)
        {
            TryInteractWithGround(other, delegate
            {
                IsOnGround = true;
                LandedOnGround?.Invoke();
            });
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            TryInteractWithGround(other, delegate
            {
                IsOnGround = false;
                GetOffGround?.Invoke();
            });
        }

        private void TryInteractWithGround(Collision2D other, Action interaction)
        {
            if (other.gameObject.TryGetComponent<Ground>(out _))
            {
                interaction?.Invoke();
            }
        }
    }
}