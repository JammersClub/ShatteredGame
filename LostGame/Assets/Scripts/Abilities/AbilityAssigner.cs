using System;
using Player;
using UnityEngine;

namespace Abilities
{
    public sealed class AbilityAssigner : MonoBehaviour
    {
        [SerializeField] private float distanceToAssignToPlayer = 1f;
        private PlayerAuthoring _player;
        private bool _scanForTarget = true;
        public event Action<GameObject> OnPlayerEnter;

        private void Awake()
        {
            _player=FindObjectOfType<PlayerAuthoring>();
            if (_player) return;
            Debug.LogWarning($"{name} Can Not Find Player!");
            enabled = false;
        }

        private void Update()
        {
            if (!_scanForTarget) return;
            // ReSharper disable once InvertIf
            if (Vector3.Distance(_player.transform.position, transform.position) < distanceToAssignToPlayer)
            {
                _scanForTarget = false;
                OnPlayerEnter?.Invoke(_player.gameObject);
            }
        }
        
    }
}