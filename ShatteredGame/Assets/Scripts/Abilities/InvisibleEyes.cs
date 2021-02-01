using Movements;
using Puzzle;
using UnityEngine;

namespace Abilities
{
    [RequireComponent(typeof(Light))]
    public class InvisibleEyes : Ability
    {
        private Light _light;
        private Movement _player;

        protected override void Awake()
        {
            base.Awake();
            enabled = false;
            _light = GetComponent<Light>();
            GetComponent<AbilityAssigner>().OnPlayerEnter += gm =>
            {
                _player = gm.GetComponent<Movement>();
                if(!_player) return;
                enabled = true;
                MarkAsOk();
            };
        }

        private void Update()
        {
            foreach (var target in ViewDistanceData.All)
                target.Show = Vector3.Distance(_player.transform.position, target.Center) < _light.range;
        }
    }
}