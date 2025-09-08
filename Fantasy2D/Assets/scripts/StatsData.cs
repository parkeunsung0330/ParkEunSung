using UnityEngine;

namespace TestFantasy2D
{
    public abstract class StatsData : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] protected int _maxHealth = 50;//최대체력
        [Header("Strength")]//인스펙터에게 보이게
        [Range(1, 99)]//최댓값,최솟값 만들기, 슬라이더로 조정 가능하게.
        [SerializeField] protected int _str = 5;//힘
        [Header("Agility")]
        [Range(0f, 3.0f)]
        [SerializeField] protected float _agi = 1.0f;//공격속도

        protected int _health;
        protected int _maxStr = 99;
        protected float _maxAgi = 3.0f;
        bool _isDead = false;

        public int CurrentHealth { get { return _health; } set { _health = value; } }

        public abstract int MaxHealth { get; set; }

        public int Strength { get { return _str; } set { _str = value; } }

        public abstract int MaxStrength { get; }

        public float Agi { get { return _agi; } set { _agi = value; } }

        public abstract float MaxAgi { get; }

        public bool IsDead { get { return _isDead; } set { _isDead = value; } }

        private void Start()
        {
            CurrentHealth = _maxHealth;
        }

        public abstract void ChangeHealth(int amount);

        public bool DeathCheck()
        {
            if(CurrentHealth <= 0)
            {
                return true;
            }

            return false;
        }
        //{
        //    //최솟값과 최댓값 설정.
        //    CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);
        //    Debug.Log("Health Changed : " + CurrentHealth + "/" + MaxHealth);
        //}
    }
}

