using Player;

namespace Abilities
{
    public sealed class EmptyAbility : Ability
    {
        private PlayerAuthoring _player;

        protected override void Awake()
        {
            base.Awake();
            enabled = false;
            GetComponent<AbilityAssigner>().OnPlayerEnter += gm =>
            {
                _player = gm.GetComponent<PlayerAuthoring>();
                if (!_player) return;
                MarkAsOk();
            };
        }
    }
}