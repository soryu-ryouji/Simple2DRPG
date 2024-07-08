using UnityEngine;

namespace Simple2DRPG.Character
{
    public class CharacterState : MonoBehaviour
    {
        public Stat strenth;
        public Stat attackDamage;
        public Stat maxHp;
        public int CurrentHp { get; private set; }

        protected virtual void Start()
        {
            CurrentHp = maxHp.GetValue();
        }

        public virtual void DoDamage(CharacterState state)
        {
            var totalDamage = attackDamage.GetValue() + strenth.GetValue();
            state.TakeDamage(totalDamage);
        }

        public virtual void TakeDamage(int damage)
        {
            CurrentHp -= damage;
        }


        protected virtual void Die()
        {

        }
    }
}