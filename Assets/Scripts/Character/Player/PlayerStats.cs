namespace Simple2DRPG.Character
{
    public class PlayerStats : CharacterState
    {
        private Player player;

        protected override void Start()
        {
            base.Start();

            player.GetComponent<Player>();
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            player.DamageEffect();
        }
    }
}
