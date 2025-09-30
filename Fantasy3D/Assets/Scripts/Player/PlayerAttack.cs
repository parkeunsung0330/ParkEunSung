using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

namespace Fantasy3D
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField]
        GameObject _weaponHolder;

        BoxCollider _weaponCollider;
        Animator _anim;
        //PlayerMove _move;
        //Rigidbody _rb;
        public bool IsAttack { get; set; }

        bool _canAttack = false;
         



        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if(_weaponCollider != null)
            {
                _weaponCollider.enabled = false;
            }

            _anim = GetComponent<Animator>();
            //_move = GetComponentInParent<PlayerMove>();
            //_rb = GetComponentInParent<Rigidbody>();
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
            IsAttack = false;
        }

        public void EquipRightWeapon(GameObject obj)
        {
            GameObject go = Instantiate(obj, _weaponHolder.transform);
            go.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            SetWeapon(go);
            Destroy(obj);
            _canAttack = true;
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
                if (_anim.name!=("Attack")&&_canAttack==true)
                {
                    IsAttack = true;
                    _anim.SetTrigger("Attack");
                }
            }
            
        }

        
    }
}
