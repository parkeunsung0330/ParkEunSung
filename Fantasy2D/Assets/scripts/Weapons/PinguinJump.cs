using UnityEngine;

namespace TestFantasy2D
{
    public class PinguinJump : Weapon
    {
        CircleCollider2D _collider;



        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _collider = GetComponent<CircleCollider2D>();
            _collider.radius = AttackRadious;
            _collider.enabled = false;
        }

        public override void SetColliderOffset(Vector2 offset)
        {
            _collider.offset = offset * _basicOffset;
        }
        public override void TurnOnCollider()
        {
            _collider.enabled = true;
        }


        public override void TurnOffCollider()
        {
            _collider.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}
