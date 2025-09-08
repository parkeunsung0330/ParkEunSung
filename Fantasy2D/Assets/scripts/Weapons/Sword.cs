using UnityEngine;

namespace TestFantasy2D
{
    public class Sword : Weapon
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
            _collider.offset = offset*_basicOffset;
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
            //Debug.Log(collision.gameObject.name);
            StatsData statsData = collision.GetComponent<StatsData>();
            if(statsData != null)
            {

                statsData.ChangeHealth(-20);
                var hitVFX = Instantiate(_particlePrefab, collision.transform.position, Quaternion.identity);
                PlayerAudio audio = GetComponentInParent<PlayerAudio>();
                AnimalAudio hitclip = collision.gameObject.GetComponent<AnimalAudio>();
                audio.SoundEffect(hitclip.Hitclip);
                Destroy(hitVFX);
            }

            void DestroyParticle(GameObject particle)
            {
                ParticleSystem ps = particle.GetComponent<ParticleSystem>();
                if(ps == null)
                {
                    particle.GetComponentInChildren<ParticleSystem>();
                }
                Destroy(particle,ps.main.duration);
            }
        }
    }
}
