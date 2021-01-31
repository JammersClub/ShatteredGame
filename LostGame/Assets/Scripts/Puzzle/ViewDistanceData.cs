using UnityEngine;

namespace Puzzle
{
    [RequireComponent(typeof(DoorAuthoring))]
    public class ViewDistanceData : GatherBehaviour<ViewDistanceData>, ICorrectPosition
    {
        private DoorAuthoring _doorMode;
        private bool _hasMeshRenderer;
        private MeshRenderer _renderer;

        public bool Show
        {
            get
            {
                if (!_doorMode) _doorMode = GetComponent<DoorAuthoring>();
                return _doorMode.IsOpen;
            }
            set
            {
                if (!_doorMode) _doorMode = GetComponent<DoorAuthoring>();
                _doorMode.IsOpen = value;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            _renderer = GetComponent<MeshRenderer>();
            _hasMeshRenderer = _renderer;
        }

        private void Start()
        {
            Show = false;
        }

        public Vector3 Center => _hasMeshRenderer ? _renderer.bounds.center : transform.position;
    }
}