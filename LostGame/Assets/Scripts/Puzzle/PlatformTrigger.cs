using Movements;
using Player;
using UnityEngine;

namespace Puzzle
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(DoorAuthoring))]
    public class PlatformTrigger:MonoBehaviour
    {
        private BoxCollider _collider;
        private DoorAuthoring _doorMode;
        private Movement _player;

        private void Awake()
        {
            _doorMode = GetComponent<DoorAuthoring>();
            _collider = GetComponent<BoxCollider>();
            _collider.isTrigger = true;
            _player = FindObjectOfType<PlayerMovement>();
        }

        private void Update()
        {
            _doorMode.IsOpen = _collider.bounds.Contains(_player.transform.position);
        }
    }
}