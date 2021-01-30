using UnityEngine;

namespace Puzzle
{
    [RequireComponent(typeof(DoorAuthoring))]
    public class ViewDistanceData:MonoBehaviour
    {
        private DoorAuthoring _doorMode;

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
    }
}