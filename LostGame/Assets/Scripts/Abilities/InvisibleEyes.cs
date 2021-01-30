using System;
using Puzzle;
using UnityEngine;

namespace Abilities
{
    [RequireComponent(typeof(Light))]
    public class InvisibleEyes : Ability
    {
        private Light _light;
        private ViewDistanceData[] _viewDistances;
        private void Awake()
        {
            enabled = false;
            _light = GetComponent<Light>();
            _viewDistances = FindObjectsOfType<ViewDistanceData>();
            GetComponent<AbilityAssigner>().OnPlayerEnter += gm =>
            {
                enabled = true;
            };
        }

        private void Start()
        {
            foreach (var target in _viewDistances) target.Show = false;
        }

        private void Update()
        {
            foreach (var target in _viewDistances)
                target.Show = Vector3.Distance(transform.position,target.transform.position) < _light.range;
        }
    }
}