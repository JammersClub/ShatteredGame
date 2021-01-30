using Player;
using Puzzle;

namespace Abilities
{
    public sealed class BodyBuildingAbility : Ability
    {
        private PlayerAuthoring _player;

        private void Awake()
        {
            enabled = false;
            GetComponent<AbilityAssigner>().OnPlayerEnter += gm =>
            {
                _player = gm.GetComponent<PlayerAuthoring>();
                if (!_player) return;
                foreach (var box in BoxAuthoring.All)
                    box.Pushable = true;
                BoxAuthoring.OnNew += box =>
                {
                    box.Pushable = true;
                };
            };
        }
    }
}