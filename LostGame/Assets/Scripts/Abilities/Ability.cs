using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator

namespace Abilities
{
    [RequireComponent(typeof(AbilityAssigner))]
    public abstract class Ability : MonoBehaviour
    {
        private const string WinScene = "Win";
        private static readonly List<Ability> Abilities = new List<Ability>();
        private bool _assigned;

        protected virtual void Awake()
        {
            Abilities.Add(this);
        }

        protected void MarkAsOk()
        {
            _assigned = true;
            var allPassed = true;
            foreach (var ability in Abilities)
                if (!ability._assigned)
                    allPassed = false;
            if (allPassed) SceneManager.LoadScene(WinScene);
        }
    }
}