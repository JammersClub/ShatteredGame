using System;
using Player;
using UnityEngine;

namespace Abilities
{
    public sealed class BodyBuildingAbility : Ability
    {
        [Tooltip("Set Player Mass After Received This Ability.")] [SerializeField] private float playerMass=2;
        private Rigidbody _player;

        private void Awake()
        {
            enabled = false;
            GetComponent<AbilityAssigner>().OnPlayerEnter += gm =>
            {
                _player = gm.GetComponent<Rigidbody>();
                if (_player) _player.mass = playerMass;
            };
        }
    }
}