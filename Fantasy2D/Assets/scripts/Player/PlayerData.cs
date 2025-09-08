
using UnityEngine;

namespace TestFantasy2D
{
    public class PlayerData : StatsData
    {
        
        //[SerializeField] UIHealthBar _hpBar;
        public override int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

        public override int MaxStrength  { get { return _maxStr; } }

        public override float MaxAgi { get { return _maxAgi; } }


        public void ChangeStrength(int amount)
        {
            
            //ÃÖ¼Ú°ª°ú ÃÖ´ñ°ª ¼³Á¤.
            Strength = Mathf.Clamp(Strength+ amount, 0, MaxStrength);
            Debug.Log("Health Changed : " + Strength + "/" + MaxStrength);
        }

        public void ChangeAgility(float amount)
        {
            //ÃÖ¼Ú°ª°ú ÃÖ´ñ°ª ¼³Á¤.
            Agi = Mathf.Clamp(Agi + amount, 0, MaxAgi);
            Debug.Log("Agility Changed : " + Agi + "/" + MaxAgi);
            PlayerAnimation playerAnimation = GetComponent<PlayerAnimation>();
            playerAnimation.AttackSpeedAnim(Agi);
        }

        public override void ChangeHealth(int amount)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
            Debug.Log("Health Changed : " + CurrentHealth + "/" + MaxHealth);
            UIHealthBar.Instance.SetValue(CurrentHealth / (float)MaxHealth);
            //_hpBar.SetValue(CurrentHealth / (float)MaxHealth);
        }
    }
}
