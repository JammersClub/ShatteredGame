using Movements;
using UnityEngine;

namespace Abilities
{
    [RequireComponent(typeof(Movement))]
    public class AbilityCollector : MonoBehaviour
    {
        [SerializeField] private float distanceToCollectAbility = 0.5f;
        private AbilityMovement[] _abilities;
        private Movement _movement;

        private void Start()
        {
            _abilities = FindObjectsOfType<AbilityMovement>();
            _movement = GetComponent<Movement>();
        }

        private void Update()
        {
            foreach (var ability in _abilities)
                if (ability.TargetIsNull && Vector2.Distance(ability.transform.position, transform.position) <
                    distanceToCollectAbility)
                    ability.Target = _movement;
        }
    }
}