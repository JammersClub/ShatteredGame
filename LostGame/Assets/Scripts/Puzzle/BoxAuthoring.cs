using Player;
using UnityEngine;

namespace Puzzle
{
    [RequireComponent(typeof(Rigidbody))]
    public class BoxAuthoring : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float distanceToAssignToPlayer = 1f;
        private PlayerAuthoring _player;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
            _player=FindObjectOfType<PlayerAuthoring>();
            if (_player) return;
            Debug.LogWarning($"{name} Can Not Find Player!");
            enabled = false;
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _player.transform.position) < distanceToAssignToPlayer)
                _rigidbody.isKinematic = !Pushable;
            else _rigidbody.isKinematic = true;
        }

        public bool Pushable { get; set; }
    }
}