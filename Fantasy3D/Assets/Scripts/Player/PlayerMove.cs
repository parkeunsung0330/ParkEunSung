using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

namespace Fantasy3D
{
    public class PlayerMove : MonoBehaviour
    {

        public enum CameraStyle
        {
            Basic,
            TopDown
        }
        const float MAXSPEED = 7.0f;

        [SerializeField] Transform _cam;
        [SerializeField] float _turnSmoothTime = 0.3f;//돌아갈때 스무스하게 돌아가는 시간
        [SerializeField] float _speed;
        [SerializeField] GameObject _topCam;
        [SerializeField] GameObject _tpsCam;

        float _horizontal;
        float _vertical;
        float _trunSmoothVelocity;

        Rigidbody _rb;
        Vector3 _move;
        Vector3 _lookDirection = new(0,0,0);

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            SetDirection();

            if(Input.GetKeyDown(KeyCode.Alpha1 ) )SwitchCamera(CameraStyle.Basic);
            if(Input.GetKeyDown(KeyCode.Alpha2 ) )SwitchCamera(CameraStyle.TopDown);
        }

        private void FixedUpdate()
        {
            Move();
        }

        void SetDirection()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");

            _move = new(_horizontal,0,_vertical);

            _lookDirection = _move.normalized;

            if (_lookDirection.magnitude >= 0.1f)
            {
                _speed = _move.magnitude * MAXSPEED;
                _speed = Mathf.Clamp(_speed,0.0f,MAXSPEED );
            }
            else
            {
                _speed = 0.0f;
            }
        }

        void Move()
        {
            //Vector3 position = _rb.position;
            //position += _speed * Time.fixedDeltaTime * _lookDirection;
            //_rb.MovePosition(position);

            float targetAngle = Mathf.Atan2(_lookDirection.x,_lookDirection.z ) * Mathf.Rad2Deg + _cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _trunSmoothVelocity, _turnSmoothTime);
            //transform.rotation = Quaternion.Euler(0f,angle,0f);
            _rb.MoveRotation(Quaternion.Euler(0f, angle, 0f));

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _rb.MovePosition(_rb.position + moveDir.normalized * Time.fixedDeltaTime * _speed);
        }


        void SwitchCamera(CameraStyle newStyle)
        {
            _tpsCam.SetActive(false);
            _topCam.SetActive(false);

            if(newStyle == CameraStyle.Basic) _tpsCam.SetActive(true);
            if(newStyle == CameraStyle.TopDown) _topCam.SetActive(true);
        }
    }
}
