using UnityEngine;

namespace TestFantasy2D
{
    public class MonkeyData : StatsData
    {
        public override int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

        public override int MaxStrength { get { return _maxStr; } }

        public override float MaxAgi { get { return _maxAgi; } }



        public override void ChangeHealth(int amount)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
            Debug.Log("Health Changed : " + CurrentHealth + "/" + MaxHealth);
        }
    }
}
