using System;
using Puzzle;
using UnityEngine;

namespace Player
{
    public class PlayerPlatform:MonoBehaviour
    {
        [NonSerialized] public PlatformAuthoring CurrentOrLastPlatform;
    }
}