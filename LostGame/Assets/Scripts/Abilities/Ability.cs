using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator

namespace Abilities
{
    [RequireComponent(typeof(AbilityAssigner))]
    public abstract class Ability : MonoBehaviour
    {
        private readonly List<Ability> _abilities=new List<Ability>();
        private bool _assigned;
        private const string WinScene = "Win";

        protected void MarkAsOk()
        {
            _assigned = true;
            
            var allPassed = true;
            foreach (var ability in _abilities) if (!ability._assigned) allPassed = false;
            if (allPassed) SceneManager.LoadScene(WinScene);
        }

        protected virtual void Awake()
        {
            _abilities.Add(this);
        }
    }
}