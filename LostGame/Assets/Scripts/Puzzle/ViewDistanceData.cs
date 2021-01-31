using System;
using UnityEngine;

namespace Puzzle
{
    [RequireComponent(typeof(DoorAuthoring))]
    public class ViewDistanceData:GatherBehaviour<ViewDistanceData>
    {
        private DoorAuthoring _doorMode;

        private void Start()
        {
            Show = false;
        }

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