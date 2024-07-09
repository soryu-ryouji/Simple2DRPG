namespace Simple2DRPG.Character
{
    public class EnemyStat : CharacterState
    {
        private Enemy enemy;

        protected override void Start()
        {
            base.Start();

            enemy = GetComponent<Enemy>();
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            enemy.DamageEffect();
        }
    }
}
