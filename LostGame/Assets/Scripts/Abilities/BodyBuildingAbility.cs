using System;
using Player;
using Puzzle;
using UnityEngine;

namespace Abilities
{
    public sealed class BodyBuildingAbility : Ability
    {
        private PlayerAuthoring _player;
        private BoxAuthoring[] _scenePushableBoxes;

        private void Awake()
        {
            enabled = false;
            _scenePushableBoxes = FindObjectsOfType<BoxAuthoring>();
            foreach (var box in _scenePushableBoxes)
                box.Pushable = false;
            GetComponent<AbilityAssigner>().OnPlayerEnter += gm =>
            {
                _player = gm.GetComponent<PlayerAuthoring>();
                if (!_player) return;
                foreach (var box in _scenePushableBoxes)
                    box.Pushable = true;
            };
        }
    }
}