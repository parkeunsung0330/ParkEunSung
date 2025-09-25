using UnityEngine;

namespace Fantasy3D
{
    public class PlayerJump : MonoBehaviour
    {

        [SerializeField] Vector3 _boxSize;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] float _jumpForce = 7.0f;
        [SerializeField] 
        [Range(0.05f, 0.1f)]
        float _maxDistance;
        bool _isJump= false;
        bool _isFalling = false;
        bool _isLanding = false;
        bool _isGround = false;
        float _gravityAccel = 9.81f;
        float _jump;
        Rigidbody _rb;
        Animator _anim;
       

        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _anim = GetComponentInChildren<Animator>();   
        }

        // Update is called once per frame
        void Update()
        {
            _jump = Input.GetAxis("Jump");

            _anim.SetBool("IsJump", _isJump);
            _anim.SetBool("IsFalling",_isFalling);
            _anim.SetBool("IsLanding", _isLanding);
        }

        private void FixedUpdate()
        {
            _isGround = GroundCheck();

            if(!_isGround && _rb.linearVelocity.y < -2.0f)
            {
                _isFalling = true;
            }

            Jumping();
        }

        void Jumping()
        {
            Vector3 velocity = _rb.linearVelocity;
            if(!_isGround)
            {
                velocity.y -= _gravityAccel * Time.fixedDeltaTime;
                _rb.linearVelocity = velocity;
            }

            if(_jump > 0.1f)
            {
                if(_isGround)
                {
                    _isJump = true;
                    velocity.y = _jumpForce;
                    _rb.linearVelocity = velocity;
                }
            }
        }

        bool GroundCheck()
        {
            Vector3 origin = transform.position + Vector3.up * _maxDistance;
            if (Physics.BoxCast(origin, _boxSize/2,Vector3.down,transform.rotation, _maxDistance))
            {
                _isJump = false;
                _isFalling = false;
                _isLanding = true;
                return true;
            }
            else
            {
                _isLanding = false;
                return false;
            }
        }


        private void OnDrawGizmos()
        {
            Vector3 origin = transform.position + Vector3.up * _maxDistance;
            Vector3 endPosition = origin + Vector3.down * _maxDistance;

            Gizmos.color = Color.red;
            if(_isGround )
            {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawCube(endPosition, _boxSize);
        }

        
    }
}
