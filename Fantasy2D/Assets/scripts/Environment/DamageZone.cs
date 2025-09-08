using UnityEngine;

namespace TestFantasy2D
{
    public class DamageZone : MonoBehaviour
    {
        [SerializeField] int _damage = 2;

        float _interal = 2f;
        float _time = 0;
        bool _isInvincible = false;
        private void OnTriggerStay2D(Collider2D collision)
        {
            PlayerData player = collision.GetComponent<PlayerData>();

            if(player != null)
            {
                _time += Time.deltaTime;
                if(_time>_interal)
                {
                    _isInvincible = true;
                    _time = 0;
                }
                if(_isInvincible)
                {
                    player.ChangeHealth(-_damage);
                    _isInvincible=false;
                }
                
            }
        }
    }
}
