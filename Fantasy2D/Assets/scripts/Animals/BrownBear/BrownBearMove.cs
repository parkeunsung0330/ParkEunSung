using UnityEngine;

namespace TestFantasy2D
{
    public class BrownBearMove : AnimalMove
    {
        //�̵� �ӵ�
       [SerializeField] float _moveSpeed = 1.0f;
        public override float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    }
}
