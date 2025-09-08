using UnityEngine;

namespace TestFantasy2D
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] float _attackRadius = 0.4f;
        [SerializeField] protected  float _basicOffset = 1f;
        [SerializeField] protected GameObject _particlePrefab;


        public float AttackRadious { get { return _attackRadius; } }

        
           

        public abstract void SetColliderOffset(Vector2 offset);
        public abstract void TurnOnCollider();


        public abstract void TurnOffCollider();
        

       
    }
}
