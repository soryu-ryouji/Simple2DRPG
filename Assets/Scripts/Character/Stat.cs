using System.Collections.Generic;
using Simple2DRPG.Character;
using UnityEngine;

namespace Simple2DRPG
{
    [System.Serializable]
    public class Stat
    {
        [SerializeField] private int baseValue;
        public List<int> modifiers;

        public int GetValue()
        {
            var finalValue = baseValue;
            foreach (var item in modifiers)
            {
                finalValue += item;
            }

            return finalValue;
        }

        public void AddModifier(int modifier)
        {
            modifiers.Add(modifier);
        }

        public void RemoveModifier(int modifier)
        {
            modifiers.RemoveAt(modifier);
        }
    }
}