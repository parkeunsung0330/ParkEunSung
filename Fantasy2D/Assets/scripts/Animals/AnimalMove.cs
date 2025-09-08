using UnityEngine;
using UnityEngine.VFX;

namespace TestFantasy2D
{
    public abstract class AnimalMove : MonoBehaviour
    {
        
        //������ٵ� ����
        Rigidbody2D _rb;
        //���� ���� �ֱ�
        float _changeDirectionInterval = 2f;
        //���� �̵� ����
        Vector2 _currentDirection;
        //���� ���� Ÿ�̸�
        float _timer;
        //8���� ���� ����Ʈ
        Vector2[] _directions;

        bool _isMoving = true;
        public bool IsMoving { get { return _isMoving; } set { _isMoving = value; } }
        public abstract float MoveSpeed { get; set; }

        public Vector2 LookDirection { get { return _currentDirection; } set { _currentDirection = value; } }

        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();

            InitalizeDirections();
            //�ʱ� ���� ����
            _currentDirection = _directions[Random.Range(0, _directions.Length)];
            _timer = 0f;
        }

        public Vector2 RoundDirection(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x);
            angle = Mathf.Round(angle / (Mathf.PI / 4) * (Mathf.PI / 4));
            return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
        public void MoveCharacter()
        {
            //Ÿ�̸� ����
            _timer += Time.fixedDeltaTime;
            //������ȯ
            if (_timer > _changeDirectionInterval)
            {
                //���ο� ���� ����
                _currentDirection = _directions[Random.Range(0, _directions.Length)];
                _timer = 0f;
            }

            //������ٵ�� ���� ��� �̵�
            Vector2 targetPosition = _rb.position + _currentDirection * MoveSpeed * Time.fixedDeltaTime;
            _rb.MovePosition(targetPosition);
        }

        private void InitalizeDirections()
        {
            _directions = new Vector2[8];
            int index = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0) continue;
                    _directions[index++] = new Vector2(x, y).normalized;
                }
            }
        }
    }
}
