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
        //������Ƽ�� ���� �����ϴ� �ʵ����. ��¦ �ٸ��� ��.

        public Vector2 Move {  get { return _move; } }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();//�ʱⰪ �ֱ�
        }

        
        
        public void MoveCharacter()//�������� ������ �����
        {
            Vector2 movement = _move.normalized * _speed * Time.fixedDeltaTime;
            //�ӵ� ����ȭ(�ִ� 1�� ���� ����)�� �����Ӵ����� ���� 
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
            _horizontal = Input.GetAxis("Horizontal");//x��
            _vertical = Input.GetAxis("Vertical");//y��
            _move = new Vector2(_horizontal, _vertical);//������ �����

            if (_move.magnitude > 0.1f)
            //�������� �����. magnitude�� ����(�̵��ѰŸ�, �Ÿ��� �׻� ���)
            {
                _lookDirection = _move.normalized;//����ȭ �ϱ�. �ִ񰪿� ���ѵα�.

                
            }
            else
            {
                _move = Vector2.zero;//����������
            }
        }
    }
}
