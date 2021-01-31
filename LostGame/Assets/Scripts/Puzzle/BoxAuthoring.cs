using Player;
using UnityEngine;

namespace Puzzle
{
    [RequireComponent(typeof(Rigidbody))]
    public class BoxAuthoring : GatherBehaviour<BoxAuthoring>,ICorrectPosition
    {
        [SerializeField] private float distanceToAssignToPlayer = 1f;
        private PlayerAuthoring _player;
        private Rigidbody _rigidbody;
        private bool _hasMeshRenderer;
        private MeshRenderer _renderer;

        public Vector3 Center => _hasMeshRenderer ? _renderer.bounds.center : transform.position;

        public bool Pushable { get; set; }

        protected override void Awake()
        {
            // ReSharper disable once LocalVariableHidesMember
            Pushable = false;
            base.Awake();
            _renderer = GetComponent<MeshRenderer>();
            _hasMeshRenderer = _renderer;
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
            _player = FindObjectOfType<PlayerAuthoring>();
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
    }
}