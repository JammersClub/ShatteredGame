using UnityEngine;

namespace Abilities
{
    public sealed class BodyBuildingAbility : Ability
    {
        private Rigidbody _player;

        private void Awake()
        {
            enabled = false;
            GetComponent<AbilityAssigner>().OnPlayerEnter += gm =>
            {
                _player = gm.GetComponent<Rigidbody>();
                if (_player)
                {
                    _player.mass = 1;
                }
            };
        }
    }
}