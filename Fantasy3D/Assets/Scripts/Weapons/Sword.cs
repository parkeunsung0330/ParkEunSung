using UnityEngine;

namespace Fantasy3D
{
    public class Sword : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (transform.parent == null && other.gameObject.tag == "Player")
            {
                PlayerAttack pa = other.gameObject.GetComponentInChildren<PlayerAttack>();

                if(pa != null)
                {
                    pa.EquipRightWeapon(this.gameObject);
                }
            }

            if(other.gameObject.tag == "Monster")
            {
                //Destroy(other.gameObject);
                EnemyMove em = other.gameObject.GetComponent<EnemyMove>();
                if(em != null)
                {
                    em.IsDead = true;
                }
            }
        }
    }
}
