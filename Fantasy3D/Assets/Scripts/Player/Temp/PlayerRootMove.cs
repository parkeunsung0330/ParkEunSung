using UnityEngine;

namespace Fantasy3D
{
    public class PlayerRootMove : MonoBehaviour
    {
        Rigidbody _rb;
        Animator _anim;

        
        void Start()
        {
            _rb = GetComponentInParent<Rigidbody>();
            _anim = GetComponent<Animator>();
        }


        private void OnAnimatorMove()
        {
            if (_anim.applyRootMotion)
            {

                _rb.MovePosition(_rb.position + _anim.deltaPosition);
                _rb.MoveRotation(_rb.rotation);
                transform.localPosition = Vector3.zero;

            }
        }

    }
}
