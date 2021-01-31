using Puzzle;
using UnityEngine;

namespace Abilities
{
    [RequireComponent(typeof(Light))]
    public class InvisibleEyes : Ability,ICorrectPosition
    {
        private Light _light;
        private bool _hasMeshRenderer;
        private MeshRenderer _renderer;

        protected override void Awake()
        {
            base.Awake();
            _renderer = GetComponent<MeshRenderer>();
            _hasMeshRenderer = _renderer;
            enabled = false;
            _light = GetComponent<Light>();
            GetComponent<AbilityAssigner>().OnPlayerEnter += gm =>
            {
                enabled = true;
                MarkAsOk();
            };
        }

        public Vector3 Center => _hasMeshRenderer ? _renderer.bounds.center : transform.position;
        private void Update()
        {
            foreach (var target in ViewDistanceData.All)
                target.Show = Vector3.Distance(Center,target.Center) < _light.range;
        }
    }
}