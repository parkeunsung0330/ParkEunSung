using UnityEngine;

namespace TestFantasy2D
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] float _speed=2.0f;

        Rigidbody2D _rb;
        Vector2 _lookDirection;
        Vector2 _move;
        float _horizontal;
        float _vertical;
        bool _isMoving = true;
        public bool IsMoving {  get { return _isMoving; } set { _isMoving = value; } }
        
        public Vector2 LookDirection { get { return _lookDirection; } }
        //프로퍼티는 값을 변경하는 필드느낌. 살짝 다르긴 함.

        public Vector2 Move {  get { return _move; } }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();//초기값 넣기
        }

        
        
        public void MoveCharacter()//물리적인 움직임 만들기
        {
            Vector2 movement = _move.normalized * _speed * Time.fixedDeltaTime;
            //속도 정규화(최댓값 1과 비율 설정)후 프레임당으로 변경 
            _rb.MovePosition(_rb.position + movement);

        }

        public Vector2 RoundDirection(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x);
            angle = Mathf.Round(angle/(Mathf.PI/4)*(Mathf.PI/4));
            return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
        public void GetDirection()
        {
            _horizontal = Input.GetAxis("Horizontal");//x축
            _vertical = Input.GetAxis("Vertical");//y축
            _move = new Vector2(_horizontal, _vertical);//움직임 만들기

            if (_move.magnitude > 0.1f)
            //움직임이 생겼다. magnitude는 빗변(이동한거리, 거리는 항상 양수)
            {
                _lookDirection = _move.normalized;//정규화 하기. 최댓값에 제한두기.

                
            }
            else
            {
                _move = Vector2.zero;//멈춰있을때
            }
        }
    }
}
