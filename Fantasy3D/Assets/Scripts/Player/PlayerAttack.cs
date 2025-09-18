using UnityEngine;
using System.Collections.Generic;
using UnityEngine;

namespace Fantasy3D
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField]
        GameObject _weaponHolder;

        BoxCollider _weaponCollider;
        Animator _anim;
        
        public bool IsAttack { get; set; }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if(_weaponCollider != null)
            {
                _weaponCollider.enabled = false;
            }

            _anim = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            Attack();
        }

        public void AttackStart()
        {
            _weaponCollider.enabled = true;
        }

        public void AttackEnd()
        {
            _weaponCollider.enabled = false;
        }

        public void EquipRightWeapon(GameObject obj)
        {
            GameObject go = Instantiate(obj, _weaponHolder.transform);
            go.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            SetWeapon(go);
            Destroy(obj);

        }

        void SetWeapon(GameObject obj)
        {
            _weaponCollider = obj.GetComponent<BoxCollider>();
            if( _weaponCollider != null )
            {
                _weaponCollider.enabled = false;
            }
        }

        void Attack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                IsAttack = true;
                _anim.SetTrigger("Attack");
            }
            
        }
    }
}
