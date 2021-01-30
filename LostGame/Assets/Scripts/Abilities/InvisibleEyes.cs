using Puzzle;
using UnityEngine;

namespace Abilities
{
    [RequireComponent(typeof(Light))]
    public class InvisibleEyes : Ability
    {
        private Light _light;
        private void Awake()
        {
            enabled = false;
            _light = GetComponent<Light>();
            GetComponent<AbilityAssigner>().OnPlayerEnter += gm =>
            {
                enabled = true;
            };
        }

        private void Update()
        {
            foreach (var target in ViewDistanceData.All)
                target.Show = Vector3.Distance(transform.position,target.transform.position) < _light.range;
        }
    }
}