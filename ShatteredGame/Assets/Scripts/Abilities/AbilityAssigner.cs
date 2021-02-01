using System;
using Player;
using UnityEngine;

namespace Abilities
{
    public sealed class AbilityAssigner : MonoBehaviour
    {
        [SerializeField] private float distanceToAssignToPlayer = 1f;
        [SerializeField] private bool autoDisable = true;
        [SerializeField] private AudioSource onAssignClip;
        private PlayerAuthoring _player;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerAuthoring>();
            if (_player) return;
            Debug.LogWarning($"{name} Can Not Find Player!");
            enabled = false;
        }

        private void Update()
        {
            // ReSharper disable once InvertIf
            if (Vector3.Distance(_player.transform.position, transform.position) < distanceToAssignToPlayer)
            {
                OnPlayerEnter?.Invoke(_player.gameObject);
                if (onAssignClip) onAssignClip.Play();
                if (autoDisable) enabled = false;
            }
        }

        public event Action<GameObject> OnPlayerEnter;
    }
}